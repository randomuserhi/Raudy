"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const { contextBridge, ipcRenderer } = require("electron"); // Import contextBridge, ipcRenderer from electron module
// TODO(randomuserhi): Look into https://stackoverflow.com/a/57656281/9642458 for better security
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
