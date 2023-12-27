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
    shelf: "routes/catalogue/shelf",
}, function({ 
    Macro, style,
    navigation,
    shelf,
}) {
    const catalogue = Macro((() => {
        const catalogue = function(this: Routes.catalogue) {
        } as RHU.Macro.Constructor<Routes.catalogue>;

        return catalogue;
    })(), "routes/catalogue", //html
    `
        ${navigation}
        <div rhu-id="body" class="${style.body}">
            ${shelf}
        </div>
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return catalogue;
});