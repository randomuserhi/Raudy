import { BrowserWindow, ipcMain } from "electron";
import * as path from "path";

export default class Program 
{
    static win: Electron.BrowserWindow;
    static app: Electron.App;
    static BrowserWindow;

    private static onWindowAllClosed() 
    {
        if (process.platform !== "darwin") {
            Program.app.quit();
        }
    }

    private static onClose() 
    {
        // Dereference the window object. 
        Program.win = null;
    }

    private static onReady() 
    {
        Program.win = new BrowserWindow({
            frame: false, // remove the window frame
            show: false, // hide the window
            webPreferences: {
                nodeIntegration: false, // is default value after Electron v5 - is disabled as per security (https://www.electronjs.org/docs/latest/tutorial/security)
                contextIsolation: true, // protect against prototype pollution - (https://www.electronjs.org/docs/latest/tutorial/context-isolation)
                preload: path.join(__dirname, "preload.cjs") // use a preload script
            }
        });
        Program.win.on('closed', Program.onClose);
        Program.win.loadFile(path.join(__dirname, "assets/main/main.html")); // load the main page
        
        Program.win.maximize();
        Program.win.show();
    }

    private static setupIPC()
    {
        ipcMain.on("closeWindow", () => {
            Program.win.close();
        });
        ipcMain.on("maximizeWindow", () => {
            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        ipcMain.on("minimizeWindow", () => {
            Program.win.minimize();
        });
    }

    static main(app: Electron.App) 
    {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);

        Program.setupIPC();
    }
}