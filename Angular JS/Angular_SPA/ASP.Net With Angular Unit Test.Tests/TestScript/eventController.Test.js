/// <reference path="../../angular in 19 days/scripts/angular.js" />
/// <reference path="../../angular in 19 days/scripts/angular-mocks.js" />
/// <reference path="../../angular in 19 days/scripts/angular-route.js" />
/// <reference path="../../angular in 19 days/scripts/events/customfilter.js" />
/// <reference path="../../angular in 19 days/scripts/events/customdirective.js" />
/// <reference path="../../angular in 19 days/scripts/events/dimodule.js" />


/// <reference path="../../angular in 19 days/scripts/events/eventmodule.js" />
/// <reference path="../../angular in 19 days/scripts/events/eventservice.js" />
/// <reference path="../../angular in 19 days/scripts/events/eventcontroller.js" />


describe("Event Controller Tests=>", function () {
    var scope;
    var $ctrlCreator;
    var eventServiceFactory;
    var httpMock;
    beforeEach(module("eventModule"));
    beforeEach(inject(function ($controller, $rootScope, EventService, $httpBackend) {
        $ctrlCreator = $controller;
        scope = $rootScope.$new();
        eventServiceFactory = EventService;
        httpMock = $httpBackend;
       
    }));
   

    //Event Controller Testing
    it("It Should have four talks", function() {
        $ctrlCreator("eventController", { $scope: scope, EventService: eventServiceFactory });
        expect(scope.smpleTalkList.length).toBe(4);
    });

   
    //Event Service Testing
    it("EventService getTalks should return four talks", function () {
        var talks;
        debugger;
      
        // Setting the mock up mock http response
        httpMock.expect("GET", "/Events/GetTalkDetails")
            .respond(200, [
                { id: '1001', name: 'Real Time Web Applications with SignalR', speaker: 'Brij Bhushan Mishra', venue: 'Hall 1', duration: '45' },
                { id: '1002', name: 'Power of Node.js', speaker: 'Dhananjay Kumar', venue: 'Hall 2', duration: '75' },
                { id: '1003', name: 'Getting started with AngularJS', speaker: 'Brij Bhushan Mishra', venue: 'Hall 1', duration: '60' },
                { id: '1004', name: 'Microsoft Azure - Your cloud destination', speaker: 'Gaurav mantri', venue: 'Hall 1', duration: '45' }
            ]);
        // calling service
        eventServiceFactory.getTalks().then(function (response) {
            talks = response;
        });

        //Flushing http backend
        httpMock.flush();

        //Verification
        expect(talks.length).toBe(4);
    });
});

//Filter Test
describe("Filter Tests=>", function() {
    var filter;
    beforeEach(module('eventModule'));
    beforeEach(inject(function(_$filter_) {
        filter = _$filter_;
    }));
    it("If the number is formatted", function() {
        var phoneFilter = filter("ConvertPhone");
        expect(phoneFilter('1234567891')).toEqual('(123) 456-7891');
    });
});


//Directive Test
describe("Directive Test=>", function() {
    var compileService, rootScope;
    beforeEach(module("eventModule"));

    // Store references to $compile and $rootScope so they can
    // be uses in all tests in this describe block

    beforeEach(inject(function(_$compile_, _$rootScope_) {
        compileService = _$compile_;
        rootScope = _$rootScope_;
        
        rootScope.talk = "MEAN Stack";
    }));

    it("Attr Custom Directive defined", function() {
        var compiledDirective = compileService(angular.element("<attr:Custom:Directive/>"))(rootScope);
        rootScope.$digest();
        expect(compiledDirective).toBeDefined();
    });

    it("Attr Custom renders proper html", function() {
        var compiledDirective = compileService(angular.element("<attr:Custom:Directive/>"))(rootScope);
        rootScope.$digest();
        compiledDirective.isolateScope().talkname = "The talk name is MEAN Stack";
        expect(compiledDirective.html()).toContain("The talk name is MEAN Stack")
    });
});