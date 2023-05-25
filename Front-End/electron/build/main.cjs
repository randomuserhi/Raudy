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
