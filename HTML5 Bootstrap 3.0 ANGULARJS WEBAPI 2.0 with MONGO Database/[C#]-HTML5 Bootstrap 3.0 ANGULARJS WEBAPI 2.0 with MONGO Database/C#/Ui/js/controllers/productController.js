productsmgmtApp.controller('AddProductController', function ($scope, ProductService) {
    $scope.AddProducts = function () {
        var product = {
            Name: $scope.Name,
            Brand: $scope.Brand,
            Type: $scope.Type
        };
        debugger;
        ProductService.addProduct(product).success(function () {
        }).error(function () { });
    };

    $scope.GetAllProducts = function () {
        $scope.products = [];
        ProductService.getProducts().success(function (response) {
            $scope.products = response;
        }).error(function () { });
    };

    $scope.UpdateProduct = function (product) {
        $scope.UpdateName = product.Name;
        $scope.UpdateBrand = product.Brand;
        $scope.UpdateType = product.Type;
        $('#myModal').modal('show');
    }

    $scope.Update = function (product) {
        debugger;
        var updateProduct = {
            Name: product.UpdateName,
            Brand: product.UpdateBrand,
            Type: product.UpdateType,
            Id: product.Id
        };

        ProductService.update(updateProduct).success(function () {
        }).error(function () { });
    }
});
