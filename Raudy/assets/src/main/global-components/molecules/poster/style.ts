declare namespace RHU {
    interface Modules {
        "components/molecules/poster/style": {
            wrapper: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "components/molecules/poster/style",
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