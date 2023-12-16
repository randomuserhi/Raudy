declare namespace RHU {
    interface Modules {
        "docuscript/components/molecules/codeblock": Macro.Template<"docuscript/molecules/codeblock">;
    }

    namespace Macro {
        interface TemplateMap {
            "docuscript/molecules/codeblock": RHUDocuscript.Molecules.Codeblock;
        }
    }
}

declare namespace RHUDocuscript {
    namespace Molecules {
        interface Codeblock extends HTMLDivElement {
            setLanguage(language?: string): void;
            
            code: HTMLElement;
        }
    }
}

RHU.module(new Error(), "docuscript/components/molecules/codeblock", { 
    Macro: "rhu/macro", style: "docuscript/components/molecules/codeblock/style",
}, function({ 
    Macro, style,
}) {
    const codeblock = Macro((() => {
        const codeblock = function(this: RHUDocuscript.Molecules.Codeblock) {
        } as RHU.Macro.Constructor<RHUDocuscript.Molecules.Codeblock>;
        codeblock.prototype.setLanguage = function(language) {
            if (language) {
                this.code.classList.toggle(language, true);
            } else {
                this.code.classList.toggle("language-plaintext", true);
            }
            hljs.highlightElement(this.code);
        };

        codeblock.prototype.append = function(...args) {
            return HTMLElement.prototype.append.call(this.code, ...args);
        }

        return codeblock;
    })(), "docuscript/molecules/codeblock", //html
        `
        <pre><code rhu-id="code"></code></pre>
        `, {
            element: //html
            `<div></div>`
        });

    return codeblock;
});