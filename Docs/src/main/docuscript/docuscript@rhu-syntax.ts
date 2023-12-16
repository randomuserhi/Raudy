declare namespace RHU {
    interface Modules {
        "docuscript": RHUDocuscript.Parser;
    }
}

declare namespace RHUDocuscript {
    interface NodeMap {
        img: {
            src: string;
            width?: string;
        };
        text: {
            text: string;
        };
        br: {};
        p: {};
        h: {
            heading: number;
            label: string;
            link?: string;
            onclick?: () => void;
        };
        div: {};
        frag: {};
        pl: {
            path: string;
            index?: number;
            link?: string;
            onclick?: () => void;
        };
        link: {
            href: string;
        };
        code: {
            language?: string;
        };
        icode: {
            language?: string;  
        };
        mj: {};
        ol: {};
        ul: {};
        desmos: {
            src: string;
        };
        i: {};
        b: {};
        table: {
            widths?: string[];
        };
        tr: {};
        td: {};
        t: never;
        ot: never;
        center: {};
    }
    type Language = keyof NodeMap;

    interface FuncMap extends Docuscript.NodeFuncMap<Language> {
        img: (src: string, width?: string) => Node<"img">;
        text: (text: string) => Node<"text">;
        br: () => Node<"br">;
        i: (...children: (string | Node)[]) => Node<"i">;
        b: (...children: (string | Node)[]) => Node<"b">;
        p: (...children: (string | Node)[]) => Node<"p">;
        
        h: (heading: number, label: string, ...children: (string | Node)[]) => Node<"h">;
    
        div: (...children: (string | Node)[]) => Node<"div">;
        frag: (...children: (string | Node)[]) => Node<"frag">;

        pl: (params: [path: string, index?: number], ...children: (string | Node)[]) => Node<"pl">;
        link: (href: string, ...children: (string | Node)[]) => Node<"link">;

        mj: (...children: (string | Node)[]) => Node<"mj">;

        ol: (...children: (string | Node)[]) => Node<"ol">;
        ul: (...children: (string | Node)[]) => Node<"ul">;

        code: (params: [language?: string], ...content: (string)[]) => Node<"code">;
        icode: (params: [language?: string], ...content: (string)[]) => Node<"icode">;

        ot: <T>( options: { 
            widths?: string[],
            headings?: string[]
        }, headings: (string | ((i: T) => any))[], ...objects: T[]) => Node<"table">;
        t: (widths: string[] | undefined, ...content: (string | Node)[][]) => Node<"table">;
        table: (widths: string[] | undefined, ...content: (string | Node<"tr">)[]) => Node<"table">;
        tr: (...content: (string | Node<"td">)[]) => Node<"tr">;
        td: (...content: (string | Node)[]) => Node<"td">;

        desmos: (src: string) => Node<"desmos">;

        center: (...content: (string | Node)[]) => Node<"center">;
    }

    type Page = Docuscript.Page<Language, FuncMap>;
    type Parser = Docuscript.Parser<Language, FuncMap>;
    type Context = Docuscript.Context<Language, FuncMap>;
    type Node<T extends Language | undefined = undefined> = Docuscript.NodeDef<NodeMap, T>;
}

RHU.module(new Error(), "docuscript", {
    codeblock: "docuscript/components/molecules/codeblock",
    style: "docuscript/style"
}, function({
    codeblock, style
}) {
    type context = RHUDocuscript.Context;
    type node<T extends RHUDocuscript.Language | undefined = undefined> = RHUDocuscript.Node<T>;

    const mountChildren = (context: context, node: node, children: (string | node)[], conversion: (text: string) => node) => {
        for (let child of children) {
            let childNode: node;
            if (typeof child === "string") {
                childNode = conversion(child);
            } else {
                childNode = child;
            }
            
            context.remount(childNode, node);
        }
    };
    const mountChildrenText = (context: context, node: node, children: (string | node)[]) => {
        mountChildren(context, node, children, (text) => context.nodes.text(text));
    }
    const mountChildrenP = (context: context, node: node, children: (string | node)[]) => {
        mountChildren(context, node, children, (text) => context.nodes.p(text));
    }

    return {
        center: {
            create: function(this: context, ...children) {
                let node: node<"center"> = {
                    __type__: "center"
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("div");
                dom.classList.toggle(`${style.center}`, true);
                dom.append(...children);
                return dom;
            }
        },
        ot: {
            create: function<T>(this: context, options: { 
                widths?: string[],
                headings?: string[],
                default?: string
            }, headings: (string | ((i: T) => any))[], ...objects: T[]): node<"table"> {
                let node: node<"table"> = {
                    __type__: "table",
                    widths: options.widths
                };

                const { td, tr, b, i } = this.nodes;
                if (options.headings) {
                    this.remount(tr(...options.headings.map(h => td(b(i(h))))), node);
                }
                for (const obj of objects) {
                    this.remount(tr(...headings.map(h => {
                        if (typeof h === "string") {
                            return td((obj as any)[h] === undefined ? options.default ? options.default : (obj as any)[h] : (obj as any)[h]);
                        } else {
                            return td(h(obj));
                        }
                    })), node);
                }

                return node;
            },
        },
        t: {
            create: function(this: context, widths, ...content) {
                let node: node<"table"> = {
                    __type__: "table",
                    widths
                };

                const { td, tr } = this.nodes;
                for (const row of content) {
                    this.remount(tr(...row.map(r => td(r))), node);
                }

                return node;
            },
        },
        table: {
            create: function(this: context, widths, ...children) {
                let node: node<"table"> = {
                    __type__: "table",
                    widths
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children, node) {
                for (const row of children) {
                    if (node.widths) {
                        for (let i = 0; i < node.widths.length && i < row.childNodes.length; ++i) {
                            (row.childNodes[i] as HTMLElement).style.width = node.widths[i];
                        }
                    }
                }

                let wrapper = document.createElement("table");
                if (node.widths) {
                    wrapper.classList.toggle(`${style.block}`, true);
                }
                let dom = document.createElement("tbody");
                dom.append(...children);
                wrapper.append(dom);
                return wrapper;
            }
        },
        tr: {
            create: function(this: context, ...children) {
                let node: node<"tr"> = {
                    __type__: "tr"
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("tr");
                dom.append(...children);
                return dom;
            }
        },
        td: {
            create: function(this: context, ...children) {
                let node: node<"td"> = {
                    __type__: "td"
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("td");
                dom.append(...children);
                return dom;
            }
        },
        i: {
            create: function(this: context, ...children) {
                let node: node<"i"> = {
                    __type__: "i",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("i");
                dom.append(...children);
                return dom;
            }
        },
        b: {
            create: function(this: context, ...children) {
                let node: node<"b"> = {
                    __type__: "b",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("b");
                dom.append(...children);
                return dom;
            }
        },
        desmos: {
            create: function(this: context, src) {
                let node: node<"desmos"> = {
                    __type__: "desmos",
                    src
                }
                return node;
            },
            parse: function(_, node) {
                const dom = document.createElement("iframe");
                dom.classList.toggle(`${style.desmos}`, true);
                dom.src=`https://www.desmos.com/${node.src}?embed`;
                return dom;
            }
        },
        ul: {
            create: function(this: context, ...children) {
                let node: node<"ul"> = {
                    __type__: "ul",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                const dom = document.createElement("ul");
                dom.classList.toggle(`${style.block}`, true);
                for (const child of children) {
                    const li = document.createElement("li");
                    li.classList.toggle(`${style.block}`, true);
                    const wrapper = document.createElement("div");
                    wrapper.classList.toggle(`${style.block}`, true);
                    wrapper.append(child);
                    li.append(wrapper);
                    dom.append(li);
                }
                return dom;
            }
        },
        ol: {
            create: function(this: context, ...children) {
                let node: node<"ol"> = {
                    __type__: "ol",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                const dom = document.createElement("ol");
                dom.classList.toggle(`${style.block}`, true);
                for (const child of children) {
                    const li = document.createElement("li");
                    li.classList.toggle(`${style.block}`, true);
                    const wrapper = document.createElement("div");
                    wrapper.classList.toggle(`${style.block}`, true);
                    wrapper.append(child);
                    li.append(wrapper);
                    dom.append(li);
                }
                return dom;
            }
        },
        mj: {
            create: function(this: context, ...children) {
                let node: node<"mj"> = {
                    __type__: "mj",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                const dom = document.createElement("span");
                dom.append(...children);
                MathJax.Hub.Queue(["Typeset", MathJax.Hub, dom]);
                return dom;
            }
        },
        link: {
            create: function(this: context, href, ...children) {
                let node: node<"link"> = {
                    __type__: "link",
                    href,
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children, node) {
                const dom = document.createElement("a");
                dom.target = "blank";
                dom.href = node.href;
                dom.append(...children);
                return dom;
            }
        },
        icode: {
            create: function(this: context, [language], ...children) {
                let node: node<"icode"> = {
                    __type__: "icode",
                    language,
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children, node) {
                const dom = document.createElement("span");
                dom.classList.toggle(`${style.inlineCode}`, true);
                dom.append(...children);
                if (node.language) {
                    dom.classList.toggle(node.language, true);
                } else {
                    dom.classList.toggle("language-plaintext", true);
                }
                hljs.highlightElement(dom);
                return dom;
            },
        },
        code: {
            create: function(this: context, [language], ...children) {
                let node: node<"code"> = {
                    __type__: "code",
                    language,
                };

                this.remount(this.nodes.text(children.join("\n")), node);

                return node;
            },
            parse: function(children, node) {
                const dom = document.createMacro(codeblock);
                dom.classList.toggle(`${style.block}`, true);
                dom.append(...children);
                dom.setLanguage(node.language);
                return dom;
            },
        },
        pl: {
            create: function(this: context, [path, index], ...children) {
                let node: node<"pl"> = {
                    __type__: "pl",
                    path,
                    index,
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children, node) {
                const pl = node as node<"pl">;
                const dom = document.createElement(`a`);
                dom.style.textDecoration = "inherit"; // TODO(randomuserhi): style properly with :hover { text-decoration: underline; }
                if (pl.link) {
                    dom.href = pl.link;
                    dom.addEventListener("click", (e) => {  
                        e.preventDefault();
                        if (pl.onclick) {
                            pl.onclick(); 
                        }
                    });
                }
                dom.append(...children);
                return dom;
            }
        },
        img: {
            create: function(src, width) {
                return {
                    __type__: "img",
                    src,
                    width
                }
            },
            parse: function(_, node) {
                let img = document.createElement("img");
                img.src = node.src;
                if (node.width) {
                    img.style.width = node.width;
                }
                return img;
            }
        },
        text: {
            create: function(text) {
                return {
                    __type__: "text",
                    text: text.toString(),
                };
            },
            parse: function(_, node) {
                return document.createTextNode(node.text);
            }
        },
        br: {
            create: function() {
                return {
                    __type__: "br",
                };
            },
            parse: function() {
                let dom = document.createElement("br");
                return dom;
            }
        },
        p: {
            create: function(this: context, ...children) {
                let node: node<"p"> = {
                    __type__: "p",
                };

                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("p");
                dom.classList.toggle(`${style.block}`, true);
                dom.append(...children);
                return dom;
            }
        },
        h: {
            create: function(this: context, heading, label, ...children) {
                let node: node<"h"> = {
                    __type__: "h",
                    heading,
                    label,
                };

                if (children.length === 0) {
                    this.remount(this.nodes.text(label), node);
                } else {
                    mountChildrenText(this, node, children);
                }

                return node;
            },
            parse: function(children, node) {
                const h = node as node<"h">;
                const dom = document.createElement(`h${h.heading}`);
                dom.style.display = "flex";
                dom.style.gap = "8px";
                dom.style.alignItems = "center";
                dom.classList.toggle(`${style.block}`, true);
                if (h.link) {
                    const wrapper = document.createElement("div");
                    wrapper.style.alignSelf = "stretch";
                    wrapper.style.flexShrink = "0";
                    wrapper.style.paddingTop = "0.8rem";
                    wrapper.style.display = "flex";
                    const link = document.createElement("a");
                    link.href = h.link;
                    link.innerHTML = "";
                    link.style.fontFamily = "docons";
                    link.style.fontSize = "1rem";
                    link.style.textDecoration = "inherit";
                    link.style.color = "inherit";
                    link.addEventListener("click", (e) => {  
                        e.preventDefault();
                        if (h.onclick) {
                            h.onclick(); 
                        }
                    });
                    wrapper.append(link);
                    dom.append(wrapper);
                }
                dom.append(...children);
                return dom;
            }
        },
        div: {
            create: function(this: context, ...children) {
                let node: node<"div"> = {
                    __type__: "div",
                };
                
                mountChildrenP(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("div");
                dom.classList.toggle(`${style.block}`, true);
                dom.append(...children);
                return dom;
            }
        },
        frag: {
            create: function (this: context, ...children) {
                let node: node<"frag"> = {
                    __type__: "frag",
                };
                
                mountChildrenText(this, node, children);

                return node;
            },
            parse: function(children) {
                let dom = new DocumentFragment();
                dom.append(...children);
                return dom;
            },
        },
    };
});