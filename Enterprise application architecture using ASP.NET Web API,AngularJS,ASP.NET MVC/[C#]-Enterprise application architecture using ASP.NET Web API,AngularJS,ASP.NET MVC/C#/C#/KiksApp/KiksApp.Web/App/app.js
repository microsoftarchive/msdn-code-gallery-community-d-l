(function () {
    'use strict';

    angular.module('kiksApp', [
        'ngAnimate', 'ngCookies', 'ngResource', 'ngRoute', 'ngSanitize', 'ngTouch', 'ui.bootstrap'
    ])
    .config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('xmlHttpInteceptor');
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
    }]);

    function errorHandler(status, message) {
        var scope = angular.element($('html')).scope();
        scope.errorHandler(status, message);
    };
})();
