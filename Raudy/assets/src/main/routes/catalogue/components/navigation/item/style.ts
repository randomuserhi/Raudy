declare namespace RHU {
    interface Modules {
        "routes/catalogue/navigation/item/style": {
            wrapper: Style.ClassName;
            icon: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/navigation/item/style", { 
    Style: "rhu/style", theme: "main/theme",
    nav: "routes/catalogue/navigation/style",
}, function({ Style, nav }) {
    const style = Style(({ style }) => {
        const height = "48px";
        const extendedHeight = "30px";
        
        const wrapper = style.class`
        width: 100%;
        height: ${height};
        cursor: pointer;
        transition: all 200ms ease;
        `;
        style`
        ${nav.extended} ${wrapper} {
            height: ${extendedHeight};
        }
        `;

        const icon = style.class`
        background-color: black;
        display: block;
        width: 100%;
        height: 100%;
        transition: background-color 200ms ease;
        `;
        style`
        ${icon}:hover {
            background-color: white;
        }
        `;

        return {
            wrapper,
            icon,
        };
    });

    return style;
});