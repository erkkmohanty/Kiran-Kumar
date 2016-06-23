(function() {
    "use strict";
    angular.module("app", ["ngRoute", "ngCookies"])
        .config(config)
        .run(run).directive('ngModel', function() {
            return {
                require: 'ngModel',
                link: function (scope, elem, attr, ngModel) {
                    debugger;
                    elem.on('blur', function() {
                        ngModel.$dirty = true;
                        scope.$apply();
                    });

                    ngModel.$viewChangeListeners.push(function() {
                        ngModel.$dirty = false;
                    });

                    scope.$on('$destroy', function() {
                        elem.off('blur');
                    });
                }
            }
        });
    //Here the above directive is for checking invalid data on blur

    var compareTo = function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.compareTo = function (modelValue) {
                    debugger;
                    return modelValue===undefined?true: modelValue === scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function (modelValue) {
                    debugger;
                    ngModel.$validate();
                });
            }
        };
    };

    angular.module("app").directive("compareTo", compareTo);

    config.$inject = ["$routeProvider","$locationProvider"];

    function config($routeProvider, $locationProvider) {
        debugger;
        $routeProvider.when('/', {
            controller: 'HomeController',
            templateUrl: 'home/home.view.html',
            controllerAs: 'vm'
        })

            .when('/login', {
                controller: 'LoginController',
                templateUrl: 'login/login.view.html',
                controllerAs: 'vm'
            })

            .when('/register', {
                controller: 'RegisterController',
                templateUrl: 'register/register.view.html',
                controllerAs: 'vm'
            })

            .otherwise({ redirectTo: '/' });
    }
    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        debugger;
        //Keep user loggedin after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in and trying to access a restricted page
            debugger;
            var restrictedPage = $.inArray($location.path(), ['/login', '/register']) === -1;
            var loggedIn = $rootScope.globals.currentUser;
            if (restrictedPage && !loggedIn) {
                $location.path('/login');
            }
        });
    }
})();