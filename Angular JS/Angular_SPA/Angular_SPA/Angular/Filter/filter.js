/// <reference path="E:\Kiran Kumar\Angular JS\Angular_SPA\Angular_SPA\Scripts/angular.js" />
/// <reference path="../app.js" />
/// <reference path="../Helper/helperjs.js" />


filterApp.filter("CamelCase", function () {
    return function (word) {
        var wordArray = word.split(' ');
        for (var singleWord in wordArray) {
            wordArray[singleWord] = convertToCamelCase(wordArray[singleWord]);
        }
        return wordArray.join(' ');
    }
});
