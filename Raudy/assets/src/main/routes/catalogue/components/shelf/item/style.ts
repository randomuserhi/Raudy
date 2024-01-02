declare namespace RHU {
    interface Modules {
        "routes/catalogue/shelf/item/style": {
            wrapper: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/shelf/item/style", { 
    Style: "rhu/style", theme: "main/theme" 
}, function({ Style }) {
    const style = Style(({ style }) => {
        const wrapper = style.class`
        width: 100%;
        aspect-ratio: 2/3;
        border-radius: 2px;
        background-color: #000;
        `;

        return {
            wrapper,
        };
    });

    return style;
});