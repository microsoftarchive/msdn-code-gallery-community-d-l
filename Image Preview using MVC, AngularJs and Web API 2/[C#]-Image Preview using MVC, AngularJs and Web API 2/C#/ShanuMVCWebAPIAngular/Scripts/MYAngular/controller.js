/// <reference path="../angular.js" />  
/// <reference path="../angular.min.js" />   
/// <reference path="../angular-animate.js" />   
/// <reference path="../angular-animate.min.js" />   


var app;


(function () {
    app = angular.module("RESTClientModule", ['ngAnimate']);
})();


app.controller("AngularJs_ImageController", function ($scope, $timeout, $rootScope, $window, $http, FileUploadService) {
    $scope.date = new Date();
    $scope.MyName = "Shanu";
    $scope.Imagename = "";
    $scope.ShowImage = false;
    $scope.Description = "";
    $scope.AnimationImageName = "1.jpg";
    $scope.ImagesALLVal=[];
    $scope.icountval = 0


    //get all image Details
    $http.get('/api/Image/').success(function (data) {
        $scope.Images = data;    
        if ($scope.Images.length > 0) {
            $scope.onShowImage($scope.Images[0].Image_Path);
        }
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";

    });



    //$scope.showMYANim = function (Image_Path) {
    //    $scope.ShowImage = false;
    //    $scope.AnimationImageName = Image_Path;

    //    $timeout(function () {
    //        $scope.ShowImage = true;
    //    }, 4000);

    //}
    $scope.onShowImage_new = function (Image_Path) {
        $scope.ShowImage = false;
        alert($scope.Images[$scope.icountval].Image_Path);
        $scope.Images[$scope.icountval].Image_Path.visible = true;
        $scope.AnimationImageName = $scope.Images[$scope.icountval].Image_Path.visible;
        $scope.icountval = $scope.icountval + 1;
        $timeout(function () {
            $scope.ShowImage = true;
        }, 2000);

    }

    $scope.onShowImage = function (Image_Path) {
        $scope.ShowImage = false;
        $scope.AnimationImageName = Image_Path
      
        $timeout(function () {
            $scope.ShowImage = true;
        }, 400);
       
    }
    

    //Declarationa and Function for Image Upload and Save Data
    //--------------------------------------------
    // Variables
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription_TR = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;
  
    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });


    // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
    // ------------------------------------------------------------------------------------
    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
          
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (1600 * 1200)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Only JPEG/PNG/Gif Image can be upload )";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
      
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
       
        var files = file[0];
        $scope.Imagename = files.name;
      
        $scope.SelectedFileForUpload = file[0];
      

    }
    //----------------------------------------------------------------------------------------

    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
     
        $scope.Message = "";
      
        $scope.ChechFileValid($scope.SelectedFileForUpload);
    
        if ($scope.IsFormValid && $scope.IsFileValid) {
          
            FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {
               
                var ItmDetails = {
                    Image_Path: $scope.Imagename,
                    Description: $scope.Description
                };
                $http.post('/api/Image/', ItmDetails).success(function (data) {
                    alert("Added Successfully!!");
                    $scope.addMode = false;
                    $scope.Images.push(data);
                    $scope.loading = false;
                }).error(function (data) {
                    $scope.error = "An Error has occured while Adding Customer! " + data;
                    $scope.loading = false;
                });
                alert(d.Message + " Item Saved!");
                $scope.IsFormSubmitted = false;
                ClearForm();

            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }

    };
    //Clear form 
    function ClearForm() {
      
        $scope.Imagename = "";
      
        $scope.Description = "";
     

        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }

})
.factory('FileUploadService', function ($http, $q) {

    var fac = {};
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append("file", file);
  
        var defer = $q.defer();
        $http.post("/Home/UploadFile", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });

        return defer.promise;

    }
    return fac;

    //---------------------------------------------
    //End of Image Upload and Insert record
 
    // This Method IS TO save image name
 

});
