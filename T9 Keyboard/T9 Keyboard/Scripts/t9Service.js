(function (app) {
    'use stric';

    app.factory('numericKeyboardService', numericKeyboardService);

    function numericKeyboardService() {
        var model = null;
        var opened = false;
        var maxLength = null;
        var getterSetter = null;
        var doneEditing = false;

        var service = {
            setModel: setModel,
            clear: clear,
            setModelValue: setModelValue,
            isDone: isDone,
            done: done,
            append: append,
            getModel: getModel,
            open: open,
            isOpened: isOpened,
            close: close,
            maxLength: setMaxLength,
            getterSetter: setGetterSetter
        };

        return service;

        function setModel(newModel) {
            debugger;
            model = newModel;
        }

        function clear() {
            debugger;
            model.$viewValue = "";
            model.$render();
        }

        function setModelValue() {
            debugger;
            doneEditing = true;
            if (model.$viewValue === "") {
                model.$rollbackViewValue();
                return;
            }
            if (getterSetter) {
                model.$viewValue = getterSetter({ newValue: model.$viewValue });
                model.$commitViewValue();
                return;
                // scope.ngBind = model.$viewValue;
            }
            model.$commitViewValue();

        }
        function isDone() {
            debugger;
            return doneEditing;
        }
        function done() {

            this.setModelValue();
            this.close();
        }

        function append(key) {
            debugger;
            if (maxLength) {
                if (model.$viewValue.length >= maxLength) {
                    return;
                }
            }
            model.$viewValue += key;
            model.$render();
        }

        function getModel() {
            debugger;
            return model.$viewValue;
        }

        function open() {
            debugger;
            maxLength = null;
            doneEditing = false;
            model = "";
            getterSetter = null;
            opened = true;
        }

        function isOpened() {
            debugger;
            return opened;
        }
        function close() {
            debugger;
            opened = false;
        }
        function setMaxLength(max) {
            debugger;
            maxLength = max;
        }
        function setGetterSetter(GS) {
            debugger;
            getterSetter = GS;
        }
    }
})(angular.module("t9Module"));