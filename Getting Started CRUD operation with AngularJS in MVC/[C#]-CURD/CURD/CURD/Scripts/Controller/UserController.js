userApp.controller("userController", function ($scope, userService) {

    GetUsers();

    $scope.SaveUser = function () {
        var UserModel = {
            Id: $scope.id,
            Email: $scope.email,
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            Phone: $scope.phone
        };
        if (!CheckIsValid()) {
            alert('Please fill the detail!');
            return false;
        }
        var requestResponse = userService.AddEdit(UserModel);
        Message(requestResponse);
    };

    $scope.editUser = function (id) {
        var getData = userService.GetUser(id);
        getData.then(function (user) {
            var userData = user.data;
            $scope.id = userData.Id;
            $scope.email = userData.Email;
            $scope.phone = userData.Phone;
        },
            function () {
                alert('Error in getting records');
            });
    }

    $scope.DeleteUser = function (id) {
        var requestResponse = userService.Delete(id);
        Message(requestResponse);
    };

    function GetUsers() {
        var requestResponse = userService.GetAll();
        requestResponse.then(function (response) {
            $scope.employees = response.data;
        }, function () {

        })
    };

    function Message(requestResponse) {
        requestResponse.then(function successCallback(response) {
            GetUsers();
            $('#addEditUser').modal('hide');
            // this callback will be called asynchronously
            // when the response is available
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    }

    function CheckIsValid() {
        var isValid = true;
        if ($('#email').val() === '' || $('#phone').val() === '' || $('#email').val() === '' || $('#phone').val() === '') {
            isValid = false;
        }
        return isValid;
    }
});
