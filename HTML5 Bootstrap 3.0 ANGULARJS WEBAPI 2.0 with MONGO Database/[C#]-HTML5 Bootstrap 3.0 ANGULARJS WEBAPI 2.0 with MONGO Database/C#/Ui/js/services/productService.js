productsmgmtApp.service('ProductService', function ($http) {

    var getAllProducts = function () {
        var request = $http({
            method: 'GET',
            cache: false,
            url: 'http://localhost:44366/v1/products/getAllProducts'
        });

        return request;
    };

    var addProducts = function (product) {
        var request = $http({
            method: 'post',
            cache: false,
            url: 'http://localhost:44366/v1/products/addProduct',
            data: product
        });

        return request;
    };

    var updateProducts = function (product) {
        debugger;
        var request = $http({
            method: 'post',
            cache: false,
            url: 'http://localhost:44366/v1/products/updateProduct',
            data: product
        });

        return request;
    };

    return {
        getProducts: getAllProducts,
        addProduct: addProducts,
        update: updateProducts
    };
});