declare namespace RHU {
    interface Modules {
        "routes/catalogue/navigation/style": {
            wrapper: Style.ClassName;
            list: Style.ClassName;
            item: Style.ClassName;
            icon: Style.ClassName;
        };
    }
}

RHU.module(new Error(), "routes/catalogue/navigation/style",
    { Style: "rhu/style", theme: "main/theme" },
    function({ Style }) {
        const style = Style(({ style }) => {
            const wrapper = style.class`
            background-color: grey;
            height: 100%;
            width: 48px;
            `;

            const list = style.class`
            display: flex;
            flex-direction: column;
            `;

            const item = style.class`
            `;
            style`
            ${item} {
                cursor: pointer;
            }
            `;

            const icon = style.class`
            background-color: black;
            display: block;
            width: 48px;
            height: 48px;
            transition: background-color 200ms ease;
            `;
            style`
            ${icon}:hover {
                background-color: white;
            }
            `;

            return {
                wrapper,
                list,
                item,
                icon,
            };
        });

        return style;
    }
);