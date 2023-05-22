declare global
{
    namespace RHU
    {

        var WeakRefMap: RHU.WeakRefMapConstructor;

        var WeakCollection: RHU.WeakCollectionConstructor;
    }

    namespace RHU
    {
        interface WeakRefMap<K, V> extends Map<K, V>
        {
            prototype: WeakRefMap<K, V>
        }
        interface WeakRefMapConstructor extends MapConstructor, ReflectConstruct
        {
            new(): WeakRefMap<any, any>,
            new <K, V>(entries?: readonly (readonly [K, V])[] | null): WeakRefMap<K, V>;
            readonly prototype: WeakRefMap<any, any>
        }

        interface WeakCollection<T extends object>
        {
            prototype: WeakCollection<T>,
            add(...items: T[]): void,
            delete(...items: T[]): void
        }
        interface WeakCollectionConstructor extends ReflectConstruct
        {
            new <T extends object = object>(values?: readonly T[] | null): WeakCollection<T>;
            readonly prototype: WeakCollection<object>;
        }
    }
}

export {}