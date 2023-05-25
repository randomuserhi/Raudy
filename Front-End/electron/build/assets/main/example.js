RHU.import(RHU.module({ trace: new Error(),
    name: "test", hard: ["RHU.Macro"],
    callback: function () {
        let { RHU } = window.RHU.require(window, this);
        let test = function () {
            this.item.innerHTML = "Working!!!";
        };
        RHU.Macro(test, "test", `
            <li rhu-id="item"></li>
            `, {
            element: `<ul></ul>`
        });
        let other = document.createMacro("test");
        document.body.append(other);
    }
}));
