declare namespace RHU {
    interface Modules {
        "routes/catalogue/navigation/style": {
            wrapper: Style.ClassName;
            extended: Style.ClassName;
            list: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/navigation/style", { 
    Style: "rhu/style", theme: "main/theme" 
}, function({ Style }) {
    const style = Style(({ style }) => {
        const width = "48px";
        const extendedWidth = "200px";
        
        const wrapper = style.class`
        background-color: grey;
        height: 100%;
        width: ${width};
        transition: all 200ms ease;
        `;
        
        const extended = style.class`
        width: ${extendedWidth};
        `;

        const list = style.class`
        display: flex;
        flex-direction: column;
        `;

        return {
            wrapper,
            extended,
            list,
        };
    });

    return style;
});