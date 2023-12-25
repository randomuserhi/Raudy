import { core } from "../RNU/rnu.cjs";
import * as net from "net";
import * as os from "os";

export declare namespace Message
{
    type SUCCESS = "Success";
    type ERROR = "Error";
}

export interface UnknownMessage
{
    status: Message.SUCCESS | Message.ERROR;
    header: {
        local_id: number,
        remote_id: number,
        type: string
    };
    content: unknown;
    tags: string;
}

export interface Message<T extends string & keyof MessageEventMap, K = unknown> extends UnknownMessage
{
    header: {
        local_id: number,
        remote_id: number,
        type: T
    };
    content: K;
}

export interface MessageEvent<T extends UnknownMessage>
{
    message: T;
}
export interface MessageEventMap
{

}

export class TcpClient {
    private static textEncoder = new TextEncoder();

    private socket: net.Socket | null;
    private eventMap: Map<string, Set<Function>>;

    constructor() {
        this.eventMap = new Map();
    }

    public addEventListener<T extends (string & {}) | keyof MessageEventMap>(type: T, listener: (this: TcpClient, ev: T extends keyof MessageEventMap ? MessageEventMap[T] : any) => any) {
        if (!this.eventMap.has(type)) {
            this.eventMap.set(type, new Set<Function>());
        }
        
        const listeners = this.eventMap.get(type)!;
        listeners.add(listener);
    }
    
    public removeEventListener<T extends (string & {}) | keyof MessageEventMap>(type: T, listener: (this: TcpClient, ev: T extends keyof MessageEventMap ? MessageEventMap[T] : any) => any) {
        const listeners = this.eventMap.get(type);
        if (core.exists(listeners)) {
            listeners.delete(listener);
        }
    }

    public dispatchEvent<T extends (string & {}) | keyof MessageEventMap>(type: T, ev: T extends keyof MessageEventMap ? MessageEventMap[T] : any) {
        const listeners = this.eventMap.get(type);
        if (core.exists(listeners)) {
            for (const listener of listeners) {
                listener.call(this, ev);
            }
        }
    }

    public async send<T extends UnknownMessage>(message: T) {
        if (!core.exists(this.socket))
            throw new Error("Socket is null");
        
        const body: Uint8Array = TcpClient.textEncoder.encode(JSON.stringify(message));
        
        const buffer = new Uint8Array(4 + body.byteLength);
        // Write message length to buffer
        if (os.endianness() !== "LE") {
            buffer[0] = (body.byteLength&0xff000000)>>24;
            buffer[1] = (body.byteLength&0x00ff0000)>>16;
            buffer[2] = (body.byteLength&0x0000ff00)>>8;
            buffer[3] = (body.byteLength&0x000000ff)>>0;
        } else {
            buffer[3] = (body.byteLength&0xff000000)>>24;
            buffer[2] = (body.byteLength&0x00ff0000)>>16;
            buffer[1] = (body.byteLength&0x0000ff00)>>8;
            buffer[0] = (body.byteLength&0x000000ff)>>0;
        }
        
        // Write message to buffer
        for (let i = 0; i < body.byteLength; ++i) {
            buffer[i + 4] = body[i];
        }
        
        const socket = this.socket;
        return new Promise<void>((resolve, reject) => {
            socket.write(buffer, (error) => core.exists(error) ? reject(error) : resolve());
        });
    }

    public async connect(ip: string, port: number) {
        if (core.exists(this.socket))
            this.socket.destroy();
        const socket = this.socket = new net.Socket();

        const headerSize: number = 4;
        let read: number = 0;
        let state: number = 0;
        let msgSize: number;
        let recvBuffer: Uint8Array = new Uint8Array(1024);
        socket.on("data", (buffer: Buffer): void => {
            if (socket === null)
                return;

            let slice: number = 0;
            while (slice < socket.bytesRead) {
                switch(state) {
                case 0:
                    // State 0 => Looking for message header

                    if (recvBuffer.byteLength < headerSize)
                        recvBuffer = new Uint8Array(headerSize);

                    if (read < headerSize) {
                        // Read message header from buffer
                        for (let i = 0; i < headerSize && i < socket.bytesRead; ++i, ++read) {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    } else {
                        // Decode message header and transition to next state when applicable

                        slice += read;
                        read = 0;

                        if (os.endianness() !== "LE") {
                            msgSize = (recvBuffer[0] << 24) |
                                    (recvBuffer[1] << 16) |
                                    (recvBuffer[2] << 8)  |
                                    (recvBuffer[3] << 0);
                        } else {
                            msgSize = (recvBuffer[0] << 0)  |
                                    (recvBuffer[1] << 8)  |
                                    (recvBuffer[2] << 16) |
                                    (recvBuffer[3] << 24);
                        }
                        if (msgSize === 0) return; // no more messages in buffer => exit

                        // transition to next state
                        state = 1;
                    }
                    break;
                case 1:
                    // State 1 => Reading message based on message header

                    if (recvBuffer.byteLength < msgSize)
                        recvBuffer = new Uint8Array(msgSize);

                    if (read < msgSize) {
                        // Read message from buffer
                        for (let i = 0; i < msgSize && i < socket.bytesRead; ++i, ++read) {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    } else {
                        // Decode message and trigger "message" event

                        slice += read;
                        read = 0;

                        let msg = "";
                        for (let i = 0; i < msgSize; ++i) {
                            msg += String.fromCharCode(recvBuffer[i]);
                        }
                        
                        const message: UnknownMessage = JSON.parse(msg);
                        const event: MessageEvent<UnknownMessage> = {
                            message: message
                        };
                        this.dispatchEvent(message.header.type, event);

                        // Transition back to state 0
                        state = 0;
                    }
                    break;
                }
            }
        });

        return new Promise<void>((resolve, reject) => {
            const errListener = (error: Error) => {
                socket.off("error", errListener);
                reject(error);
            };
            socket.on("error", errListener);
            socket.connect(port, ip, () => resolve());
        });
    }
}

// TODO(randomuserhi): Refactor all this code...
//                     - re write using modern js (Class structure etc...)

/*
export interface TcpClient
{
    connect(ip: string, port: number, connectionListener?: () => void): void;
    send<T extends UnknownMessage>(message: T): void;

    dispatchEvent(type: string, ev: unknown): void;
    dispatchEvent<T extends keyof MessageEventMap>(type: T, ev: MessageEventMap[T]): void;

    addEventListener<T extends keyof MessageEventMap>(type: T, listener: (this: TcpClient, ev: MessageEventMap[T]) => any): void;
    addEventListener(type: string, listener: (ev: unknown) => any): void;
    removeEventListener<T extends keyof MessageEventMap>(type: T, listener: (this: TcpClient, ev: MessageEventMap[T]) => any): void;
    removeEventListener(type: string, listener: (ev: unknown) => any): void;
}
export interface TcpClientConstructor
{
    new(): TcpClient;
    prototype: TcpClient;
}

interface _TcpClient extends TcpClient
{
    _socket: net.Socket | null;
    _eventMap: Map<string, Set<Function>>;
}
interface _TcpClientConstructor extends TcpClientConstructor
{
    new(): _TcpClient;
    prototype: _TcpClient;
}

const textEncoder = new TextEncoder;
const _TcpClient: _TcpClientConstructor = function(this: _TcpClient) {
    this._eventMap = new Map();
} as Function as _TcpClientConstructor;
_TcpClient.prototype.addEventListener = function(this: _TcpClient, type: string, listener: (ev: unknown) => any): void {
    if (!this._eventMap.has(type))
        this._eventMap.set(type, new Set<Function>());

    const listeners = this._eventMap.get(type)!;
    listeners.add(listener);
};
_TcpClient.prototype.removeEventListener = function(this: _TcpClient, type: string, listener: (ev: unknown) => any): void {
    const listeners = this._eventMap.get(type);
    if (core.exists(listeners))
        listeners.delete(listener);
};
_TcpClient.prototype.dispatchEvent = function(this: _TcpClient, type: string, ev: unknown): void {
    const listeners = this._eventMap.get(type);
    if (core.exists(listeners))
        for (const listener of listeners)
            listener.call(this, ev);
};
_TcpClient.prototype.connect = function(this: _TcpClient, ip: string, port: number, connectionListener: () => void | undefined): void {
    if (core.exists(this._socket))
        this._socket.destroy();

    this._socket = new net.Socket();
    this._socket.on('error', (error) => {
        // TODO(randomuserhi): Proper error handling
        console.log(error);
    });
    this._socket.on("connect", () => {
        // TODO(randomuserhi): Proper connection handling
        console.log("connected");
    });

    this._socket.connect(port, ip, connectionListener);

    const headerSize: number = 4;
    let read: number = 0;
    let state: number = 0;
    let msgSize: number;
    let recvBuffer: Uint8Array = new Uint8Array(1024);
    this._socket.on("data", (buffer: Buffer): void => {
        if (this._socket === null)
            return;

        let slice: number = 0;
        while (slice < this._socket.bytesRead) {
            switch(state) {
            case 0:
                // State 0 => Looking for message header

                if (recvBuffer.byteLength < headerSize)
                    recvBuffer = new Uint8Array(headerSize);

                if (read < headerSize) {
                    // Read message header from buffer
                    for (let i = 0; i < headerSize && i < this._socket.bytesRead; ++i, ++read) {
                        recvBuffer[read] = buffer[slice + i];
                    }
                } else {
                    // Decode message header and transition to next state when applicable

                    slice += read;
                    read = 0;

                    if (os.endianness() !== "LE") {
                        msgSize = (recvBuffer[0] << 24) |
                                (recvBuffer[1] << 16) |
                                (recvBuffer[2] << 8)  |
                                (recvBuffer[3] << 0);
                    } else {
                        msgSize = (recvBuffer[0] << 0)  |
                                (recvBuffer[1] << 8)  |
                                (recvBuffer[2] << 16) |
                                (recvBuffer[3] << 24);
                    }
                    if (msgSize === 0) return; // no more messages in buffer => exit

                    // transition to next state
                    state = 1;
                }
                break;
            case 1:
                // State 1 => Reading message based on message header

                if (recvBuffer.byteLength < msgSize)
                    recvBuffer = new Uint8Array(msgSize);

                if (read < msgSize) {
                    // Read message from buffer
                    for (let i = 0; i < msgSize && i < this._socket.bytesRead; ++i, ++read) {
                        recvBuffer[read] = buffer[slice + i];
                    }
                } else {
                    // Decode message and trigger "message" event

                    slice += read;
                    read = 0;

                    let msg = "";
                    for (let i = 0; i < msgSize; ++i) {
                        msg += String.fromCharCode(recvBuffer[i]);
                    }
                    
                    const message: UnknownMessage = JSON.parse(msg);
                    const event: MessageEvent<UnknownMessage> = {
                        message: message
                    };
                    this.dispatchEvent(message.header.type, event);

                    // Transition back to state 0
                    state = 0;
                }
                break;
            }
        }
    });
};
_TcpClient.prototype.send = function<T extends UnknownMessage>(this: _TcpClient, message: T): void {
    if (!core.exists(this._socket))
        throw new Error("Socket is null");

    const body: Uint8Array = textEncoder.encode(JSON.stringify(message));

    const buffer = new Uint8Array(4 + body.byteLength);
    // Write message length to buffer
    if (os.endianness() !== "LE") {
        buffer[0] = (body.byteLength&0xff000000)>>24;
        buffer[1] = (body.byteLength&0x00ff0000)>>16;
        buffer[2] = (body.byteLength&0x0000ff00)>>8;
        buffer[3] = (body.byteLength&0x000000ff)>>0;
    } else {
        buffer[3] = (body.byteLength&0xff000000)>>24;
        buffer[2] = (body.byteLength&0x00ff0000)>>16;
        buffer[1] = (body.byteLength&0x0000ff00)>>8;
        buffer[0] = (body.byteLength&0x000000ff)>>0;
    }

    // Write message to buffer
    for (let i = 0; i < body.byteLength; ++i) {
        buffer[i + 4] = body[i];
    }
    
    this._socket.write(buffer);
};

export const TcpClient: TcpClientConstructor = _TcpClient;*/