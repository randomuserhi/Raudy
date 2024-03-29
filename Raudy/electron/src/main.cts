import { BrowserWindow, ipcMain } from "electron";
import * as path from "path";

import { TcpClient, Message } from "./Net/tcpClient.cjs";

declare module "./Net/tcpClient.cjs"
{
    interface MessageEventMap
    {
        "HeartBeat": MessageEvent<Message<"HeartBeat", string>>;
    }
}

// TODO(randomuserhi): Look into https://www.electronjs.org/docs/latest/tutorial/security#csp-http-headers, instead of relying on
//                     <meta> tags in loaded HTML

export default class Program {
    static win: Electron.BrowserWindow | null;
    static app: Electron.App;

    private static onWindowAllClosed(): void {
        if (process.platform !== "darwin") {
            Program.app.quit();
        }
    }

    private static onClose(): void {
        // Dereference the window object. 
        Program.win = null;
    }

    private static onReady(): void {
        Program.win = new BrowserWindow({
            frame: false, // remove the window frame
            show: false, // hide the window,
            backgroundColor: "#fff", // always set a bg color to enable font antialiasing
            webPreferences: {
                nodeIntegration: false, // is default value after Electron v5 - is disabled as per security (https://www.electronjs.org/docs/latest/tutorial/security)
                contextIsolation: true, // protect against prototype pollution - (https://www.electronjs.org/docs/latest/tutorial/context-isolation)
                preload: path.join(__dirname, "preload.cjs") // use a preload script
            }
        });
        Program.win.on('closed', Program.onClose);
        Program.win.loadFile(path.join(__dirname, "assets/main/main.html")); // load the main page
        
        //Program.win.maximize();
        Program.win.show();

        const client: TcpClient = new TcpClient();
        client.connect("127.0.0.1", 56759);
        
        client.addEventListener("HeartBeat", (e) => {
            console.log("heartbeat received!");
            const message: Message<"HeartBeat", string> = {
                status: "Success",
                header: {
                    local_id: 0, // TODO(randomuserhi): generate local_id
                    remote_id: e.message.header.local_id,
                    type: "HeartBeat"
                },
                content: "",
                tags: ""
            };
            client.send(message);
        });
    }

    private static setupIPC(): void {
        ipcMain.on("closeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;
            if (Program.win === null) return;
            
            Program.win.close();
        });
        ipcMain.on("maximizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;
            if (Program.win === null) return;

            Program.win.isMaximized() ? Program.win.unmaximize() : Program.win.maximize();
        });
        ipcMain.on("minimizeWindow", (e) => {
            if (!Program.isTrustedFrame(e.senderFrame)) return;
            if (Program.win === null) return;

            Program.win.minimize();
        });
    }

    private static isTrustedFrame(frame: Electron.WebFrameMain): boolean {
        if (Program.win === null) return false;
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
    static log(message: string): void {
        if (Program.win === null) return;
        Program.win.webContents.executeJavaScript(`console.log(\`${message}\`);`);
    }

    static main(app: Electron.App): void {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);

        Program.setupIPC();
    }
}