declare namespace RHU {
    interface Modules {
        "docs/indices": {
            DOCUSCRIPT_ROOT: string;
        };
    }
}

(() => {
    let DOCUSCRIPT_ROOT = "";
    if (document.currentScript) {
        let s = document.currentScript as HTMLScriptElement;
        let r = s.src.match(/(.*)[/\\]/);
        if (r)
            DOCUSCRIPT_ROOT = r[1] || "";
    } else {
        throw new Error("Failed to get document root.");
    }

    RHU.module(new Error(), "docs/indices", { 
        docs: "docs",
    }, function({
        docs,
    }) {
        
        ((docs: Docs) => {
            const stack: string[] = [];
            const dir = (dir: string, func: (docs: (path: string, page?: string, index?: number) => string) => void) => {
                stack.push(dir);
                const current = [...stack];
                let prio = 0;
                const d = (path: string, page?: string) => {
                    docs.set(`${[...current, ...path.split("/")].join("/")}`, page, prio++);
                    return path;
                };
                func(d);
                stack.pop();
            };
            let prio = 0;
            const set = (path: string, page?: string) => {
                docs.set(path, page, prio++);
                return path;
            };

            set("About", "About.js");
            /*dir(set("Deep", "Docs/Deep.js"), (set) => {
                dir(set("Net", "Docs/Deep/Net.js"), (set) => {
                    set("UDPServer", "Docs/Deep/Net/UDPServer.js");
                    set("UDPClient", "Docs/Deep/Net/UDPClient.js");
                    set("TCPServer", "Docs/Deep/Net/TCPServer.js");
                    set("TCPClient", "Docs/Deep/Net/TCPClient.js");
                });
            });*/
        })(docs.create("1.0.0", "About"));

        return {
            DOCUSCRIPT_ROOT
        };
    });
})();