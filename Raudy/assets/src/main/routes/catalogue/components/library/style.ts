declare namespace RHU {
    interface Modules {
        "routes/catalogue/library/style": {
            wrapper: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/library/style",
    { Style: "rhu/style", theme: "main/theme" },
    function({ Style }) {
        const style = Style(({ style }) => {
            const wrapper = style.class`
            `;

            return {
                wrapper,
            };
        });

        return style;
    }
);