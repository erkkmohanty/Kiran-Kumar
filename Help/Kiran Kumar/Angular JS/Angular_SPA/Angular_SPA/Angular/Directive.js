/// <reference path="app.js" />
/// <reference path="../Scripts/angular.js" />
customDirApp.directive("mydir", function () {
    var directive = {};//definning the directive object
    directive.restrict = "E";//Signifies that directive is element directive
    //template replaces the complete element with its text
    directive.template = "Student:<b>{{student.name}}<b>,<br/>Roll No.:<b>{{student.rollno}}<b/>";
    //scope is used to distinguish each mydir element based on criteria
    directive.scope = { student: "=name" }
    directive.compile = function (element, attributes) {
        element.css("border", "1px solid #cccccc");
        var linkFunction = function ($scope, element, attributes) {
            element.html("Student: <b>" + $scope.student.name + "</b> , Roll No: <b>" + $scope.student.rollno + "</b><br/>");
            element.css("background-color", "#ff00ff");
        }
        return linkFunction;
    }
    return directive;
});