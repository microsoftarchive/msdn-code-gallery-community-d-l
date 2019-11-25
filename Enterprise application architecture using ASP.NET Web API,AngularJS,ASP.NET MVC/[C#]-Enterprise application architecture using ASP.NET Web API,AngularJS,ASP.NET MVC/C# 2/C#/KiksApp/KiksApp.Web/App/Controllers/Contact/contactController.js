(function () {
    'use strict';

    angular
        .module('kiksApp')
        .controller('ContactController', ContactController);

    ContactController.$inject = ['$scope', '$q', 'ContactService', 'errorHandler', '$modal'];

    function ContactController($scope, $q, ContactService, errorHandler, $modal) {
        (function startup() {
            var contacts = ContactService.getContacts();

            $q.all([
                contacts
            ]).then(function (data) {
                if (data != null) {
                    $scope.contacts = data[0];
                }
            }, function (reason) {
                errorHandler.logServiceError('ContactController', reason);
            }, function (update) {
                errorHandler.logServiceNotify('ContactController', update);
            });
        })();

        function removeContact(contactId) {
            for (var i = 0; i < $scope.contacts.length; i++) {
                if ($scope.contacts[i].id == contactId) {
                    $scope.contacts.splice(i, 1);
                    break;
                }
            }
        };

        $scope.contacts = [];

        $scope.Commands = {
            saveContact: function (contact) {
                ContactService.addContact(contact).then(
                    function (result) {
                        $scope.contacts.push(result.data);
                    },
                    function (response) {
                        console.log(response);
                    });
            },
            updateContact: function (contact) {
                ContactService.updateContact(contact).then(
                    function (result) {

                    },
                    function (response) {
                        console.log(response);
                    });
            }
        };

        $scope.Queries = {
            getContacts: function () {
                ContactService.getContacts();
            },
            getContactById: function (contactId) {
                ContactService.getContactById(contactId);
            }
        };

        $scope.Modals = {
            open: function (contact) {
                $scope.contact = contact;

                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/App/Templates/Contact/ContactFormModal.html',
                    controller: 'ContactFormModalController',
                    size: 'lg',
                    scope: $scope,
                    backdrop: 'static'
                });

                modalInstance.result.then(
                    function (contact) {
                        if (contact.id != null) {
                            $scope.Commands.updateContact(contact);
                        }
                        else
                        {
                            $scope.Commands.saveContact(contact);
                        }
                    },
                    function (event) {

                    });
            },
            deleteContact: function (contactId) {
                if (confirm('Are you sure you want to delete this contact?')) {
                    ContactService.deleteContact(contactId).then(
                        function (data) {
                            removeContact(contactId);
                        },
                        function (response) {
                            console.log(response);
                        });
                }
                else {
                    console.log('delete cancelled');
                }
            }
        }
    };
})
();