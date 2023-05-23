declare global
{
    interface RHU
    {

        WeakRefMap?: RHU.WeakRefMapConstructor;

        WeakCollection?: RHU.WeakCollectionConstructor;
    }

    namespace RHU
    {
        var WeakRefMap: RHU.WeakRefMapConstructor | undefined | null;
        var WeakCollection: RHU.WeakCollectionConstructor | undefined | null;

        interface WeakRefMap<K, V> extends Map<K, V>
        {
            prototype: WeakRefMap<K, V>;
        }
        interface WeakRefMapConstructor extends ReflectConstruct<MapConstructor, WeakRefMapConstructor>
        {
            new(): WeakRefMap<any, any>;
            new <K, V>(entries?: readonly (readonly [K, V])[] | null): WeakRefMap<K, V>;
            readonly prototype: WeakRefMap<any, any>;
        }

        interface WeakCollection<T extends object> extends WeakSet<T>
        {
            prototype: WeakCollection<T>;
            add(item: T): this;
            delete(item: T): boolean;
            add(...items: T[]): void;
            delete(...items: T[]): void;
            [Symbol.iterator](): IterableIterator<T>;
        }
        interface WeakCollectionConstructor extends ReflectConstruct<WeakSetConstructor, WeakCollectionConstructor>
        {
            new <T extends object = object>(values?: readonly T[] | null): WeakCollection<T>;
            readonly prototype: WeakCollection<object>;
        }
    }
}

export {}