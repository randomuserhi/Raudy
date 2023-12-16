interface Docuscript {
    (generator: (nodes: Docuscript.ParserNodes<Docuscript.docuscript.Language, Docuscript.docuscript.FuncMap>) => void): Docuscript.docuscript.Page;
    <T extends string, FuncMap extends Docuscript.NodeFuncMap<T>>(generator: (nodes: Docuscript.ParserNodes<T, FuncMap>) => void, parser: Docuscript.Parser<T, FuncMap>): Docuscript.Page<T, FuncMap>;
    parse(page: Docuscript.Page<any, any>): Docuscript.Node<any>[];
    defaultParser: Docuscript.docuscript.Parser;
    render(page: Docuscript.Page<any, any>): [DocumentFragment, () => void];
    render<T extends string, FuncMap extends Docuscript.NodeFuncMap<T>>(page: Docuscript.Page<T, FuncMap>, 
        patch?: { 
            pre?: (node: Docuscript.NodeDef<FuncMap, undefined>) => void;
            post?: (node: Docuscript.NodeDef<FuncMap, undefined>, dom: Node) => void;
        }): [DocumentFragment, () => void];
}

declare var docuscript: Docuscript;
interface Window {
    docuscript: Docuscript;
}

declare namespace Docuscript {
    type AnyNode = {  
        __type__: PropertyKey,
        __children__?: AnyNode[],
        __parent__?: AnyNode,
        __destructor__?: any,
        [x: string]: any,
    };
    type NodeFuncMap<T extends string> = { [K in T]: (...args: any[]) => any; };
    interface NodeDefinition<T extends (...args: any[]) => any = (...args: any[]) => any> {
        create: T;
        parse?: (node: AnyNode) => globalThis.Node;
    }
    type ToNodeMap<T extends { [k in string]: (...args: any[]) => any }> = {
        [K in keyof T]: NodeDefinition<T[K]>;
    };

    interface Context<T extends string, FuncMap extends NodeFuncMap<T>> {
        nodes: {
            [P in keyof NodeFuncMap<T>]: ToNodeMap<FuncMap>[P]["create"];
        };
        remount: (child: Node<T>, parent: Node<T>) => void;
    }

    type Parser<T extends string, FuncMap extends NodeFuncMap<T>> = {
        [P in T]: {
            create: ToNodeMap<FuncMap>[P]["create"];
            parse?: (children: globalThis.Node[], node: ReturnType<ToNodeMap<FuncMap>[P]["create"]>) => globalThis.Node | [globalThis.Node, ReturnType<ToNodeMap<FuncMap>[P]["create"]>["__destructor__"]];
            destructor?: (data: ReturnType<ToNodeMap<FuncMap>[P]["create"]>["__destructor__"]) => void;
        }
    };
    type ParserNodes<T extends string, FuncMap extends NodeFuncMap<T>> = {
        [P in T]: ToNodeMap<FuncMap>[P]["create"];
    }

    interface Page<T extends string, FuncMap extends NodeFuncMap<T>> {
        parser: Parser<T, FuncMap>;
        generator: (nodes: Docuscript.ParserNodes<T, FuncMap>) => void;
    }

    interface Node<T> {
        __type__: T;
        __children__?: Node<T>[];
        __parent__?: Node<T>;
        [x: string]: any;
    }

    type NodeDef<NodeMap, T> = Node<T extends keyof NodeMap ? T : keyof NodeMap> & (T extends keyof NodeMap ? NodeMap[T] : {});

    namespace docuscript {
        interface NodeMap {
            text: {
                text: string;
            };
            br: {};
            p: {};
            h: {
                heading: number;
            };
            block: {};
        }
        type Language = keyof NodeMap;

        interface FuncMap extends NodeFuncMap<Language> {
            text: (text: string) => Node<"text">;
            br: () => Node<"br">;
            p: (...children: (string | Node)[]) => Node<"p">;
            
            h: (heading: number, ...children: (string | Node)[]) => Node<"h">;
    
            block: (...children: (string | Node)[]) => Node<"block">;
        }

        type Page = Docuscript.Page<Language, FuncMap>;
        type Parser = Docuscript.Parser<Language, FuncMap>;
        type Context = Docuscript.Context<Language, FuncMap>;
        type Node<T extends Language | undefined = undefined> = Docuscript.NodeDef<NodeMap, T>;
    }
}