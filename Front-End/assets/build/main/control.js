document.getElementById("close-btn").addEventListener("click", (e) => {
    window.api.closeWindow();
});
document.getElementById("max-btn").addEventListener("click", (e) => {
    window.api.maximizeWindow();
});
document.getElementById("min-btn").addEventListener("click", (e) => {
    window.api.minimizeWindow();
});
RHU.module({ name: "test", hard: ["RHU.Macro"] }, function () {
    let test = function () {
        this.item.innerHTML = "Working!!!";
    };
    RHU.Macro(test, "test", /*html*/ `
        <li rhu-id="item"></li>
        `, { element: /*html*/ `<ul></ul>` });
    let other = document.createMacro("test");
    document.body.append(other);
});
