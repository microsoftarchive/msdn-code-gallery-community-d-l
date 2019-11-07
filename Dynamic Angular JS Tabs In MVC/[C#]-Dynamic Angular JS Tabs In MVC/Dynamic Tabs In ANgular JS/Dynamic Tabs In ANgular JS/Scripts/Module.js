(function () {
    'use strict';
    var app;
    (function () {
        //create app
        app = angular.module("tab", ['ngMaterial', 'ngMessages', 'material.svgAssetsCache']);
        //create controller
        app.controller('tabController', function ($scope, tabService) {
            var serv = tabService.getAll();
            serv.then(function (d) {
                tabController(d.data, $scope);
            }, function (error) {
                console.log('Something went wrong, please check after a while');
            })
        });
        //create service
        app.service('tabService', function ($http) {
            this.getAll = function () {
               return $http({
                    url: "/Home/TabData", //Here we are calling our controller JSON action
                    method: "GET"
                });
            };
        });
    })();

    function tabController(data, $scope) {
        var tabsArray = [];
        for (var i = 0; i < data.length; i++) {
            tabsArray.push(
                {
                    'title':"Customer ID: "+ data[i].CustomerID,
                    'content': data[i].CustomerCode + " The data you are seeing here is for the customer with the Custome rCode " + data[i].CustomerCode
                });
        }
        var tabs = tabsArray,
            selected = null,
            previous = null;
        $scope.tabs = tabs;
        $scope.selectedIndex = 0;
        $scope.$watch('selectedIndex', function (current, old) {
            previous = selected;
            selected = tabs[current];
        });
        $scope.addTab = function (title, view) {
            view = view || title + " Content View";
            tabs.push({ title: title, content: view, disabled: false });
        };
        $scope.removeTab = function (tab) {
            var index = tabs.indexOf(tab);
            tabs.splice(index, 1);
        };
    }
})();