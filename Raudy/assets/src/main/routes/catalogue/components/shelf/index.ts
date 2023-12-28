declare namespace RHU {
    interface Modules {
        "routes/catalogue/shelf": Macro.Template<"routes/catalogue/shelf">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue/shelf": Routes.Catalogue.shelf;
        }
    }
}

declare namespace Routes.Catalogue {
    interface shelf extends HTMLDivElement {
    }
}

RHU.module(new Error(), "routes/catalogue/shelf", { 
    Macro: "rhu/macro", style: "routes/catalogue/shelf/style",
    item: "routes/catalogue/shelf/item"
}, function({ 
    Macro, style,
    item
}) {
    const library = Macro((() => {
        const library = function(this: Routes.Catalogue.library) {
        } as RHU.Macro.Constructor<Routes.Catalogue.library>;

        return library;
    })(), "routes/catalogue/shelf", //html
    `
        <!-- title -->
        <div>Shelf</div>
        <!-- results -->
        <!-- NOTE(randomuserhi): Maybe convert grid to a global-component as "shelf" + "library" use this grid sub-component --> 
        <div class="${style.grid}">
            ${item}
            ${item}
            ${item}
            ${item}
            ${item}
        </div>
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return library;
});