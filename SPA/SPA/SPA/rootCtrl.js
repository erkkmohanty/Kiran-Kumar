(function (app) {
    "use strict";
    app.controller("RootCtrl", RootCtrl);

    RootCtrl.$inject = ["authService"];

    function RootCtrl(authService) {
        var rc = this;
        rc.authentication = authService.authentication;
    }
})(angular.module("rootModule"));