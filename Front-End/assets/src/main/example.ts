interface test extends HTMLUListElement
{
    item: HTMLLIElement
}
interface testConstructor extends RHU.Macro.Constructor<test>
{
    
}

declare namespace RHU { namespace Macro {
    interface TemplateMap
    {
        "test": test
    }      
}}

RHU.import(RHU.module({ trace: new Error(),
    name: "test", hard: ["RHU.Macro"],
    callback: function()
    {
        let { RHU } = window.RHU.require(window, this);

        let test = function(this: test)
        {
            this.item.innerHTML = "Working!!!";
        } as testConstructor;
        RHU.Macro(test, "test", //html
            `
            <li rhu-id="item"></li>
            `, {
                element: //html
                `<ul></ul>`
            });

        let other = document.createMacro("test");
        document.body.append(other);
    }
}));