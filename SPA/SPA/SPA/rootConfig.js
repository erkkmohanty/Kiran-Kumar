(function (app) {
    "use strict";
    app.config(configuration);
    
    configuration.$inject = ["$stateProvider", "$urlRouterProvider", "urlServiceProvider", "$httpProvider", "$provide"];
    function configuration($stateProvider, $urlRouterProvider, urlServiceProvider, $httpProvider, $provide) {
        debugger;
        Raven.config('https://8b13fcf366054250a71f81bdf94e547c@sentry.io/98780').install();
        $stateProvider.state("Login", {
            url: "/Login",
            controller: "LoginCtrl",
            templateUrl: "SPA/Login/login.html",
            controllerAs: "lc"
        }).state("Register", {
            url: "/Register",
            controller: "registerCtrl",
            templateUrl: "SPA/Login/register.html",
            controllerAs: "rc"
        })
        .state("Dashboard", {
            url: "/Dashboard",
            controller: "dashboardCtrl",
            templateUrl: "SPA/Dashboard/dashboard.html",
            controllerAs: "dc",
            data: { requiredLogin: true }
        });
        $urlRouterProvider.otherwise("/Dashboard");

        urlServiceProvider.setUrl("http://localhost:18470/");
        $httpProvider.interceptors.push("authInterceptorService");

        $provide.decorator('$exceptionHandler', ['$log', '$delegate',
          function ($log, $delegate) {
              return function (exception, cause) {
                  $log.debug('Sentry exception handler.');
                  Raven.captureException(exception);
                  $delegate(exception, cause);
              };
          }
        ]);
    }
})(angular.module("rootModule"));