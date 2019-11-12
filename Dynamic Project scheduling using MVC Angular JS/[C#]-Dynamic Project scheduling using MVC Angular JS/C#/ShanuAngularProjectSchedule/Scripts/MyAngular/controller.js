// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   


var app;


(function () {
    app = angular.module("RESTClientModule", ['ngAnimate']);
})();


app.controller("AngularJs_studentsController", function ($scope, $timeout, $rootScope, $window, $http) {
    $scope.date = new Date();
    $scope.projectId = "";
 

    selectScheduleDetails($scope.projectId);

    function selectScheduleDetails(projectId) {

        $http.get('/api/schedule/projectScheduleSelect/', { params: { projectId: projectId } }).success(function (data) {
            $scope.Schedules = data;
           
            if ($scope.Schedules.length > 0) {
           
            }
        })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
   });
    }


    //Search
    $scope.searchScheduleDetails = function () {

        selectScheduleDetails($scope.projectId);
    }

  

});