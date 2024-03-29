declare namespace RHU {
    interface Modules {
        "routes/catalogue/library/style": {
            wrapper: Style.ClassName;
            grid: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/library/style",
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