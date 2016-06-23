var eventModule = angular.module("eventModule", ["ngRoute", "directoryModule"]);

eventModule.config(function($routeProvider) {
    $routeProvider.when("/Talks", {
        templateUrl: "/Templates/Talk.html",
        controller: "eventController"
    }).when("/Speakers", {
        templateUrl: "/Templates/Speaker.html",
        controller: "speakerCtrl"
    }).when("/error", {
        template: "<b>Sorry the item does not exist</b>"
    }).when("/AddTalk", {
        templateUrl: "/Templates/AddTalk.html",
        controller: "talkController"
    }).when("/CustomDirective", {
        templateUrl: "/Templates/CustomDirective.html",
        controller: "CustomDirectiveController"
    }).otherwise({
        redirectTo: "/Talks"
    });
});



