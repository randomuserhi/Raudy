"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.weak = exports.WeakCollection = exports.WeakRefMap = void 0;
const core_cjs_1 = require("./core.cjs");
let Map_set = Map.prototype.set;
let Map_keys = Map.prototype.keys;
let Map_get = Map.prototype.get;
exports.WeakRefMap = core_cjs_1.core.reflectConstruct(Map, "WeakRefMap", function () {
    this._registry = new FinalizationRegistry((key) => {
        this.delete(key);
    });
});
exports.WeakRefMap.prototype.set = function (key, value) {
    this._registry.register(value, key);
    return Map_set.call(this, key, new WeakRef(value));
};
exports.WeakRefMap.prototype.get = function (key) {
    let raw = Map_get.call(this, key);
    if (!core_cjs_1.core.exists(raw))
        return undefined;
    let value = raw.deref();
    if (!core_cjs_1.core.exists(value))
        return undefined;
    return value;
};
exports.WeakRefMap.prototype.values = function* () {
    for (let key of Map_keys.call(this)) {
        let value = Map_get.call(this, key).deref();
        if (core_cjs_1.core.exists(value))
            yield value;
        else
            this.delete(key);
    }
};
exports.WeakRefMap.prototype[Symbol.iterator] = function* () {
    for (let key of Map_keys.call(this)) {
        let value = Map_get.call(this, key).deref();
        if (core_cjs_1.core.exists(value))
            yield [key, value];
        else
            this.delete(key);
    }
};
core_cjs_1.core.inherit(exports.WeakRefMap, Map);
let WeakSet_add = WeakSet.prototype.add;
let WeakSet_delete = WeakSet.prototype.delete;
exports.WeakCollection = core_cjs_1.core.reflectConstruct(WeakSet, "WeakCollection", function () {
    this._collection = [];
    this._registry = new FinalizationRegistry(() => {
        this._collection = this._collection.filter((i) => {
            return core_cjs_1.core.exists(i.deref());
        });
    });
});
exports.WeakCollection.prototype.add = function (...items) {
    if (items.length === 1) {
        this._collection.push(new WeakRef(items[0]));
        this._registry.register(items[0], undefined);
        return WeakSet_add.call(this, items[0]);
    }
    for (let item of items) {
        if (!this.has(item)) {
            this._collection.push(new WeakRef(item));
            WeakSet_add.call(this, item);
            this._registry.register(item, undefined);
        }
    }
};
exports.WeakCollection.prototype.delete = function (...items) {
    if (items.length === 1) {
        this._collection = this._collection.filter((ref) => {
            let item = ref.deref();
            return core_cjs_1.core.exists(item) && !items.includes(item);
        });
        return WeakSet_delete.call(this, items[0]);
    }
    for (let item of items)
        WeakSet_delete.call(this, item);
    this._collection = this._collection.filter((ref) => {
        let item = ref.deref();
        return core_cjs_1.core.exists(item) && !items.includes(item);
    });
};
exports.WeakCollection.prototype[Symbol.iterator] = function* () {
    let collection = this._collection;
    this._collection = [];
    for (let ref of collection) {
        let item = ref.deref();
        if (core_cjs_1.core.exists(item)) {
            this._collection.push(new WeakRef(item));
            yield item;
        }
    }
};
core_cjs_1.core.inherit(exports.WeakCollection, WeakSet);
exports.weak = {
    WeakRefMap: exports.WeakRefMap,
    WeakCollection: exports.WeakCollection
};
