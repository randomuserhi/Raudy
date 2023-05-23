declare global
{
    interface RHU
    {

        Macro?: RHU.Macro;
    }

    namespace RHU
    {
        var Macro: RHU.Macro | undefined | null;

        interface Macro
        {
            
            (constructor: Function, type: string, source: string, options: RHU.Macro.Options): void;
            
            parseDomString(str: string): DocumentFragment;
            
            parse(element: Element, type?: string | undefined | null, force?: boolean): void;

            observe(target: Node): void;
        }

        namespace Macro
        {
            interface Options
            {

                element?: string;

                floating?: boolean;

                strict?: boolean;

                encapsulate?: PropertyKey;
                
                content?: PropertyKey;
            }

            interface Constructor<T extends Element = Element>
            {
                (this: T): void;
                prototype: T;
            }

            interface TemplateMap
            {

            }
        }
    }

    interface Document
    {
        
        createMacro<T extends keyof RHU.Macro.TemplateMap>(type: T): RHU.Macro.TemplateMap[T];
        
        Macro(type: string, attributes: Record<string, string>): string;
    }

    interface Element
    {

        rhuMacro: string;
    }
}

export {}