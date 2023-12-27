declare namespace RHU {
    interface Modules {
        "routes/catalogue/shelf/item": Macro.Template<"routes/catalogue/shelf/item">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue/shelf/item": Macro.Template<"routes/catalogue/shelf/item">;
        }
    }
}

declare namespace Routes.Catalogue.Shelf {
    interface item extends HTMLDivElement {
    }
}

RHU.module(new Error(), "routes/catalogue/shelf/item", { 
    Macro: "rhu/macro", style: "routes/catalogue/shelf/item/style"
}, function({ 
    Macro, style
}) {
    const poster = Macro((() => {
        const poster = function(this: Routes.Catalogue.library) {
        } as RHU.Macro.Constructor<Routes.Catalogue.library>;

        return poster;
    })(), "routes/catalogue/shelf/item", //html
    `
        <img />
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return poster;
});