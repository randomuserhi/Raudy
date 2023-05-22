(function () {
    let RHU = window.RHU;
    if (RHU === null || RHU === undefined)
        throw new Error("No RHU found. Did you import RHU before running?");
    RHU.module({ name: "rhu/event", trace: new Error(), hard: [] }, function () {
        if (RHU.exists(RHU.eventTarget) || RHU.exists(RHU.CustomEvent))
            console.warn("Overwriting RHU.EventTarget...");
        RHU.eventTarget = function (target) {
            let node = document.createTextNode(null);
            let addEventListener = node.addEventListener.bind(node);
            target.addEventListener = function (type, listener, options) {
                addEventListener(type, (e) => { listener(e.detail); }, options);
            };
            target.removeEventListener = node.removeEventListener.bind(node);
            target.dispatchEvent = node.dispatchEvent.bind(node);
        };
        RHU.CustomEvent = function (type, detail) {
            return new CustomEvent(type, { detail: detail });
        };
    });
})();
