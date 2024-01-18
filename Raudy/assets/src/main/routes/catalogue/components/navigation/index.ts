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
        items: Raudy.Shelf[];
        dom: {
            list: HTMLUListElement;
        }
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
        const render = function(el: Routes.Catalogue.navigation) {
            el.dom.list.replaceChildren(...el.items.map(shelf => {
                const i = document.createMacro(item);
                i.set(shelf);
                return i;
            }));
        };

        const navigation = function(this: Routes.Catalogue.navigation) {
            this.items = []; //Raudy.GET("shelf");
            render(this);
        } as RHU.Macro.Constructor<Routes.Catalogue.navigation>;

        return navigation;
    })(), "routes/catalogue/navigation", //html
    `
        <ul rhu-id="list" class="${style.list}"></ul>
        `, {
        element: //html
            `<div class="${style.wrapper} ${style.extended}"></div>`,
        encapsulate: "dom"
    });

    return navigation;
});