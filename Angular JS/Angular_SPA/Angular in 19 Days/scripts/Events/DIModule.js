/// <reference path="../angular.js" />
"use strict";
var dimodule = angular.module("DI Module", []);

//Providing a number and assigning to value object
dimodule.value("NumberofItems", 40);

//Providing a string and assigning to value object
dimodule.value("ApplicationHeader", "Angular App with DI using value");

//Providing an object and assigning value object
dimodule.value("Person", { Name: "Kiran Kumar", Age: 24, City: "Los Angeles" });

//Providing current date and assigning to value object
dimodule.value("Time", new Date());


