/// <reference path="../../asp.net with angular unit test/customangular/home.js" />

describe("My First Test -> ", function () {
    it("Add with two positive num Positive Scenario 1", function () {
        debugger;
        expect(Add(2, 3)).toEqual(5);
    });
    it("Add with two positive num Positive Scenario 2", function () {
        debugger;
        expect(Add(-4, -3)).toEqual(-7);
    });
});