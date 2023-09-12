declare namespace RHU { 
    interface Modules {
        "main": void;
    }
    namespace Macro {
        interface TemplateMap {
            "test": test;
        }
    }
}

interface test extends HTMLUListElement
{
    item: HTMLLIElement
}

RHU.module(new Error(), "main", 
    { Macro: "rhu/macro" },
    function({ Macro }) {
        Macro((() => {
            let test = function(this: test)
            {
                this.item.innerHTML = "Working!!!";
            } as RHU.Macro.Constructor<test>;
            
            return test;    
        })(), "test", //html
            `
            <li rhu-id="item"></li>
            `, {
                element: //html
                `<ul></ul>`
            });

        let other = document.createMacro("test");
        document.body.append(other);
    }
);