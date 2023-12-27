declare namespace RHU {
    interface Modules {
        "components/molecules/poster": Macro.Template<"molecules/poster">;
    }

    namespace Macro {
        interface TemplateMap {
            "molecules/poster": Molecules.poster;
        }
    }
}

declare namespace Molecules {
    interface poster extends HTMLDivElement {
    }
}

RHU.module(new Error(), "components/molecules/poster", { 
    Macro: "rhu/macro", style: "components/molecules/poster/style"
}, function({ 
    Macro, style
}) {
    const poster = Macro((() => {
        const poster = function(this: Routes.Catalogue.library) {
        } as RHU.Macro.Constructor<Routes.Catalogue.library>;

        return poster;
    })(), "molecules/poster", //html
    `
        <img />
        `, {
        element: //html
            `<div class="${style.wrapper}"></div>`
    });

    return poster;
});