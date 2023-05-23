declare global
{
    interface RHU
    {

        eventTarget?<T extends EventTarget>(target: T): void;
    }

    namespace RHU
    {
        var eventTarget: (<T extends EventTarget>(target: T) => void) | undefined | null;
    }
}

export {}