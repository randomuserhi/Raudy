// TODO(randomuserhi): Documentation

(function() {
    type context = Docuscript.docuscript.Context;
    type node<T extends keyof Docuscript.docuscript.NodeMap | undefined = undefined> = Docuscript.docuscript.Node<T>;
    let defaultParser: Docuscript.docuscript.Parser = {
        text: {
            create: function(text) {
                return {
                    __type__: "text",
                    text: text,
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
            parse: function(children) {
                let dom = document.createElement("br");
                dom.append(...children);
                return dom;
            }
        },
        p: {
            create: function(this: context, ...children) {
                let node: node<"p"> = {
                    __type__: "p",
                };

                for (let child of children) {
                    let childNode: node;
                    if (typeof child === "string") {
                        childNode = this.nodes.text(child);
                    } else {
                        childNode = child;
                    }
                    
                    this.remount(childNode, node);
                }

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("p");
                dom.append(...children);
                return dom;
            }
        },
        h: {
            create: function(this: context, heading, ...children) {
                let node: node<"h"> = {
                    __type__: "h",
                    heading: heading,
                };
                
                for (let child of children) {
                    let childNode: node;
                    if (typeof child === "string") {
                        childNode = this.nodes.text(child);
                    } else {
                        childNode = child;
                    }
                    
                    this.remount(childNode, node);
                }

                return node;
            },
            parse: function(children, node) {
                let dom = document.createElement(`h${node.heading}`);
                dom.append(...children);
                return dom;
            }
        },
        block: {
            create: function(this: context, ...children) {
                let node: node<"block"> = {
                    __type__: "block",
                };
                
                for (let child of children) {
                    let childNode: node;
                    if (typeof child === "string") {
                        childNode = this.nodes.p(child);
                    } else {
                        childNode = child;
                    }
                    
                    this.remount(childNode, node);
                }

                return node;
            },
            parse: function(children) {
                let dom = document.createElement("div");
                dom.append(...children);
                return dom;
            }
        },
    };

    let docuscript = window.docuscript = function<T extends string, FuncMap extends Docuscript.NodeFuncMap<T>>(generator: (nodes: Docuscript.ParserNodes<T, FuncMap>) => void, parser: Docuscript.Parser<T, FuncMap> = defaultParser as any): Docuscript.Page<T, FuncMap> {
        return {
            parser,
            generator
        };
    } as Docuscript;

    docuscript.parse = function<T extends string, FuncMap extends Docuscript.NodeFuncMap<T>>(page: Docuscript.Page<T, FuncMap>) {
        let content: Docuscript.Node<any>[] = [];
        
        const nodes: any = {};
        const context: any = {};
        for (const [node, func] of Object.entries(page.parser as Docuscript.Parser<string, Docuscript.NodeFuncMap<string>>)) {
            nodes[node as keyof typeof nodes] = (...args: any[]) => 
                func.create.call(docuscriptContext, ...args);

            context[node as keyof typeof context] = (...args: any[]) => { 
                const node = func.create.call(docuscriptContext, ...args); 
                content.push(node); // auto-mount node
                return node;
            }
        }
        const docuscriptContext: Docuscript.Context<T, Docuscript.NodeFuncMap<T>> = {
            nodes,
            remount: (child, parent) => {
                if (child.__parent__ && child.__parent__.__children__) {
                    child.__parent__.__children__ = child.__parent__.__children__.filter(n => n !== child);
                } else {
                    content = content.filter(n => n !== child);
                }
                child.__parent__ = parent;
                if (parent.__children__) {
                    parent.__children__.push(child);
                } else {
                    parent.__children__ = [child];
                }
            } 
        }
        page.generator(context);

        return content;
    }

    docuscript.render = function<T extends string, FuncMap extends Docuscript.NodeFuncMap<T>>(page: Docuscript.Page<T, FuncMap>, patch?: {
        pre?: (node: Docuscript.Node<T>) => void;
        post?: (node: Docuscript.Node<T>, dom: Node) => void;
    }): [DocumentFragment, () => void] {
        const fragment = new DocumentFragment();
        const parser = page.parser as Docuscript.Parser<string, FuncMap>;
        const destructors: (()=>void)[] = [];
        let content = docuscript.parse(page);

        let stack: globalThis.Node[][] = [];
        let walk = (node: Docuscript.Node<T>) => {
            let wrapper: globalThis.Node[] = [];

            let parent = stack.length === 0 ? undefined : stack[stack.length - 1];

            stack.push(wrapper);

            if (node.__children__) {
                for (let child of node.__children__) {
                    walk(child);
                }
            }

            if (patch && patch.pre) {
                patch.pre(node);
            }
            if (parser[node.__type__].parse === undefined) throw new Error(`No parser exists for node of type: ${node.__type__}.`);
            let result = parser[node.__type__].parse!(wrapper, node as any);
            let data: any = undefined;
            let dom: globalThis.Node;
            if (Array.isArray(result)) {
                dom = result[0];
                data = result[1];
            } else {
                dom = result;
            }
            if (parser[node.__type__].destructor) {
                destructors.push(() => {
                    parser[node.__type__].destructor!(data);
                });
            }
            if (patch && patch.post) {
                patch.post(node, dom);
            }

            if (parent) {
                parent.push(dom);
            } else {
                fragment.append(dom);
            }

            stack.pop();
        };
        for (let node of content) {
            walk(node);
        }

        return [fragment, () => {
            for (const destructor of destructors) {
                destructor();
            }
        }];
    };

    docuscript.defaultParser = defaultParser;
})();