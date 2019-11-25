(function () {
    'use strict';

    angular
        .module('kiksApp')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$scope', '$location', '$timeout', 'AuthService'];

    function RegisterController($scope, $location, $timeout, AuthService) {

        $scope.savedSuccessfully = false;
        $scope.message = "";

        $scope.registration = {
            firstName: "",
            lastName: "",
            email : "",
            userName: "",
            password: ""
        };

        $scope.signUp = function () {

            AuthService.saveRegistration($scope.registration)
                .then(function (response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = {
                        success: true,
                        description: "Registered successfully, you will be redicted to login page shortly"
                    };
                    startTimer();
            },
             function (response) {
                 var errors = [];
                 for (var key in response.data.modelState) {
                     for (var i = 0; i < response.data.modelState[key].length; i++) {
                         errors.push(response.data.modelState[key][i]);
                     }
                 }

                 $scope.message = {
                     success: false,
                     description: "Failed to register user : " + errors.join(' ')
                 };

             });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/Account/Login');
            }, 2000);
        }
    }
})();
