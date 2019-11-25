(function () {
    'use strict';

    angular
        .module('kiksApp')
        .factory('ContactService', ContactService);

    ContactService.$inject = ['$resource', '$q', '$http'];

    function ContactService($resource, $q, $http) {
        var resource = $resource('/api/Contacts/:action/:param', { action: '@action', param: '@param'}, {
            'update': { method: 'PUT' }
        });

        var _getContacts = function () {
            var deferred = $q.defer();
            resource.query({ action: "get", param: ""},
				function (result) {
				    if (result == null) {
				        result = [];
				    };
				    deferred.resolve(result);
				},
				function (response) {
				    deferred.reject(response);
				});
            return deferred.promise;

        };

        var _getContactById = function (contactId) {
            var deferred = $q.defer();
            resource.query({ action: 'ById', param: contactId},
				function (result) {
				    if (result == null) {
				        result = [];
				    };

				    deferred.resolve(result);
				},
				function (response) {
				    deferred.reject(response);
				});
            return deferred.promise;
        };

        var _addContact = function (contactDto) {
            var deferred = $q.defer();

            $http.post('/api/Contacts', contactDto)
                .then(function (result) {
                        deferred.resolve(result);
                    },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _updateContact = function (contactDto) {
            var deferred = $q.defer();

            $http.put('/api/Contacts/' + contactDto.id, contactDto)
                .then(function (result) {
                    deferred.resolve(result);
                },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _deleteContact = function (contactId) {
            var deferred = $q.defer();

            resource.delete({ action: "", param: contactId},
                    function (result) {
                        if (result == null) {
                            result = [];

                        };
                        deferred.resolve(result);
                    },
                    function (response) {
                        deferred.reject(response);
                    });
            return deferred.promise;
        };

        return {
            getContacts: _getContacts,
            getContactById: _getContactById,
            addContact: _addContact,
            updateContact: _updateContact,
            deleteContact: _deleteContact
        };

    }

})();