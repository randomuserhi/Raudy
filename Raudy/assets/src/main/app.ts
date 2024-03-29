declare namespace RHU { 
    interface Modules {
        "__loader__": void;
        "app": () => app;
    }
    
    namespace Macro {
        interface TemplateMap {
            "app": app
        }      
    }
}

interface app extends HTMLElement {
    body: HTMLDivElement;
    load(node: Node): void;
}

(() => {
    const ref: { value?: app } = { value: undefined };
    RHU.module(new Error(), "app", {}, function() {
        return () => ref.value!;
    });

    RHU.module(new Error(), "__loader__", { 
        Macro: "rhu/macro", Style: "rhu/style", theme: "main/theme", 
        winNav: "components/organisms/winNav"
    }, function({ 
        Macro, Style, theme, 
        winNav
    }) {
        const style = Style(({ style }) => {
            const wrapper = style.class`
                width: 100%;
                height: 100%;
                display: flex;
                flex-direction: column;
                `;
            const body = style.class`
                flex: 1;
                `;
            return {
                wrapper,
                body,
            };
        });

        Macro((() => {
            const app = function(this: app) {
                this.load(document.createMacro("routes/catalogue"));
            } as any as RHU.Macro.Constructor<app>;

            app.prototype.load = function(node) {
                this.body.replaceChildren(node);
            };

            return app;
        })(), "app", //html
        `
            ${winNav}
            <!-- Content goes here -->
            <div rhu-id="body" class="${style.body}">
            </div>
            `, {
            element: //html
                `<div class="${theme} ${style.wrapper}"></div>`
        });

        // Load app
        const app = () => {
            const app = document.createMacro("app");
            document.body.append(app);
            ref.value = app;
        };
        if (document.readyState === "loading") {
            document.addEventListener("DOMContentLoaded", app);
        } else {
            app();
        }
    });
})();