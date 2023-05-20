const { contextBridge, ipcRenderer } = require("electron"); // Import contextBridge, ipcRenderer from electron module

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