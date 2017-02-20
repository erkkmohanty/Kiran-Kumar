(function (app) {
    "use strict";

    app.factory("authService", authService);

    authService.$inject = ["apiService", "localStorageService", "$state", "urlService", "$q"]
    function authService(apiService, localStorageService, $state, urlService, $q) {
        var serverUrl = urlService.url;
        var _authentication = { isAuthenticated: false, userName: "" };
        var authServiceFactory = {
            register: _register,
            login: _login,
            logout: _logOut,
            fillAuthData: _fillAuthData,
            authentication: _authentication
        };
        return authServiceFactory;

        function _register(userInfo) {
            debugger;
            var deferred = $q.defer();
            apiService.postData(serverUrl + "api/account/register", userInfo, {}).then(function (response) {
                deferred.resolve(response);
            }, function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        function _login(userInfo) {
            _logOut();
            var deferred = $q.defer();

            var data = "grant_type=password&username=" + userInfo.userName + "&password=" + userInfo.password;

            apiService.postData(serverUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
                localStorageService.set('authorizationData', { token: response.data.access_token, userName: userInfo.userName });
                _authentication.isAuthenticated = true;
                _authentication.userName = userInfo.userName;
                deferred.resolve(response);
            }, function (error) {
                _logOut();
                deferred.reject(error);
            });
            return deferred.promise;
        }

        function _logOut() {
            localStorageService.remove("authorizationData");
            localStorageService.clearAll();
            _authentication.isAuthenticated = false;
            _authentication.userName = "";
            $state.go("Login");
        }

        function _fillAuthData() {
            var authData = localStorageService.get("authorizationData");
            if (authData) {
                _authentication.isAuthenticated = true;
                _authentication.userName = authData.userName;
            }
        }


    }
})(angular.module("common.core"));