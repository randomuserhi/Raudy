// TODO(randomuserhi): documentation
// Types used for distribution

declare global
{
    // TODO(randomuserhi): I should implement the type as an interface instead of a namespace.
    //                     Using an interface allows for `readonly` keyword etc...
    //                     but means I need to declare a global variable RHU:
    //                     
    //                     var RHU: RHU;
    //                     interface RHU { ... }
    //                     namespace RHU { ... }

    namespace RHU
    {
        interface Config
        {

            readonly root: string,

            readonly extensions: string[],

            readonly modules: string[],

            readonly includes: Record<string, string>
        }

        namespace Properties
        {
            export interface Options
            {
                enumerable?: boolean,
                configurable?: boolean,
                symbols?: boolean,
                hasOwn?: boolean,
                writable?: boolean,
                get?: boolean,
                set?: boolean
            }

            export interface Flags
            {
                replace?: boolean,
                warn?: boolean,
                err?: boolean
            }
        }

        namespace Module
        {
            enum Type
            {
                Module = "module",
                Extension = "x-module"
            }
        }
        
        export interface ReflectConstruct extends Function
        {
            __reflect__(newTarget: unknown, args: any[]): unknown;
            __constructor__: Function;
            __args__(...args: any[]): any[];
        }

        export interface Dependencies
        {
            hard?: string[];
            soft?: string[];
            trace?: Error;
        }

        export interface ResolvedDependency
        {
            has: string[],
            missing: string[]
        }

        export interface ResolvedDependencies
        {
            hard: ResolvedDependency, 
            soft: ResolvedDependency,
            trace: Error
        }

        export interface Module extends Dependencies
        {
            name?: string;
            callback?: (result: RHU.ResolvedDependencies) => void;
        }

        var version: string;

        enum ReadyState 
        {
            Loading = "loading",
            Complete = "complete"
        }

        var readyState: ReadyState;
        var config: RHU.Config;

        var imports: RHU.Module[];

        function addEventListener(type: string, listener: (any) => void, options?: boolean | EventListenerOptions): void;

        function removeEventListener(type: string, callback: EventListenerOrEventListenerObject, options?: EventListenerOptions | boolean): void;

        function dispatchEvent(event: Event): boolean;

        function isMobile(): boolean;

        function exists(object: any): boolean;

        function parseOptions<T>(template: T, options: any): T;

        function properties(object: any, options: RHU.Properties.Options, operation?: (object: any, property: PropertyKey) => void): Set<PropertyKey>;

        function defineProperty(object: any, property: PropertyKey, options: PropertyDescriptor, flags?: RHU.Properties.Flags): boolean;

        function definePublicProperty(object: any, property: PropertyKey, options: PropertyDescriptor, flags?: RHU.Properties.Flags): boolean;
        
        function definePublicAccessor(object: any, property: PropertyKey, options: PropertyDescriptor, flags?: RHU.Properties.Flags): boolean;

        function defineProperties(object: any, properties: { [x: PropertyKey]: PropertyDescriptor }, flags?: RHU.Properties.Flags): void;
        
        function definePublicProperties(object: any, properties: { [x: PropertyKey]: PropertyDescriptor }, flags?: RHU.Properties.Flags): void;

        function definePublicAccessors(object: any, properties: { [x: PropertyKey]: PropertyDescriptor }, flags?: RHU.Properties.Flags): void;

        function assign<T>(target: T, source: any, options?: RHU.Properties.Flags): T;
        
        function deleteProperties(object: any, preserve: {}): void;

        function clone<T extends object>(object: object, prototype: T) : T;
        function clone<T extends object>(object: T) : T;

        function isConstructor(object: any): boolean;

        function inherit(child: Function, base: Function): void;

        function reflectConstruct(base: Function, name: string, constructor: Function, argnames?: string[]): RHU.ReflectConstruct;

        function clearAttributes(element: HTMLElement): void;

        function getElementById(id: string, clearID: boolean): HTMLElement;

        function module(dependencies: RHU.Module, callback: (result?: RHU.ResolvedDependencies) => void): void;
    }
}

export {}