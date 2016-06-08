(function() {
    "use strict";
    angular.module("app")
        .controller("LoginController", LoginController);
    LoginController.$inject = ["$location", "AuthenticationService", "FlashService"];

    function LoginController($location, AuthenticationService, FlashService) {
        debugger;
        var vm = this;
        vm.login = login;

        (function initController() {
            debugger;
            //reset login status
            AuthenticationService.ClearCredentials();
        })();

        function login() {
            debugger;
            vm.dataLoading = true;
            AuthenticationService.Login(vm.username, vm.password, function(response) {
                if (response.success) {
                    AuthenticationService.SetCredentials(vm.username, vm.password);
                    $location.path("/");
                } else {
                    FlashService.Error(response.message);
                    vm.dataLoading = false;
                }
            });
        }
    }
})();