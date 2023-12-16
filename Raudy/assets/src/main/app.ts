declare namespace RHU { 
    interface Modules {
        "app": void;
    }
    
    namespace Macro {
        interface TemplateMap {
            "app": app
        }      
    }
}

interface app extends HTMLElement {
}

RHU.module(new Error(), "app", { 
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
            `;
        return {
            wrapper,
        };
    });

    Macro((() => {
        const app = function(this: app)
        {
        } as any as RHU.Macro.Constructor<app>;
        
        return app;
    })(), "app", //html
        `
        ${winNav}
        <!-- Content goes here -->
        `, {
            element: //html
            `<div class="${theme} ${style.wrapper}"></div>`
        });

    // Load app
    const app = () => {
        const app = document.createMacro("app");
        document.body.append(app);
    };
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", app);
    } else {
        app();
    }
});