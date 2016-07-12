var eventModule = angular.module("eventModule", ["ngRoute", "directoryModule", "FilterModule", "DI Module"]);

eventModule.config(function ($routeProvider) {
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
    }).when("/CustomFilter", {
        templateUrl: "/Templates/CustomFilter.html",
        controller: "CustomFilterController"
    }).when("/DI", {
        templateUrl: "/Templates/DI.html",
        controller: "DIController"
    }).otherwise({
        redirectTo: "/Talks"
    });
});



