declare namespace RHU {
    interface Modules {
        "raudy": {
            api: Raudy.API;
        };
    }
}

RHU.module(new Error(), "raudy", { 
}, function() {
    return {
        api: window.api
    };
});