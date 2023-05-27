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
const electron_1 = require("electron");
const path = __importStar(require("path"));
const net = __importStar(require("net"));
const os = __importStar(require("os"));
class Program {
    static onWindowAllClosed() {
        if (process.platform !== "darwin") {
            Program.app.quit();
        }
    }
    static onClose() {
        Program.win = null;
    }
    static onReady() {
        Program.win = new electron_1.BrowserWindow({
            frame: false,
            show: false,
            backgroundColor: "rgba(0, 0, 0, 0)",
            webPreferences: {
                nodeIntegration: false,
                contextIsolation: true,
                preload: path.join(__dirname, "preload.cjs")
            }
        });
        Program.win.on('closed', Program.onClose);
        Program.win.loadFile(path.join(__dirname, "assets/main/main.html"));
        Program.win.maximize();
        Program.win.show();
        let textEncoder = new TextEncoder();
        let textDecoder = new TextDecoder();
        let client = new net.Socket();
        client.connect(65034, "127.0.0.1", function () {
            Program.log("connected");
            let body = textEncoder.encode(JSON.stringify({
                "status": "Success",
                "header": {
                    "local_id": 0,
                    "type": "getEpisodes"
                },
                "result": {},
                "messages": []
            }));
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
            Program.log(body.byteLength.toString());
            for (let i = 0; i < body.byteLength; ++i) {
                buffer[i + 4] = body[i];
            }
            client.write(buffer);
        });
        const headerSize = 4;
        let read = 0;
        let state = 0;
        let msgSize;
        let recvBuffer = new Uint8Array(1024);
        client.on("data", (buffer) => {
            let slice = 0;
            while (slice < client.bytesRead) {
                switch (state) {
                    case 0:
                        if (recvBuffer.byteLength < headerSize)
                            recvBuffer = new Uint8Array(headerSize);
                        if (read < headerSize) {
                            for (let i = 0; i < headerSize && i < client.bytesRead; ++i, ++read) {
                                recvBuffer[read] = buffer[slice + i];
                            }
                        }
                        else {
                            slice += read;
                            read = 0;
                            state = 1;
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
                            Program.log(msgSize.toString());
                        }
                        break;
                    case 1:
                        if (recvBuffer.byteLength < msgSize)
                            recvBuffer = new Uint8Array(msgSize);
                        if (read < msgSize) {
                            for (let i = 0; i < msgSize && i < client.bytesRead; ++i, ++read) {
                                recvBuffer[read] = buffer[slice + i];
                            }
                        }
                        else {
                            slice += read;
                            read = 0;
                            state = 0;
                            let msg = "";
                            for (let i = 0; i < msgSize; ++i) {
                                msg += String.fromCharCode(recvBuffer[i]);
                            }
                            Program.log(msg);
                        }
                        break;
                }
            }
        });
    }
    static setupIPC() {
        electron_1.ipcMain.on("closeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            if (Program.win === null)
                return;
            Program.win.close();
        });
        electron_1.ipcMain.on("maximizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            if (Program.win === null)
                return;
            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        electron_1.ipcMain.on("minimizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            if (Program.win === null)
                return;
            Program.win.minimize();
        });
    }
    static isTrustedFrame(frame) {
        if (Program.win === null)
            return false;
        return frame === Program.win.webContents.mainFrame;
    }
    static log(message) {
        if (Program.win === null)
            return;
        Program.win.webContents.executeJavaScript(`console.log(\`${message}\`);`);
    }
    static main(app) {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);
        Program.setupIPC();
    }
}
exports.default = Program;
