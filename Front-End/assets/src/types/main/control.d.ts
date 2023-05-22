declare global
{
    interface test extends HTMLUListElement
    {
        item: HTMLLIElement
    }
    interface testConstructor extends RHU.Macro.Constructor<test>
    {
        
    }

    namespace RHU { namespace Macro {
        interface TemplateMap
        {
            "test": test
        }      
    }}
}

export {}