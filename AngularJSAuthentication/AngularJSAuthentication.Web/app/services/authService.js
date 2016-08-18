/// <reference path="../app.js" />
"use strict";


app.factory("authService", ["$http", "$q", "localStorageService", "url_provider", function ($http, $q, localStorageService, url_provider) {
    debugger;
    var serviceBase = url_provider.url;
    var authServiceFactory = {};

    var _authentication = { isAuth: false, userName: "" };



    var _saveRegistration = function (registration) {
        _logOut();
        debugger;
        return $http.post(serviceBase + "api/account/register", registration).then(function (response) {
            return response;
        });

    }

    var _login = function (loginData) {
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deferred = $q.defer();
        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    }


    var _fillAuthData = function () {
        var authData = localStorageService.get("authorizationData");
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    var _logOut = function () {
        debugger;
        localStorageService.remove("authorizationData");
        _authentication.isAuth = false;
        _authentication.userName = "";
    }
    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);