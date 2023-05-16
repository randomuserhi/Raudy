import { BrowserWindow } from 'electron';

export default class Program {
    static mainWindow: Electron.BrowserWindow;
    static application: Electron.App;
    static BrowserWindow;
    private static onWindowAllClosed() {
        if (process.platform !== "darwin") {
            Program.application.quit();
        }
    }

    private static onClose() {
        // Dereference the window object. 
        Program.mainWindow = null;
    }

    private static onReady() {
        Program.mainWindow = new Program.BrowserWindow({ width: 800, height: 600 });
        Program.mainWindow
            .loadURL('file://' + __dirname + '/index.html');
        Program.mainWindow.on('closed', Program.onClose);
    }

    static main(app: Electron.App, browserWindow: typeof BrowserWindow) {
        // we pass the Electron.App object and the  
        // Electron.BrowserWindow into this function 
        // so this class has no dependencies. This 
        // makes the code easier to write tests for 
        Program.BrowserWindow = browserWindow;
        Program.application = app;
        Program.application.on('window-all-closed', Program.onWindowAllClosed);
        Program.application.on('ready', Program.onReady);
    }
}