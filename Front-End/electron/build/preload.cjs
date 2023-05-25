"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const { contextBridge, ipcRenderer } = require("electron");
contextBridge.exposeInMainWorld("api", {
    closeWindow: () => {
        ipcRenderer.send("closeWindow");
    },
    minimizeWindow: () => {
        ipcRenderer.send("minimizeWindow");
    },
    maximizeWindow: () => {
        ipcRenderer.send("maximizeWindow");
    }
});
