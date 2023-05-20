document.getElementById("close-btn").addEventListener("click", (e) => {
    window.api.closeWindow();
});

document.getElementById("max-btn").addEventListener("click", (e) => {
    window.api.maximizeWindow();
});

document.getElementById("min-btn").addEventListener("click", (e) => {
    window.api.minimizeWindow();
});