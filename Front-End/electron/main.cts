import { BrowserWindow, ipcMain } from "electron";
import * as path from "path";

//import * as net from "net";
/*let client = new net.Socket();
client.connect(65034, "127.0.0.1", function() {
    Program.log("connected");
    client.write("Crazy");
});*/

// TODO(randomuserhi): Look into https://www.electronjs.org/docs/latest/tutorial/security#csp-http-headers, instead of relying on
//                     <meta> tags in loaded HTML

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
            show: false, // hide the window,
            backgroundColor: "rgba(0, 0, 0, 0)", // always set a bg color to enable font antialiasing
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
        ipcMain.on("closeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;

            Program.win.close();
        });
        ipcMain.on("maximizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;

            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        ipcMain.on("minimizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;

            Program.win.minimize();
        });
    }

    private static isTrustedFrame(frame: Electron.WebFrameMain)
    {
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
    static log(message: string)
    {
        Program.win.webContents.executeJavaScript(`console.log("${message}");`);
    }

    static main(app: Electron.App) 
    {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);

        Program.setupIPC();
    }
}