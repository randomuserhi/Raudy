declare namespace RHU {
    interface Modules {
        "routes/catalogue": Macro.Template<"routes/catalogue">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue": Routes.catalogue;
        }
    }
}

declare namespace Routes {
    interface catalogue extends HTMLDivElement {
        body: HTMLDivElement;
    }
}

RHU.module(new Error(), "routes/catalogue", { 
    Macro: "rhu/macro", style: "routes/catalogue/style",
    navigation: "routes/catalogue/navigation",
    library: "routes/catalogue/library",
}, function({ 
    Macro, style,
    navigation,
    library,
}) {
    const catalogue = Macro((() => {
        const catalogue = function(this: Routes.catalogue) {
        } as RHU.Macro.Constructor<Routes.catalogue>;

        return catalogue;
    })(), "routes/catalogue", //html
    `
        ${navigation}
        <div rhu-id="body" class="${style.body}">
            ${library}
        </div>
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return catalogue;
});