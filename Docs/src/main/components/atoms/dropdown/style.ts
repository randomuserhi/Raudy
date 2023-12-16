declare namespace RHU {
    interface Modules {
        "components/atoms/dropdown/style": {
            wrapper: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "components/atoms/dropdown/style",
    { Style: "rhu/style", theme: "main/theme" },
    function({ Style, theme })
    {
        const style = Style(({ style }) => {
            const wrapper = style.class`
            
            `;
            
            return {
                wrapper
            };
        });

        return style;
    }
);