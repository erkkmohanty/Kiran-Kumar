(function (app) {
    "use strict";
    app.controller("LoginCtrl", LoginCtrl);


    LoginCtrl.$inject = ["$scope", "authService", "notificationService", "$state"];
    function LoginCtrl($scope, authService, notificationService, $state) {
        var vm = this;
        vm.userInfo = {
            userName: "",
            password: ""
        };
        vm.dataLoading = false;
        vm.logIn = logIn;

        function logIn() {
            debugger;
            vm.dataLoading = true;
            authService.login(vm.userInfo).then(logInSuccess, logInFailure);
        }
        function logInSuccess(response) {
            debugger;
            vm.dataLoading = false;
            try {
                notificationService.displaySuccess("success");
            }
            catch (e) {
                console.log(e);
            }
            $state.go("Dashboard");

        }
        function logInFailure(error) {
            debugger;
            vm.dataLoading = false;
            notificationService.displayError(error);
        }
    }
})(angular.module("authModule"));