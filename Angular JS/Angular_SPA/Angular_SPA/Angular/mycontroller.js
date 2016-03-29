/// <reference path="../Scripts/angular.js" />
/// <reference path="~/Angular/app.js" />
app.controller("MyController", function ($scope) {
    $scope.article = "Hello There! I am learning Angular JS";
});

app.controller("BookStore", function ($scope) {
    $scope.items = [{ ISBN: "567678", Name: "Angular JS", Price: 234.78, Quantity: 10 },
                    { ISBN: "5634578", Name: "Intoduction to .NET", Price: 344.78, Quantity: 23 },
                    { ISBN: "5632278", Name: "Intoduction to JAVA", Price: 456.89, Quantity: 33 }];
});

app2.controller("filterController", function ($scope) {
    $scope.student = {
        firstName: "Kiran Kumar", lastName: "Mohanty", fullName: function () {
            var studentObject;
            studentObject = $scope.student;
            return studentObject.firstName + " " + studentObject.lastName;
        }, fees: 1008.987, subjects: [{ name: "Physics", mark: 80 }, { name: "Chemistry", mark: 70 }, { name: "Math", mark: 50 }, { name: "Biology", mark: 99 }]
    };
});

app.controller("BookStoreCRUD", function ($scope) {
    $scope.items = [{ ISBN: "567678", Name: "Angular JS", Price: 234.78, Quantity: 10 },
                    { ISBN: "5634578", Name: "Intoduction to .NET", Price: 344.78, Quantity: 23 },
                    { ISBN: "5632278", Name: "Intoduction to JAVA", Price: 456.89, Quantity: 33 }];

    $scope.editing = false;
    $scope.totalPrice = function () {
        var total = 0;
        for (index = 0; index < $scope.items.length; index++) {
            total += $scope.items[index].Price * $scope.items[index].Quantity;
        }
        return toFixed(total, 2);
    };

    $scope.removeItem = function (index) {
        debugger;
        $scope.items.splice(index, 1);
    };

    $scope.editItem = function (index) {
        debugger;
        $scope.editing = $scope.items.indexOf(index);
    };

    $scope.saveField = function (index) {
        debugger;
        $scope.editing = false;
    };

    $scope.addItem = function (item) {
        debugger;
        $scope.items.push(item);
        $scope.item = {};
    };
});
function toFixed(value, precision) {
    var power = Math.pow(10, precision || 0);
    return String(Math.round(value * power) / power);
}


scopeApp.controller("ScopeController", function ($scope) {
    $scope.message = "Scope Controller Message";
    $scope.type = "Scope Controller type";
});
scopeApp.controller("CircleController", function ($scope) {
    $scope.message = "Circle Controller Message";

});
scopeApp.controller("SquareController", function ($scope) {
    $scope.message = "Square Controller Message";
    $scope.type = "Square Controller type";
});

serviceApp.value("defaultInput", 5);

serviceApp.controller("ServiceController", ["$scope", "CalcService", "defaultInput", function ($scope, CalcService, dInput) {
    $scope.number = dInput;
    $scope.result = CalcService.square($scope.number);
    $scope.square = function () {
        $scope.result = CalcService.square($scope.number);
    }
    $scope.addition = function () { $scope.result2 = CalcService.addition($scope.number2, $scope.number3); }
}]);


dependencyApp.controller("dependCtrl", [
    "$scope", "MathService2", function ($scope, MathService2) {
        $scope.square= function() {
            $scope.result = MathService2.multiply($scope.number, $scope.number);
        }
    }
]);
customDirApp.controller("StudentCtrl", ["$scope", function ($scope) {
    $scope.Mahesh = {};
    $scope.Mahesh.name = "Mahesh Parashar";
    $scope.Mahesh.rollno = 1;
    $scope.Piyush = {};
    $scope.Piyush.name = "Piyush Parashar";
    $scope.Piyush.rollno = 2;
}]);