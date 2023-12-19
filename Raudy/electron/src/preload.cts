import { contextBridge, ipcRenderer } from "electron";

// TODO(randomuserhi): Look into https://stackoverflow.com/a/57656281/9642458 for better security

contextBridge.exposeInMainWorld(
    "api", {
        closeWindow: () => { // When window.api.closeWindow() is called, send "closeWindow" event to ipcMain
            ipcRenderer.send("closeWindow");
        },
        minimizeWindow: () => { // When window.api.closeWindow() is called, send "minimizeWindow" event to ipcMain
            ipcRenderer.send("minimizeWindow");
        },
        maximizeWindow: () => { // When window.api.closeWindow() is called, send "maximizeWindow" event to ipcMain
            ipcRenderer.send("maximizeWindow");
        }
    }
);