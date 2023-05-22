declare global
{
    namespace RHU
    {

        function eventTarget(target: any): void;

        function CustomEvent(type: string, detail: any): CustomEvent;
    }
}

export {}