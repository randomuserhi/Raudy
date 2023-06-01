"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.core = void 0;
let isEventListener = function (callback) {
    return callback instanceof Function;
};
exports.core = {
    version: "1.0.0",
    exists: function (obj) {
        return obj !== null && obj !== undefined;
    },
    parseOptions: function (template, options) {
        if (!exports.core.exists(options))
            return template;
        if (!exports.core.exists(template))
            return template;
        let result = template;
        Object.assign(result, options);
        return result;
    },
    properties: function (object, options = {}, operation) {
        if (!exports.core.exists(object))
            throw TypeError("Cannot get properties of 'null' or 'undefined'.");
        let opt = {
            enumerable: undefined,
            configurable: undefined,
            symbols: undefined,
            hasOwn: undefined,
            writable: undefined,
            get: undefined,
            set: undefined
        };
        exports.core.parseOptions(opt, options);
        let properties = new Set();
        let iterate = function (props, descriptors) {
            for (let p of props) {
                let descriptor = descriptors[p];
                let valid = true;
                if (opt.enumerable && descriptor.enumerable !== opt.enumerable)
                    valid = false;
                if (opt.configurable && descriptor.configurable !== opt.configurable)
                    valid = false;
                if (opt.writable && descriptor.writable !== opt.writable)
                    valid = false;
                if (opt.get === false && descriptor.get)
                    valid = false;
                else if (opt.get === true && !descriptor.get)
                    valid = false;
                if (opt.set === false && descriptor.set)
                    valid = false;
                else if (opt.set === true && !descriptor.set)
                    valid = false;
                if (valid) {
                    if (!properties.has(p)) {
                        if (exports.core.exists(operation))
                            operation(curr, p);
                        properties.add(p);
                    }
                }
            }
        };
        let curr = object;
        do {
            let descriptors = Object.getOwnPropertyDescriptors(curr);
            if (!exports.core.exists(opt.symbols) || opt.symbols === false) {
                let props = Object.getOwnPropertyNames(curr);
                iterate(props, descriptors);
            }
            if (!exports.core.exists(opt.symbols) || opt.symbols === true) {
                let props = Object.getOwnPropertySymbols(curr);
                iterate(props, descriptors);
            }
        } while ((curr = Object.getPrototypeOf(curr)) && !opt.hasOwn);
        return properties;
    },
    defineProperty: function (object, property, options, flags) {
        let opt = {
            replace: true,
            warn: false,
            err: false
        };
        exports.core.parseOptions(opt, flags);
        if (opt.replace || !exports.core.properties(object, { hasOwn: true }).has(property)) {
            delete object[property];
            Object.defineProperty(object, property, options);
            return true;
        }
        if (opt.warn)
            console.warn(`Failed to define property '${property.toString()}', it already exists. Try 'replace: true'`);
        if (opt.err)
            console.error(`Failed to define property '${property.toString()}', it already exists. Try 'replace: true'`);
        return false;
    },
    definePublicProperty: function (object, property, options, flags) {
        let opt = {
            writable: true,
            enumerable: true
        };
        return exports.core.defineProperty(object, property, Object.assign(opt, options), flags);
    },
    definePublicAccessor: function (object, property, options, flags) {
        let opt = {
            configurable: true,
            enumerable: true
        };
        return exports.core.defineProperty(object, property, Object.assign(opt, options), flags);
    },
    defineProperties: function (object, properties, flags) {
        for (let key of exports.core.properties(properties, { hasOwn: true }).keys()) {
            if (Object.hasOwnProperty.call(properties, key)) {
                exports.core.defineProperty(object, key, properties[key], flags);
            }
        }
    },
    definePublicProperties: function (object, properties, flags) {
        let opt = function () {
            this.configurable = true;
            this.writable = true;
            this.enumerable = true;
        };
        for (let key of exports.core.properties(properties, { hasOwn: true }).keys()) {
            if (Object.hasOwnProperty.call(properties, key)) {
                let o = Object.assign(new opt(), properties[key]);
                exports.core.defineProperty(object, key, o, flags);
            }
        }
    },
    definePublicAccessors: function (object, properties, flags) {
        let opt = function () {
            this.configurable = true;
            this.enumerable = true;
        };
        for (let key of exports.core.properties(properties, { hasOwn: true }).keys()) {
            if (Object.hasOwnProperty.call(properties, key)) {
                let o = Object.assign(new opt(), properties[key]);
                exports.core.defineProperty(object, key, o, flags);
            }
        }
    },
    assign: function (target, source, options) {
        if (target === source)
            return target;
        exports.core.defineProperties(target, Object.getOwnPropertyDescriptors(source), options);
        return target;
    },
    deleteProperties: function (object, preserve) {
        if (object === preserve)
            return;
        exports.core.properties(object, { hasOwn: true }, (obj, prop) => {
            if (!exports.core.exists(preserve) || !exports.core.properties(preserve, { hasOwn: true }).has(prop))
                delete obj[prop];
        });
    },
    clone: function (object, prototype) {
        if (exports.core.exists(prototype))
            return exports.core.assign(Object.create(prototype), object);
        else
            return exports.core.assign(Object.create(Object.getPrototypeOf(object)), object);
    },
    isConstructor: function (object) {
        try {
            Reflect.construct(String, [], object);
        }
        catch (e) {
            return false;
        }
        return true;
    },
    inherit: function (child, base) {
        Object.setPrototypeOf(child.prototype, base.prototype);
        Object.setPrototypeOf(child, base);
    },
    reflectConstruct: function (base, name, constructor, argnames) {
        let args = argnames;
        if (!exports.core.exists(args)) {
            args = ["...args"];
            let STRIP_COMMENTS = /((\/\/.*$)|(\/\*.*\*\/))/mg;
            let funcString = constructor.toString().replace(STRIP_COMMENTS, "");
            if (funcString.indexOf("function") === 0) {
                let s = funcString.substring("function".length).trimStart();
                args = s.substring(s.indexOf("(") + 1, s.indexOf(")"))
                    .split(",")
                    .map((a) => {
                    let clean = a.trim();
                    clean = clean.split(/[ =]/)[0];
                    return clean;
                })
                    .filter((c) => c !== "");
            }
        }
        let definition;
        let argstr = args.join(",");
        if (!exports.core.exists(name))
            name = constructor.name;
        name.replace(/[ \t\r\n]/g, "");
        if (name === "")
            name = "__ReflectConstruct__";
        let parts = name.split(".").filter(c => c !== "");
        let evalStr = "{ let ";
        for (let i = 0; i < parts.length - 1; ++i) {
            let part = parts[i];
            evalStr += `${part} = {}; ${part}.`;
        }
        evalStr += `${parts[parts.length - 1]} = function(${argstr}) { return definition.__reflect__.call(this, new.target, [${argstr}]); }; definition = ${parts.join(".")} }`;
        eval(evalStr);
        if (!exports.core.exists(definition)) {
            console.warn("eval() call failed to create reflect constructor. Using fallback...");
            definition = function (...args) {
                return definition.__reflect__.call(this, new.target, args);
            };
        }
        definition.__constructor__ = constructor;
        definition.__args__ = function () {
            return [];
        };
        definition.__reflect__ = function (newTarget, args = []) {
            if (exports.core.exists(newTarget)) {
                let obj = Reflect.construct(base, definition.__args__(...args), definition);
                definition.__constructor__.call(obj, ...args);
                return obj;
            }
            else
                definition.__constructor__.call(this, ...args);
        };
        return definition;
    }
};
