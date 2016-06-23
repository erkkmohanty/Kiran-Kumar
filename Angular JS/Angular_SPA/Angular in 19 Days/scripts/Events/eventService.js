var eventModule = angular.module("eventModule");


eventModule.factory("EventService", function($http, $q) {
    return {
        getTalks: function() {
            debugger;
            //Get the deferred object

            var deferred = $q.defer();

            //Initiates the AJAX call

            $http({ method: "GET", url: "/Events/GetTalkDetails" })
                .success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request
            //completes
            debugger;
            return deferred.promise;
        },
        getSpeakers:function() {
            var deferred = $q.defer();

            $http({ method: "GET", url: "/Events/GetSpeakerDetails" })
                .success(deferred.resolve).error(deferred.reject);

            return deferred.promise;
        },
        addTalk: function (talkObj) {
            debugger;
            
            // Get the deferred object
            var deferred = $q.defer();
            // Initiates the AJAX call
            $http({
                method: "POST", url: "/Events/AddTalk", data: { talkObj: talkObj, dat: 2 }
            }).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request
            //completes
            return deferred.promise;
        }
    };
});

