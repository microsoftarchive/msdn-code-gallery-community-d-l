userApp.service("userService", function ($http) {
    var $this = this;
    $this.AddEdit = function (user) {
        var request = $http({
            method: 'POST',
            url: Domain + 'AddEditUser',
            data: JSON.stringify(user),
            dataType: "json"
        });
        return request;
    }

    $this.Delete = function (id) {
        var request = $http({
            method: 'POST',
            url: Domain + 'DeleteUser',
            data: "{ id:" + id + " }",
            dataType: "json"
        });
        return request;
    }

    $this.GetAll = function () {
        var request = $http({
            method: 'GET',
            url: Domain + 'GetAllUsers',
        });
        return request;
    }

    $this.GetUser = function (id) {
        var request = $http({
            method: 'GET',
            url: Domain + 'GetUser/' + id,
        });
        return request;
    }
});