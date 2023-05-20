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
        // Dereference the window object. 
        Program.win = null;
    }
    static onReady() {
        Program.win = new electron_1.BrowserWindow({
            frame: false,
            show: false,
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
        electron_1.ipcMain.on("closeWindow", () => {
            Program.win.close();
        });
        electron_1.ipcMain.on("maximizeWindow", () => {
            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        electron_1.ipcMain.on("minimizeWindow", () => {
            Program.win.minimize();
        });
    }
    static main(app) {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);
        Program.setupIPC();
    }
}
exports.default = Program;
