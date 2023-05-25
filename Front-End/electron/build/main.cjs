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
//import * as net from "net";
/*let client = new net.Socket();
client.connect(65034, "127.0.0.1", function() {
    Program.log("connected");
    client.write("Crazy");
});*/
// TODO(randomuserhi): Look into https://www.electronjs.org/docs/latest/tutorial/security#csp-http-headers, instead of relying on
//                     <meta> tags in loaded HTML
class Program {
    static onWindowAllClosed() {
        if (process.platform !== "darwin") {
            Program.app.quit();
        }
    }
    static onClose() {
        // Dereference the window object. 
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
                preload: path.join(__dirname, "preload.cjs") // use a preload script
            }
        });
        Program.win.on('closed', Program.onClose);
        Program.win.loadFile(path.join(__dirname, "assets/main/main.html")); // load the main page
        Program.win.maximize();
        Program.win.show();
    }
    static setupIPC() {
        electron_1.ipcMain.on("closeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            Program.win.close();
        });
        electron_1.ipcMain.on("maximizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        electron_1.ipcMain.on("minimizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame))
                return;
            Program.win.minimize();
        });
    }
    static isTrustedFrame(frame) {
        // NOTE(randomuserhi): This simply checks if the frame making the call is the same
        //                     as the loaded frame of the browser window.
        //                     This is potentially an issue if the main browser window loads 
        //                     an external unsafe URL since then this check doesn't work.
        //
        //                     For the use case of this application, the browser window should never
        //                     load an external URL so this check is fine.
        return frame === Program.win.webContents.mainFrame;
    }
    // TODO(randomuserhi): Remove this, purely for debugging => or atleast make a proper API for it
    static log(message) {
        Program.win.webContents.executeJavaScript(`console.log("${message}");`);
    }
    static main(app) {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);
        Program.setupIPC();
    }
}
exports.default = Program;
