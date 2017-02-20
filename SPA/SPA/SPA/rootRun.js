(function (app) {
    "use strict";
    app.run(run);
    run.$inject = ["authService", "$rootScope", "$state"];
    function run(authService, $rootScope, $state) {
        $rootScope.$on("$stateChangeStart", function (event, toState) {
            authService.fillAuthData();
            var requiredLogin = false;
            // check if this state need login
            if (toState.data && toState.data.requiredLogin)
                requiredLogin = true;
            debugger;
            //var restrictedPage = $.inArray(toState.name, ["Login", "Register"]) === -1;
            //if (restrictedPage && !authService.authentication.isAuthenticated) {
            //    setTimeout(function () {
            //        $state.go("Login");
            //    }, 0);
               
            //}
            if (requiredLogin && !authService.authentication.isAuthenticated) {
                event.preventDefault();
                $state.go('Login');
            }
        });
    }
})(angular.module("rootModule"));

