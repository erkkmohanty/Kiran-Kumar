"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("angular2/core");
var core_directives_1 = require("angular2/src/common/directives/core_directives");
var api_service_1 = require("./api.service");
var ApiComponent = (function () {
    function ApiComponent(service) {
        this.service = service;
        this.apiOccurances = 0;
        this.isLoading = false;
    }
    ApiComponent.prototype.ngOnInit = function () {
        this.get();
    };
    ApiComponent.prototype.get = function () {
        var _this = this;
        this.isLoading = true;
        this.service.get(function (json) {
            if (json) {
                _this.data = json.numbers;
                _this.isLoading = false;
                _this.apiOccurances++;
            }
        });
    };
    ApiComponent = __decorate([
        core_1.Component({
            selector: "numbers",
            templateUrl: "/partial/numbers",
            providers: [api_service_1.ApiService],
            directives: core_directives_1.CORE_DIRECTIVES
        })
    ], ApiComponent);
    return ApiComponent;
}());
exports.ApiComponent = ApiComponent;
