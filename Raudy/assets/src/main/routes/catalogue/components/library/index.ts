declare namespace RHU {
    interface Modules {
        "routes/catalogue/library": Macro.Template<"routes/catalogue/library">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue/library": Routes.Catalogue.navigation;
        }
    }
}

declare namespace Routes.Catalogue {
    interface library extends HTMLDivElement {
    }
}

RHU.module(new Error(), "routes/catalogue/library", { 
    Macro: "rhu/macro", style: "routes/catalogue/library/style"
}, function({ 
    Macro, style
}) {
    const library = Macro((() => {
        const library = function(this: Routes.Catalogue.library) {
        } as RHU.Macro.Constructor<Routes.Catalogue.library>;

        return library;
    })(), "routes/catalogue/library", //html
    `
        <!-- title -->
        <div>Library</div>
        <div>
            <!-- search -->
            <div></div>
            <!-- filters TODO(randomuserhi): Add option to search across all categories -->
            <div></div>
        </div>
        <!-- library categories -->
        <div>
        </div>
        <!-- results -->
        <div class="${style.grid}">
            <div></div>
        </div>
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return library;
});