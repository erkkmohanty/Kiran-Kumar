(function() {
    "use strict";
    angular.module("app")
        .factory("UserService", UserService);

    UserService.$inject = ["$timeout", "$filter", "$q"];

    function UserService($timeout, $filter, $q) {
        debugger;
        var service = {};
        service.GetAll = GetAll;
        service.GetById = GetById;
        service.GetByUsername = GetByUsername;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        return service;

        function GetAll() {
            debugger;
            var deferred = $q.defer();
            deferred.resolve(getUsers());
            return deferred.promise;
        }

        function GetById(id) {
            debugger;
            var deferrred = $q.defer();
            var filtered = $filter("filter")(getUsers(), { id: id });
            var user = filtered.length ? filtered[0] : null;
            deferrred.resolve(user);
            return deferrred.promise;
        }

        function GetByUsername(username) {
            debugger;
            var deferred = $q.defer();
            var filtered = $filter("filter")(getUsers(), { username: username });
            var user = filtered.length ? filtered[0] : null;
            deferred.resolve(user);
            return deferred.promise;
        }

        function Create(user) {
            debugger;
            var deferred = $q.defer();
            // simulate api call with $timeout
            $timeout(function() {
                GetByUsername(user.username)
                    .then(function(duplicateuser) {
                        if (duplicateuser !== null) {
                            deferred.resolve({ success: false, message: "Username \"" + user.username + "\" is already taken" });
                        } else {
                            var users = getUsers();
                            //assign id
                            var lastUser = users[users.length - 1] || { id: 0 };
                            user.id = lastUser.id + 1;

                            //Save to local storage
                            users.push(user);
                            setUsers(users);
                            deferred.resolve({ success: true });
                        }
                    });
            }, 1000);
            return deferred.promise;
        }

        function Update(user) {
            debugger;
            var deferred = $q.defer();
            var users = getUsers();
            for (var index = 0; index < users.length; index++) {
                if (users[index].id === user.id) {
                    users[index] = user;
                    break;
                }
            }
            setUsers(users);
            deferred.resolve({ success: true });
            return deferred.promise;
        }

        function Delete(id) {
            debugger;
            var deferred = $q.defer();
            var users = getUsers();
            for (var index = 0; index < users.length; index++) {
                if (users[index].id === id) {
                    users.splice(index, 1);
                    break;
                }
            }
            setUses(users);
            deferred.resolve({ succes: true });
            return deferred.promise;
        }

        //private functions
        function getUsers() {
            debugger;
            if (!localStorage.users) {
                localStorage.users = JSON.stringify([]);
            }
            return JSON.parse(localStorage.users);
        }

        function setUsers(users) {
            debugger;
            localStorage.users = JSON.stringify(users);
        }
    }
})();