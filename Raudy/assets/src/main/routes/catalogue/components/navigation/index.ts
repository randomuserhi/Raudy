declare namespace RHU {
    interface Modules {
        "routes/catalogue/navigation": Macro.Template<"routes/catalogue/navigation">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue/navigation": Routes.Catalogue.navigation;
        }
    }
}

declare namespace Routes.Catalogue {
    interface navigation extends HTMLDivElement {
        append(): void; // TODO(randomuserhi)
    }
}

RHU.module(new Error(), "routes/catalogue/navigation", { 
    Macro: "rhu/macro", style: "routes/catalogue/navigation/style",
    item: "routes/catalogue/navigation/item"
}, function({ 
    Macro, style,
    item
}) {
    const navigation = Macro((() => {
        const navigation = function(this: Routes.Catalogue.navigation) {
        } as RHU.Macro.Constructor<Routes.Catalogue.navigation>;

        return navigation;
    })(), "routes/catalogue/navigation", //html
    `
        <ul class="${style.list}">
            ${item}
        </ul>
        `, {
        element: //html
            `<div class="${style.wrapper} ${style.extended}"></div>`
    });

    return navigation;
});