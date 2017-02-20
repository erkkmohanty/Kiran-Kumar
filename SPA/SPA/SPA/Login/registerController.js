(function (app) {
    app.controller("registerCtrl", registerController);
    registerController.$inject = ["$timeout", "authService", "notificationService"];

    function registerController($timeout, authService, notificationService) {
        var rg = this;
        rg.register = _register;
        function _register() {
            debugger;
            rg.dataLoading = true;
            authService.register(rg.user).then(registerSuccess, registerFailure);
        }
        function registerSuccess(response) {
            debugger;
            rg.dataLoading = false;
            notificationService.displaySuccess(response.data);
            $timeout(function () {
                $state.go("Login");
            }, 5000);
        }
        function registerFailure(error) {
            debugger;
            rg.dataLoading = false;
            notificationService.displayError(error.message);
        }
    }
})(angular.module("authModule"));