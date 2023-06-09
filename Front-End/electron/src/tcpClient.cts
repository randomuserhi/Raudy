import { core } from "./RNU/rnu.cjs"
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
    result: unknown;
    messages: string[];
}

export interface Message<T extends string & keyof MessageEventMap, K = unknown> extends UnknownMessage
{
    header: {
        local_id: number,
        remote_id: number,
        type: T
    };
    result: K;
}

export interface MessageEvent<T extends UnknownMessage>
{
    message: T;
}
export interface MessageEventMap
{

}

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

let textEncoder = new TextEncoder;
let _tcpClient: _TcpClientConstructor = function(this: _TcpClient)
{
    this._eventMap = new Map();
} as Function as _TcpClientConstructor;
_tcpClient.prototype.addEventListener = function(this: _TcpClient, type: string, listener: (ev: unknown) => any): void
{
    if (!this._eventMap.has(type))
        this._eventMap.set(type, new Set<Function>());

    let listeners = this._eventMap.get(type)!;
    listeners.add(listener);
};
_tcpClient.prototype.removeEventListener = function(this: _TcpClient, type: string, listener: (ev: unknown) => any): void
{
    let listeners = this._eventMap.get(type);
    if (core.exists(listeners))
        listeners.delete(listener);
};
_tcpClient.prototype.dispatchEvent = function(this: _TcpClient, type: string, ev: unknown): void
{
    let listeners = this._eventMap.get(type);
    if (core.exists(listeners))
        for (let listener of listeners)
            listener.call(this, ev);
};
_tcpClient.prototype.connect = function(this: _TcpClient, ip: string, port: number, connectionListener: () => void | undefined): void
{
    if (core.exists(this._socket))
        this._socket.destroy();

    this._socket = new net.Socket;
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
        while (slice < this._socket.bytesRead)
        {
            switch(state)
            {
            case 0:
                // State 0 => Looking for message header

                if (recvBuffer.byteLength < headerSize)
                    recvBuffer = new Uint8Array(headerSize);

                if (read < headerSize)
                {
                    // Read message header from buffer
                    for (let i = 0; i < headerSize && i < this._socket.bytesRead; ++i, ++read)
                    {
                        recvBuffer[read] = buffer[slice + i];
                    }
                }
                else
                {
                    // Decode message header and transition to next state when applicable

                    slice += read;
                    read = 0;

                    if (os.endianness() === "LE")
                    {
                        msgSize = (recvBuffer[0] << 24) |
                                (recvBuffer[1] << 16) |
                                (recvBuffer[2] << 8)  |
                                (recvBuffer[3] << 0);
                    }
                    else
                    {
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

                if (read < msgSize)
                {
                    // Read message from buffer
                    for (let i = 0; i < msgSize && i < this._socket.bytesRead; ++i, ++read)
                    {
                        recvBuffer[read] = buffer[slice + i];
                    }
                }
                else
                {
                    // Decode message and trigger "message" event

                    slice += read;
                    read = 0;

                    let msg = "";
                    for (let i = 0; i < msgSize; ++i)
                    {
                        msg += String.fromCharCode(recvBuffer[i]);
                    }
                    
                    let message: UnknownMessage = JSON.parse(msg);
                    let event: MessageEvent<UnknownMessage> = {
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
_tcpClient.prototype.send = function<T extends UnknownMessage>(this: _TcpClient, message: T): void
{
    if (!core.exists(this._socket))
        throw new Error("Socket is null");

    let body: Uint8Array = textEncoder.encode(JSON.stringify(message));

    let buffer = new Uint8Array(4 + body.byteLength);
    if (os.endianness() === "LE")
    {
        buffer[0] = (body.byteLength&0xff000000)>>24;
        buffer[1] = (body.byteLength&0x00ff0000)>>16;
        buffer[2] = (body.byteLength&0x0000ff00)>>8;
        buffer[3] = (body.byteLength&0x000000ff)>>0;
    }
    else
    {
        buffer[3] = (body.byteLength&0xff000000)>>24;
        buffer[2] = (body.byteLength&0x00ff0000)>>16;
        buffer[1] = (body.byteLength&0x0000ff00)>>8;
        buffer[0] = (body.byteLength&0x000000ff)>>0;
    }

    for (let i = 0; i < body.byteLength; ++i)
    {
        buffer[i + 4] = body[i];
    }
    
    this._socket.write(buffer);
};

export let tcpClient: TcpClientConstructor = _tcpClient;