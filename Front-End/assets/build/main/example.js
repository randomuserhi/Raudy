RHU.module(new Error(), "main", { Macro: "rhu/macro" }, function ({ Macro }) {
    Macro((() => {
        let test = function () {
            this.item.innerHTML = "Working!!!";
        };
        return test;
    })(), "test", `
            <li rhu-id="item"></li>
            `, {
        element: `<ul></ul>`
    });
    let other = document.createMacro("test");
    document.body.append(other);
});
