(function () {
    'use strict';

    angular
        .module('kiksApp')
        .factory('errorHandler', errorHandler);

    errorHandler.$inject = [];

    function errorHandler() {
        var _logError = function (status, message, rejection) {
            if (angular.isUndefined(rejection)) {
                window.console && console.error(status + ': ' + message);
            } else {
                window.console && console.error(status + ': ' + message + ' : ' + JSON.stringify(rejection));
            }
        };

        var _logServiceError = function (controllerName, reason) {
            window.console && console.error(controllerName + ': Unhandled error : ' + JSON.stringify(reason));
        };

        var _logServiceNotify = function (controllerName, update) {
            window.console && console.log(controllerName + ': Notification received : ' + JSON.stringify(update));
        };

        return {
            logError: _logError,
            logServiceError: _logServiceError,
            logServiceNotify: _logServiceNotify
        };
    }
})();