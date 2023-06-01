"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.tcpClient = void 0;
const rnu_cjs_1 = require("./RNU/rnu.cjs");
const net = __importStar(require("net"));
const os = __importStar(require("os"));
let textEncoder = new TextEncoder;
let _tcpClient = function () {
    this._eventMap = new Map();
};
_tcpClient.prototype.addEventListener = function (type, listener) {
    if (!this._eventMap.has(type))
        this._eventMap.set(type, new Set());
    let listeners = this._eventMap.get(type);
    listeners.add(listener);
};
_tcpClient.prototype.removeEventListener = function (type, listener) {
    let listeners = this._eventMap.get(type);
    if (rnu_cjs_1.core.exists(listeners))
        listeners.delete(listener);
};
_tcpClient.prototype.dispatchEvent = function (type, ev) {
    let listeners = this._eventMap.get(type);
    if (rnu_cjs_1.core.exists(listeners))
        for (let listener of listeners)
            listener.call(this, ev);
};
_tcpClient.prototype.connect = function (ip, port, connectionListener) {
    if (rnu_cjs_1.core.exists(this._socket))
        this._socket.destroy();
    this._socket = new net.Socket;
    this._socket.connect(port, ip, connectionListener);
    const headerSize = 4;
    let read = 0;
    let state = 0;
    let msgSize;
    let recvBuffer = new Uint8Array(1024);
    this._socket.on("data", (buffer) => {
        if (this._socket === null)
            return;
        let slice = 0;
        while (slice < this._socket.bytesRead) {
            switch (state) {
                case 0:
                    if (recvBuffer.byteLength < headerSize)
                        recvBuffer = new Uint8Array(headerSize);
                    if (read < headerSize) {
                        for (let i = 0; i < headerSize && i < this._socket.bytesRead; ++i, ++read) {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    }
                    else {
                        slice += read;
                        read = 0;
                        if (os.endianness() === "LE") {
                            msgSize = (recvBuffer[0] << 24) |
                                (recvBuffer[1] << 16) |
                                (recvBuffer[2] << 8) |
                                (recvBuffer[3] << 0);
                        }
                        else {
                            msgSize = (recvBuffer[0] << 0) |
                                (recvBuffer[1] << 8) |
                                (recvBuffer[2] << 16) |
                                (recvBuffer[3] << 24);
                        }
                        if (msgSize === 0)
                            return;
                        state = 1;
                    }
                    break;
                case 1:
                    if (recvBuffer.byteLength < msgSize)
                        recvBuffer = new Uint8Array(msgSize);
                    if (read < msgSize) {
                        for (let i = 0; i < msgSize && i < this._socket.bytesRead; ++i, ++read) {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    }
                    else {
                        slice += read;
                        read = 0;
                        let msg = "";
                        for (let i = 0; i < msgSize; ++i) {
                            msg += String.fromCharCode(recvBuffer[i]);
                        }
                        let message = JSON.parse(msg);
                        let event = {
                            message: message
                        };
                        this.dispatchEvent(message.header.type, event);
                        state = 0;
                    }
                    break;
            }
        }
    });
};
_tcpClient.prototype.send = function (message) {
    if (!rnu_cjs_1.core.exists(this._socket))
        throw new Error("Socket is null");
    let body = textEncoder.encode(JSON.stringify(message));
    let buffer = new Uint8Array(4 + body.byteLength);
    if (os.endianness() === "LE") {
        buffer[0] = (body.byteLength & 0xff000000) >> 24;
        buffer[1] = (body.byteLength & 0x00ff0000) >> 16;
        buffer[2] = (body.byteLength & 0x0000ff00) >> 8;
        buffer[3] = (body.byteLength & 0x000000ff) >> 0;
    }
    else {
        buffer[3] = (body.byteLength & 0xff000000) >> 24;
        buffer[2] = (body.byteLength & 0x00ff0000) >> 16;
        buffer[1] = (body.byteLength & 0x0000ff00) >> 8;
        buffer[0] = (body.byteLength & 0x000000ff) >> 0;
    }
    for (let i = 0; i < body.byteLength; ++i) {
        buffer[i + 4] = body[i];
    }
    this._socket.write(buffer);
};
exports.tcpClient = _tcpClient;
