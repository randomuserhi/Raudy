"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const electron_1 = require("electron");
const path = require("path");
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
