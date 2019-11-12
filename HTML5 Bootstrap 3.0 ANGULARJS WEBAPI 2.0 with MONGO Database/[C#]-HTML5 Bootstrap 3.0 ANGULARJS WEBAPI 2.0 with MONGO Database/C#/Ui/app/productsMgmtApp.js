var productsmgmtApp = angular.module('productsmgmtApp', ['ngRoute']);

productsmgmtApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/addproduts', {
            templateUrl: '/templates/products.html',
            controller: 'AddProductController'
        }).
        otherwise({
            redirectTo: '/addproduts'
        });
  }]);