// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />  
var app;

(function () {
    app = angular.module("OrderModule", ['ngAnimate']);
})();


app.controller("AngularJsOrderController", function ($scope,$sce, $timeout, $rootScope, $window, $http) {
    $scope.date = new Date();
    $scope.MyName = "shanu";

    //For Order Master Search 
    $scope.ToyType = "";
    $scope.ToyName = "";

    // 1) Item List Arrays.This arrays will be used to display .
    $scope.itemType = [];
    $scope.ColNames = [];

    // 2) Item List Arrays.This arrays will be used to display .
    $scope.items = [];  
    $scope.ColMonths = [];

 

    // To get all details from Database
    selectToySalesDetails($scope.ToyType, $scope.ToyName);

    // To get all details from Database
    function selectToySalesDetails(ToyType, ToyName) {
     
        $http.get('/api/Toy/', { params: { ToyType: ToyType, ToyName: ToyName } }).success(function (data) {          
            $scope.ToyDetails = data;
            if ($scope.ToyDetails.length > 0) {
                //alert($scope.ToyDetails.length);
                var uniqueMonth = {},uniqueToyName = {}, i;
                
                for (i = 0; i < $scope.ToyDetails.length; i += 1) {
                    // For Column wise Month add
                    uniqueMonth[$scope.ToyDetails[i].Month] = $scope.ToyDetails[i];

                    //For column wise Toy Name add
                    uniqueToyName[$scope.ToyDetails[i].ToyName] = $scope.ToyDetails[i];
                }
                // For Column wise Month add
                for (i in uniqueMonth) {
                    $scope.ColMonths.push(uniqueMonth[i]);
                }

                // For Column wise ToyName add
                for (i in uniqueToyName) {
                    $scope.ColNames.push(uniqueToyName[i]);
                }
               
                // To disply the  Month wise Pivot result
                $scope.getMonthDetails();

           
                // To disply the  Month wise Pivot result
                $scope.getToyNameDetails();
            }
        })
   .error(function () {
       $scope.error = "An Error has occured while loading posts!";
   });
    }

    //Search
    $scope.searchToySales = function () {
        // 1) Item List Arrays.This arrays will be used to display .
        $scope.itemType = [];
        $scope.ColNames = [];

        // 2) Item List Arrays.This arrays will be used to display .
        $scope.items = [];
        $scope.ColMonths = [];

        selectToySalesDetails($scope.ToyType, $scope.ToyName);
    }


    // ** 1) Pivot Month Display

    // To Display Toy Details as Toy Name Pivot Cols   
    $scope.getToyNameDetails = function () {

        var UniqueItemName = {}, i

        for (i = 0; i < $scope.ToyDetails.length; i += 1) {

            UniqueItemName[$scope.ToyDetails[i].ToyType] = $scope.ToyDetails[i];
        }
        for (i in UniqueItemName) {

            var ItmDetails = {
                ToyType: UniqueItemName[i].ToyType
            };
            $scope.itemType.push(ItmDetails);
        }
    }

    // To Display Toy Details as Toy Name wise Pivot Price Sum calculate 
    $scope.showToyItemDetails = function (colToyType, colToyName) {
     
        $scope.getItemPrices = 0;
      
        for (i = 0; i < $scope.ToyDetails.length; i++) {
            if (colToyType == $scope.ToyDetails[i].ToyType) {
                if (colToyName == $scope.ToyDetails[i].ToyName) {

                        $scope.getItemPrices = parseInt($scope.getItemPrices) + parseInt($scope.ToyDetails[i].Price);                 
                 
             }
            }
        }
        if (parseInt($scope.getItemPrices) > 0)
            {
            return $sce.trustAsHtml("<font color='red'><b>" + $scope.getItemPrices.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b></font>");
        }
        else
        {
            return $sce.trustAsHtml("<b>" + $scope.getItemPrices.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b>");
        }
    }

    // To Display Toy Details as Toy Name wise Pivot Column wise Total
    $scope.showToyColumnGrandTotal = function (colToyType, colToyName) {

        $scope.getColumTots = 0;
       
        for (i = 0; i < $scope.ToyDetails.length; i++) {
            if (colToyType == $scope.ToyDetails[i].ToyType) {
                $scope.getColumTots = parseInt($scope.getColumTots) + parseInt($scope.ToyDetails[i].Price);
            }
        }
        return $sce.trustAsHtml("<font color='#203e5a'><b>" + $scope.getColumTots.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b></font>");
    }


    // To Display Toy Details as Month wise Pivot Row wise Total
    $scope.showToyRowTotal = function (colToyType, colToyName) {

        $scope.getrowTotals = 0;

        for (i = 0; i < $scope.ToyDetails.length; i++) {
            if (colToyName == $scope.ToyDetails[i].ToyName) {
                $scope.getrowTotals = parseInt($scope.getrowTotals) + parseInt($scope.ToyDetails[i].Price);
            }
        }
        return $sce.trustAsHtml("<font color='#203e5a'><b>" + $scope.getrowTotals.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b></font>");
    }

    // To Display Toy Details as Month wise Pivot Row & Column Grand Total
    $scope.showToyGrandTotals = function (colToyType, colToyName) {
        $scope.getGrandTotals = 0;
        if ($scope.ToyDetails && $scope.ToyDetails.length) {
            for (i = 0; i < $scope.ToyDetails.length; i++) {
                $scope.getGrandTotals = parseInt($scope.getGrandTotals) + parseInt($scope.ToyDetails[i].Price);
            }
        }
        return $sce.trustAsHtml("<b>" + $scope.getGrandTotals.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b>");
    }

    // ** 1) End

    // ** 2) Pivot Month Display

    // To Display Toy Details as Month wise Pivot 
    $scope.getMonthDetails = function () {
        var UniqueItem = {}, i
        for (i = 0; i < $scope.ToyDetails.length; i += 1) {
            UniqueItem[$scope.ToyDetails[i].ToyName] = $scope.ToyDetails[i];

        }
        for (i in UniqueItem) {

            var ItmDetails = {
                ToyType: UniqueItem[i].ToyType,
                ToyName: UniqueItem[i].ToyName,
                ImageName: UniqueItem[i].ImageName
            };
            $scope.items.push(ItmDetails);
        }
    }

    
    // To Display Toy Details as Month wise Pivot Price Sum calculate 
    $scope.showMonthItemDetails = function (colToyName, colMonthName) {
        $scope.getItemPrice = 0;        
        $scope.monthCount = 0;
        for (i = 0; i < $scope.ToyDetails.length; i++) {
         if (colToyName == $scope.ToyDetails[i].ToyName) {
                if (colMonthName == $scope.ToyDetails[i].Month) {
                  
                    if ($scope.monthCount > 0) {
                        $scope.getItemPrice = parseInt($scope.getItemPrice) + parseInt($scope.ToyDetails[i].Price);
                    }
                    else
                    {
                        $scope.getItemPrice = parseInt($scope.ToyDetails[i].Price);
                    }
                    $scope.monthCount = $scope.monthCount + 1;
                    //  alert($scope.getItemPrice);
                }
            }
        }
          return $sce.trustAsHtml("<b>"+$scope.getItemPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") +"</b>");
    }

    // To Display Toy Details as Month wise Pivot Column wise Total
    $scope.showMonthColumnGrandTotal = function (colToyName, colMonthName) {

        $scope.getColumTot = 0;
        $scope.monthCount = 0;
        for (i = 0; i < $scope.ToyDetails.length; i++) {
            if (colToyName == $scope.ToyDetails[i].ToyName) {
                $scope.getColumTot = parseInt($scope.getColumTot) + parseInt($scope.ToyDetails[i].Price);
            }
        }
        return $sce.trustAsHtml("<b>" + $scope.getColumTot.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b>");
    }
    // To Display Toy Details as Month wise Pivot Row wise Total
    $scope.showMonthRowTotal = function (colToyName, colMonthName) {

        $scope.getrowTotal = 0;
     
        for (i = 0; i < $scope.ToyDetails.length; i++) {

                if (colMonthName == $scope.ToyDetails[i].Month) {                  
                     $scope.getrowTotal = parseInt($scope.getrowTotal) + parseInt($scope.ToyDetails[i].Price); 
            }
        }
        return $sce.trustAsHtml("<b>" + $scope.getrowTotal.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b>");
    }

    // To Display Toy Details as Month wise Pivot Row & Column Grand Total
    $scope.showMonthGrandTotals = function (colToyName, colMonthName) {

        $scope.getGrandTotal = 0;
        if ($scope.ToyDetails && $scope.ToyDetails.length) {
            for (i = 0; i < $scope.ToyDetails.length; i++) {
                $scope.getGrandTotal = parseInt($scope.getGrandTotal) + parseInt($scope.ToyDetails[i].Price);
            }
        }
        return $sce.trustAsHtml("<b>" + $scope.getGrandTotal.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "</b>");
    }

    // ** 2) End of Pivot Month Display
        
});