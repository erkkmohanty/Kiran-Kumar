appRoute.config(function ($routeProvider) {
    debugger;
    $routeProvider.when("/Add", {
        templateUrl:"route_templates/add.html",
        controller:"addCtrl"
    }).when("/Update",  {
        templateUrl:"route_templates/update.html",
        controller:"updateCtrl"
    }).when("/Delete",  {
        templateUrl:"route_templates/delete.html",
        controller:"deleteCtrl"
    }).when("/Show/:id", {
        templateUrl: "route_templates/show.html",
        controller: "showCtrl"
    }).otherwise({
        redirectTo:"/Show"
    });
});