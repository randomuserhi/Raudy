import { BrowserWindow, ipcMain } from "electron";
import * as path from "path";

import * as net from "net";
import * as os from "os";

// TODO(randomuserhi): Look into https://www.electronjs.org/docs/latest/tutorial/security#csp-http-headers, instead of relying on
//                     <meta> tags in loaded HTML

export default class Program 
{
    static win: Electron.BrowserWindow | null;
    static app: Electron.App;

    private static onWindowAllClosed(): void
    {
        if (process.platform !== "darwin") {
            Program.app.quit();
        }
    }

    private static onClose(): void
    {
        // Dereference the window object. 
        Program.win = null;
    }

    private static onReady(): void
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

        let textEncoder: TextEncoder = new TextEncoder();
        let textDecoder: TextDecoder = new TextDecoder();

        let client = new net.Socket();
        client.connect(65034, "127.0.0.1", function() {
            Program.log("connected");
            
            let body: Uint8Array = textEncoder.encode(JSON.stringify({
                "status": "Success", // Success / Error
                "header": {
                    "local_id": 0, // message id being sent
                    "type": "getEpisodes" // type of message => so receiver knows how to parse result
                },
                "result": {
                    // body of message
                },
                "messages": [] // stack of server messages if any 
            }));

            let buffer = new Uint8Array(4 + body.byteLength);
            if (os.endianness() === "LE")
            {
                buffer[0] = (body.byteLength&0xff000000)>>24;
                buffer[1] = (body.byteLength&0x00ff0000)>>16;
                buffer[2] = (body.byteLength&0x0000ff00)>>8;
                buffer[3] = (body.byteLength&0x000000ff)>>0;
            }
            else
            {
                buffer[3] = (body.byteLength&0xff000000)>>24;
                buffer[2] = (body.byteLength&0x00ff0000)>>16;
                buffer[1] = (body.byteLength&0x0000ff00)>>8;
                buffer[0] = (body.byteLength&0x000000ff)>>0;
            }

            Program.log(body.byteLength.toString());
            for (let i = 0; i < body.byteLength; ++i)
            {
                buffer[i + 4] = body[i];
            }
            
            client.write(buffer);
        });

        const headerSize: number = 4;
        let read: number = 0;
        let state: number = 0;
        let msgSize: number;
        let recvBuffer: Uint8Array = new Uint8Array(1024);
        client.on("data", (buffer: Buffer) => {
            let slice: number = 0;
            while (slice < client.bytesRead)
            {
                switch(state)
                {
                case 0:
                    if (recvBuffer.byteLength < headerSize)
                        recvBuffer = new Uint8Array(headerSize);

                    if (read < headerSize)
                    {
                        for (let i = 0; i < headerSize && i < client.bytesRead; ++i, ++read)
                        {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    }
                    else
                    {
                        slice += read;
                        read = 0;
                        state = 1;

                        if (os.endianness() === "LE")
                        {
                            msgSize = (recvBuffer[0] << 24) |
                                    (recvBuffer[1] << 16) |
                                    (recvBuffer[2] << 8)  |
                                    (recvBuffer[3] << 0);
                        }
                        else
                        {
                            msgSize = (recvBuffer[0] << 0)  |
                                    (recvBuffer[1] << 8)  |
                                    (recvBuffer[2] << 16) |
                                    (recvBuffer[3] << 24);
                        }
                        if (msgSize === 0) return; // no more messages in buffer
                    }
                    break;
                case 1:
                    if (recvBuffer.byteLength < msgSize)
                        recvBuffer = new Uint8Array(msgSize);

                    if (read < msgSize)
                    {
                        for (let i = 0; i < msgSize && i < client.bytesRead; ++i, ++read)
                        {
                            recvBuffer[read] = buffer[slice + i];
                        }
                    }
                    else
                    {
                        slice += read;
                        read = 0;
                        state = 0;

                        let msg = "";
                        for (let i = 0; i < msgSize; ++i)
                        {
                            msg += String.fromCharCode(recvBuffer[i]);
                        }
                        Program.log(msg);
                    }
                    break;
                }
            }
        })
    }

    private static setupIPC(): void
    {
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

    private static isTrustedFrame(frame: Electron.WebFrameMain): boolean
    {
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
    static log(message: string): void
    {
        if (Program.win === null) return;
        Program.win.webContents.executeJavaScript(`console.log(\`${message}\`);`);
    }

    static main(app: Electron.App): void 
    {
        Program.app = app;
        Program.app.on('window-all-closed', Program.onWindowAllClosed);
        Program.app.on('ready', Program.onReady);

        Program.setupIPC();
    }
}