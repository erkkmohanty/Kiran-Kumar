﻿/// <script src="//ajax.googleapis.com/ajax/libs/angularjs/1.2.16/angular.min.js"></script>
var app = angular.module("AngularAuthApp", ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);


app.config(["$routeProvider", function ($routeProvider) {
    debugger;
    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    })
    .when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    })
    .when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    })
    .when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    })
    .otherwise("/", {
        redirectTo: "/home"
    });
}]);

app.provider("url_provider", urlProvider);

function urlProvider() {
    var urlName = '';
    this.setUrl = function (url) {
        urlName = url;
    };
    this.$get = function () {
        return { url: urlName };
    }
}


app.config(function ($httpProvider, url_providerProvider) {
    url_providerProvider.setUrl("http://localhost:18470/");
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);