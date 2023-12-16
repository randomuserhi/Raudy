RHU.require(new Error(), { 
    docs: "docs", rhuDocuscript: "docuscript",
}, function({
    docs, rhuDocuscript,
}) {
    docs.jit = (version, path) => docuscript<RHUDocuscript.Language, RHUDocuscript.FuncMap>(({
        h, p, frag, br, link, img
    }) => {
        p(
            "This is the Docuscript document for Raudy.",
        );
    }, rhuDocuscript);
});