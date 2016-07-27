(function () {
    "use strict";

    angular.module("angularUploadApp", ["ngRoute", "angularFileUpload"])
            .config(config);

    config.$inject = ["$routeProvider"];

    function config($routeProvider) {
        $routeProvider.when("/", {
            controller: "fileUploadCtrl",
            templateUrl: "app/templates/fileUpload.html"
        })
        .otherwise({
            redirectTo:"/",
        });
    }
}());