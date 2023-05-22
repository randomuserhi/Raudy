declare global
{
    interface test extends HTMLUListElement
    {
        item: HTMLLIElement
    }
    interface testConstructor extends Function
    {
        new(): test,
        prototype: test
    }

    namespace RHU { namespace Macro {
        interface TemplateMap
        {
            "test": test
        }      
    }}
}

export {}