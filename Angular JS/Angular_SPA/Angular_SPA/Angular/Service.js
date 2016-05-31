serviceApp.factory("MathService", function () {
    var factoryObj = {};
    factoryObj.multiply = function (a, b) { return a * b; }
    factoryObj.add = function (a, b) { return a + b; }
    return factoryObj;
});


serviceApp.service("CalcService", ["MathService", function (MathService) {
    this.square = function (a) {
        return MathService.multiply(a, a);
    }
    this.addition = function (a, b) {
        return a + b;
    }
}]);


dependencyApp.config(["$provide", function ($provide) {
    $provide.provider("MathService2", function () {

        this.$get = function () {
            var factory = {};
            factory.multiply = function (a, b) { return a * b; }
            return factory;
        }
    });
}]);


serviceApp.service("SquareService", function () {
    this.square = function (a) { return a * a; };
    this.Multiply = function(num1, num2) { return num1 * num2; };
});