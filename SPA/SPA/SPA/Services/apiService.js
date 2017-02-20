(function (app) {
    "use strict";
    app.factory("apiService", apiService);

    apiService.$inject = ["$http", "$q"];

    function apiService($http, $q) {
        var apiService = {
            getData: getData,
            postData: postData,
            putData: putData,
            deleteData: deleteData
        };
        return apiService;

        function getData(url, params, headers) {
            var deferred = $q.defer();

            $http.get(url, params, headers).then(function (response) {
                deffered.resolve(response);
            },
            function (error) {
                deffered.reject(error);
            });
            return deferred.promise;
        }

        function postData(url, params, headers) {
            debugger;
            var deffered = $q.defer();
            $http.post(url, params, headers).then(function (response) {
                deffered.resolve(response);
            }, function (error) {
                deffered.reject(error);
            });
            return deffered.promise;
        }

        function putData(url, params, headers) {
            var deffered = $q.defder();
            $http.put(url, params, headers).then(function (response) {
                deffered.resolve(response);
            }, function (error) {
                deffered.reject(error);
            });
            return defered.promise;
        }

        function deleteData(url, params, headers) {
            headers = {
                headers: headers
            };
            var deffered = $q.defder();
            $http.delete(url, params, headers).then(function (response) {
                deffered.resolve(response);
            }, function (error) {
                deffered.reject(error);
            });
            return defered.promise;
        }
    }
})(angular.module("common.core"));