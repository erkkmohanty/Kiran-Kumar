"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("angular2/core");
var router_1 = require("angular2/router");
var static_component_1 = require("./components/static.component");
var AppComponent = (function () {
    function AppComponent(router, location) {
        this.router = router;
        this.location = location;
        this.routes = null;
    }
    AppComponent.prototype.ngOnInit = function () {
        if (this.routes === null) {
            this.routes = [
                { path: "/index", component: static_component_1.StaticComponent, name: "Index", useAsDefault: true },
                new router_1.AsyncRoute({
                    path: "/sub",
                    name: "Sub",
                    loader: function () { return System.import("app/components/mvc.component").then(function (c) { return c["MvcComponent"]; }); }
                }),
                new router_1.AsyncRoute({
                    path: "/numbers",
                    name: "Numbers",
                    loader: function () { return System.import("app/components/api.component").then(function (c) { return c["ApiComponent"]; }); }
                })
            ];
            this.router.config(this.routes);
        }
    };
    AppComponent.prototype.getLinkStyle = function (route) {
        return this.location.path().indexOf(route.path) > -1;
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: "app",
            templateUrl: "/app/app.html",
            directives: [router_1.ROUTER_DIRECTIVES]
        })
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
