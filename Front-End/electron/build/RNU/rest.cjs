"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.rest = void 0;
const core_cjs_1 = require("./core.cjs");
exports.rest = {
    fetch: function (options) {
        let partialOpt = {
            url: "",
            fetch: undefined,
            callback: undefined,
            parser: undefined
        };
        core_cjs_1.core.parseOptions(partialOpt, options);
        if (!core_cjs_1.core.exists(partialOpt.fetch))
            throw new SyntaxError("No fetch options were provided.");
        if (!core_cjs_1.core.exists(partialOpt.callback))
            throw new SyntaxError("No callback was provided.");
        let opt = partialOpt;
        if (core_cjs_1.core.exists(opt.parser)) {
            return (async function (...params) {
                let payload = {
                    urlParams: {},
                    body: null
                };
                core_cjs_1.core.parseOptions(payload, opt.parser(...params));
                let init = core_cjs_1.core.clone(opt.fetch);
                init.body = payload.body;
                let url = new URL(opt.url);
                for (let key in payload.urlParams)
                    url.searchParams.append(key, payload.urlParams[key]);
                const response = await fetch(url, init);
                return await opt.callback(response);
            });
        }
        else {
            return (async function (payload) {
                let parsedPayload = {
                    urlParams: {},
                    body: null
                };
                core_cjs_1.core.parseOptions(parsedPayload, payload);
                let init = core_cjs_1.core.clone(opt.fetch);
                init.body = payload.body;
                let url = new URL(opt.url);
                for (let key in parsedPayload.urlParams)
                    url.searchParams.append(key, parsedPayload.urlParams[key]);
                const response = await fetch(url, init);
                return await opt.callback(response);
            });
        }
    },
    fetchJSON: function (options) {
        let partialOpt = {
            url: undefined,
            fetch: undefined,
            callback: undefined,
            parser: undefined
        };
        core_cjs_1.core.parseOptions(partialOpt, options);
        if (!core_cjs_1.core.exists(partialOpt.url))
            throw new SyntaxError("No fetch url was provided.");
        if (!core_cjs_1.core.exists(partialOpt.fetch))
            throw new SyntaxError("No fetch options were provided.");
        if (!core_cjs_1.core.exists(partialOpt.callback))
            throw new SyntaxError("No callback was provided.");
        let headers = new Headers(partialOpt.fetch.headers);
        headers.set("Content-Type", "application/json");
        partialOpt.fetch.headers = headers;
        let opt = partialOpt;
        if (core_cjs_1.core.exists(opt.parser)) {
            let parser = opt.parser;
            opt.parser = function (...params) {
                let payload = parser(...params);
                if (core_cjs_1.core.exists(payload.body))
                    payload.body = JSON.stringify(payload.body);
                return payload;
            };
        }
        else {
            opt.parser = function (payload) {
                if (core_cjs_1.core.exists(payload.body))
                    payload.body = JSON.stringify(payload.body);
                return payload;
            };
        }
        return exports.rest.fetch(opt);
    }
};
