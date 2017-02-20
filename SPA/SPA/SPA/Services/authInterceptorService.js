(function (app) {
    "use strict";
    app.factory("authInterceptorService", authInterCeptorService);

    authInterCeptorService.$inject = ["$q", "localStorageService", "notificationService", "$injector"];

    function authInterCeptorService($q, localStorageService, notificationService, $injector) {
        var authInterCeptor = {
            // On request success
            request: _request,
            // On request failure
            requestError: _requestError,
            // On response success
            response: _response,
            // On response failture
            responseError: _responseError
        }
        return authInterCeptor;

        function _request(config) {
            // console.log(config); // Contains the data about the request before it is sent.
            config.headers = config.headers || {};

            var authData = localStorageService.get("authorizationData");
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }
            //return config;
            // Return the config or wrap it in a promise if blank.
            return config || $q.when(config);
        }


        function _requestError(rejection) {
            // console.log(rejection); // Contains the data about the error on the request.
            // Return the promise rejection.
            return $q.reject(rejection);
        }

        function _response(response) {
            // console.log(response); // Contains the data from the response.
            // Return the response or promise.
            //return response;
            return response || $q.when(response);
        }
        function _responseError(rejection) {
            notificationService.displayError(rejection);
            //var $state = $injector.get('$state');
            //// console.log(rejection); // Contains the data about the error.
            //if (rejection.status === 401) {
            //    $state.go("/Login");
            //    localStorageService.remove('authorizationData');
            //}
            //// Return the promise rejection.
            //return $q.reject(rejection);
        }
    }
})(angular.module("common.core"));