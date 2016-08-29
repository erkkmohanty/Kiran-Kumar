(function () {
    angular.module("app")
        .controller("RegisterController", RegisterController);
    RegisterController.$inject = ["UserService", "$location", "$rootScope", "FlashService", "$timeout"];

    function RegisterController(UserService, $location, $rootScope, FlashService, $timeout) {
        debugger;
        var vm = this;
        vm.countryList = [{ Id: 1, Name: "India" }, { Id: 2, Name: "Australia" }, { Id: 3, Name: "US" }, { Id: 4, Name: "UK" }];
        vm.selectedCountry = null;
        vm.stateList = [];
        vm.selectedState = null;
        vm.register = register;
        vm.getStates = getStates
        function getStates() {
            sleep(500).then(() => {
                debugger;
                // Do something after the sleep!
                console.log(vm.selectedCountry);
                vm.stateList = [{ Id: 1, Name: "Odisha" }, { Id: 2, Name: "Delhi" }, { Id: 3, Name: "W.B." },
                    { Id: 4, Name: "Tripura" }, { Id: 5, Name: "U.P." }];
            });
        }
        function register() {
            vm.dataLoading = true;
            UserService.Create(vm.user)
                .then(function (response) {
                    if (response.success) {
                        FlashService.Success("Registration Successfull", true);
                        $location.path("/login");
                    } else {
                        FlashService.Error(response.message);
                        vm.dataLoading = false;
                    }
                });
        }

        function sleep(time) {
            return new Promise((resolve) => $timeout(resolve, time));
        }
    }
})();