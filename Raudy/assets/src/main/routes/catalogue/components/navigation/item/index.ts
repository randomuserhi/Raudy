declare namespace RHU {
    interface Modules {
        "routes/catalogue/navigation/item": Macro.Template<"routes/catalogue/navigation/item">;
    }

    namespace Macro {
        interface TemplateMap {
            "routes/catalogue/navigation/item": Routes.Catalogue.Navigation.item;
        }
    }
}

declare namespace Routes.Catalogue.Navigation {
    interface item extends HTMLLIElement {
        set(shelf: Raudy.Shelf): void;
        dom: {
            name: HTMLDivElement;
        }
    }
}

RHU.module(new Error(), "routes/catalogue/navigation/item", { 
    Macro: "rhu/macro", style: "routes/catalogue/navigation/item/style"
}, function({ 
    Macro, style
}) {
    const item = Macro((() => {
        const item = function(this: Routes.Catalogue.Navigation.item) {
        } as RHU.Macro.Constructor<Routes.Catalogue.Navigation.item>;

        item.prototype.set = function(shelf) {
            this.dom.name.innerHTML = shelf.name;
        };

        return item;
    })(), "routes/catalogue/navigation/item", //html
    `
        <a rhu-id="name" class="${style.icon}"></a>
        `, {
        element: //html
            `<li class="${style.wrapper}"></li>`,
        encapsulate: "dom"
    });

    return item;
});