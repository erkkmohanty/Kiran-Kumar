/// <reference path="../angular.js" />
"use strict";

var filterModule = angular.module("FilterModule", []);


//Custom Filter Type 1 (Filter where item is a string)

filterModule.filter("ConvertPhone", function () {
    return function (item) {
        debugger;
        var temp = ("" + item).replace(/\D/g, '');
        var temparr = temp.match(/^(\d{3})(\d{3})(\d{4})$/);
        return (!temparr) ? null : "(" + temparr[1] + ") " +
        temparr[2] + "-" + temparr[3];
    };
});

// Custom Filter Type 2 (Filter where item is an array)


filterModule.filter("RemoveSpecialCharacters", function () {
    return function (items) {
        debugger;
        var filteredList = [];
        for (var item in items) {
            if (items.hasOwnProperty(item)) {
                filteredList.push(items[item].replace(/[^\w\s]/gi, ""));
            }
        }
        return filteredList;
    };
});





