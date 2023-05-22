declare global
{
    namespace RHU
    {
        var Macro: Macro

        interface Macro
        {

            (constructor: Function, type: string, source: string, options: RHU.Macro.Options): void,
            
            parseDomString(str: string): DocumentFragment,
            
            parse(element: Element, type?: string, force?: boolean): void,

            observe(target: Node): void
        }

        namespace Macro
        {
            interface TemplateMap
            {
                
            }

            interface Constructor<T extends Element = Element>
            {
                (this: T): void;
                prototype: T;
            }

            interface Options
            {

                element?: string,

                floating?: boolean,

                strict?: boolean,

                encapsulate?: PropertyKey,
                
                content?: PropertyKey
            }
        }
    }

    interface Document
    {
        
        createMacro<T extends keyof RHU.Macro.TemplateMap>(type: T): RHU.Macro.TemplateMap[T],
        
        Macro(type: string, attributes: Record<string, string>): string
    }

    interface Element
    {

        rhuMacro: string
    }
}

export {}