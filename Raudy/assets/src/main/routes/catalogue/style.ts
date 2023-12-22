declare namespace RHU {
    interface Modules {
        "routes/catalogue/style": {
            wrapper: Style.ClassName;
            body: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/style",
    { Style: "rhu/style", theme: "main/theme" },
    function({ Style }) {
        const style = Style(({ style }) => {
            const wrapper = style.class`
            width: 100%;
            height: 100%;
            display: flex;
            flex-direction: row;
            `;

            const body = style.class`
            flex: 1;
            `;

            return {
                wrapper,
                body,
            };
        });

        return style;
    }
);