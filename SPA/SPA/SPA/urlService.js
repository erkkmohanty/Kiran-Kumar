(function (app) {
    "use strict";

    app.provider("urlService", urlServiceProvider);
    function urlServiceProvider() {
        var url = '';
        this.setUrl = function (url) {
            this.url = url;
        }
        this.$get = function () {
            return { url: this.url };
        }
    }
})(angular.module("rootModule"));