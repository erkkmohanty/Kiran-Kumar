"use strict";
angular.module("Authentication", []);
angular.module("Home", []);

angular.module("BasicHttpAuthExample",
    ["Authentication", "Home", "ngRoute", "ngCookies"])
    .config([
        "$routeProvider", function($routeProvider) {
            debugger;
            $routeProvider.when("/login", {
                    controller: "LoginController",
                    templateUrl: "modules/authentication/views/login.html"
                })
                .when("/home", {
                    controller: "HomeController",
                    templateUrl: "modules/home/views/home.html"
                })
                .otherwise({ redirectTo: "/home" });
        }
    ])
    .run([
        "$rootScope", "$location", "$cookieStore", "$http",
        function($rootScope, $location, $cookieStore, $http) {
            debugger;
            // keep user logged in after page refresh
            $rootScope.globals = $cookieStore.get("globals") || {};
            if ($rootScope.globals.currentUser) {
                $http.defaults.headers.common["Authorization"] = "Basic " + $rootScope.globals.currentUser.authdata; // jshint ignore:line
            }

            $rootScope.$on("$locationChangeStart", function(event, next, current) {
                debugger;
                // redirect to login page if not logged in
                if ($location.path() !== "/login" && !$rootScope.globals.currentUser) {
                    $location.path("/login");
                }
            });
        }
    ]);