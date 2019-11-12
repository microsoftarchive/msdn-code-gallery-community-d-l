angular.module('myFaceApp', [])
.controller('faceDetectionCtrl', function ($scope, FileUploadService) {

    $scope.Title = 'Microsoft FaceAPI - Face Detection';
    $scope.DetectedResultsMessage = 'No result found!!';
    $scope.SelectedFileForUpload = null;
    $scope.UploadedFiles = [];
    $scope.SimilarFace = [];
    $scope.FaceRectangles = [];
    $scope.DetectedFaces = [];

    //File Select & Save 
    $scope.selectCandidateFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file;
        $scope.loaderMoreupl = true;
        $scope.uplMessage = 'Uploading, please wait....!';
        $scope.result = "color-red";

        //Save File
        var uploaderUrl = "/FaceDetection/SaveCandidateFiles";
        var fileSave = FileUploadService.UploadFile($scope.SelectedFileForUpload, uploaderUrl);
        fileSave.then(function (response) {
            if (response.data.Status) {
                $scope.GetDetectedFaces();
                angular.forEach(angular.element("input[type='file']"), function (inputElem) {
                    angular.element(inputElem).val(null);
                });
                $scope.f1.$setPristine();
                $scope.uplMessage = response.data.Message;
                $scope.loaderMoreupl = false;
            }
        },
        function (error) {
            console.warn("Error: " + error);
        });
    }

    //Get Detected Faces
    $scope.GetDetectedFaces = function () {
        $scope.loaderMore = true;
        $scope.faceMessage = 'Preparing, detecting faces, please wait....!';
        $scope.result = "color-red";

        var fileUrl = "/FaceDetection/GetDetectedFaces";
        var fileView = FileUploadService.GetUploadedFile(fileUrl);
        fileView.then(function (response) {
            $scope.QueryFace = response.data.QueryFaceImage;
            $scope.DetectedResultsMessage = response.data.DetectedResults;
            $scope.DetectedFaces = response.data.FaceInfo;
            $scope.FaceRectangles = response.data.FaceRectangles;
            $scope.loaderMore = false;

            //Reset element
            $('#faceCanvas_img').remove();
            $('.divRectangle_box').remove();

    
            //get element byID
            var canvas = document.getElementById('faceCanvas');

            //add image element
            var elemImg = document.createElement("img");
            elemImg.setAttribute("src", $scope.QueryFace);
            elemImg.setAttribute("width", response.data.MaxImageSize);
            elemImg.id = 'faceCanvas_img';
            canvas.append(elemImg);

            //Loop with face rectangles
            angular.forEach($scope.FaceRectangles, function (imgs, i) {
                //console.log($scope.DetectedFaces[i])
                //Create rectangle for every face
                var divRectangle = document.createElement('div');
                var width = imgs.Width;
                var height = imgs.Height;
                var top = imgs.Top;
                var left = imgs.Left;

                //Style Div
                divRectangle.className = 'divRectangle_box';
                divRectangle.style.width = width + 'px';
                divRectangle.style.height = height + 'px';
                divRectangle.style.position = 'absolute';
                divRectangle.style.top = top + 'px';
                divRectangle.style.left = left + 'px';
                divRectangle.style.zIndex = '999';
                divRectangle.style.border = '1px solid #fff';
                divRectangle.style.margin = '0';
                divRectangle.id = 'divRectangle_' + (i + 1);

                //Generate rectangles
                canvas.append(divRectangle);
            });
        },
        function (error) {
            console.warn("Error: " + error);
        });
    };

    $scope.hoverIn = function () {
        this.hoverEdit = true;
    };
})
.factory('FileUploadService', function ($http, $q) {
    var fact = {};
    fact.UploadFile = function (files, uploaderUrl) {
        var formData = new FormData();
        angular.forEach(files, function (f, i) {
            formData.append("file", files[i]);
        });
        var request = $http({
            method: "post",
            url: uploaderUrl,
            data: formData,
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        });
        return request;
    }
    fact.GetUploadedFile = function (fileUrl) {
        return $http.get(fileUrl);
    }
    return fact;
})