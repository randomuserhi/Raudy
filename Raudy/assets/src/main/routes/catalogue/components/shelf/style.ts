declare namespace RHU {
    interface Modules {
        "routes/catalogue/shelf/style": {
            wrapper: Style.ClassName;
            grid: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/shelf/style",
    { Style: "rhu/style", theme: "main/theme" },
    function({ Style }) {
        const style = Style(({ style }) => {
            const wrapper = style.class`
            `;

            const grid = style.class`
            display: grid;
            `;

            return {
                wrapper,
                grid,
            };
        });

        return style;
    }
);