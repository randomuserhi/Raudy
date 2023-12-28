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
            padding: 0.5rem;

            /* TODO(randomuserhi): Move to a different class */
            --item-width: 200px;
            `;

            const grid = style.class`
            display: grid;
            padding: 0.5rem;
            grid-gap: 0.5rem;
            grid-template-columns: repeat(auto-fill, var(--item-width)); /* minmax(var(--item-width), 1fr) */
            `;

            return {
                wrapper,
                grid,
            };
        });

        return style;
    }
);