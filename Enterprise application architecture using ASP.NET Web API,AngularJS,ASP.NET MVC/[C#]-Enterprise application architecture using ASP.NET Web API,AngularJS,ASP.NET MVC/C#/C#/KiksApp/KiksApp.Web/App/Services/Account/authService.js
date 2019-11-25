(function () {
    'use strict';

    angular
        .module('kiksApp')
        .factory('AuthService', AuthService);

    AuthService.$inject = ['$q', '$window', 'errorHandler', '$http', 'tokenHandler'];

    function AuthService($q, $window, errorHandler, $http, tokenHandler) {

        var serviceBase = 'http://localhost:8131/';
        var authServiceFactory = {};

        var _saveRegistration = function (registration) {

            return $http.post('/api/account/register', registration)
                .then(function (response) {
                    return response;
                });

        };

        var _login = function (loginData) {
            var deferred = $q.defer();
            var data = "userName=" + loginData.userName + "&password=" + loginData.password + "&grant_type=password";

            $http.post(serviceBase + 'token', data, {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            })
                .success(function (result) {
                    tokenHandler.setLoginToken(result.access_token);
                    tokenHandler.setLoginName(result.userName);

                    deferred.resolve(result);
                })
                .error(function (err, status) {
                    _logOut();

                    deferred.reject(err);
                });

            return deferred.promise;

        };

        var _logOut = function () {
            var deferred = $q.defer();

            $http.post('/api/Account/Logout')
                .success(function (response) {

                    tokenHandler.removeLoginToken();

                    deferred.resolve(response);

                })
                .error(function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var _isAuthenticated = function () {
            return tokenHandler.hasLoginToken();
        }

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.isAuthenticated = _isAuthenticated;

        return authServiceFactory;
    };
})();