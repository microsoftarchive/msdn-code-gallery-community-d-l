$(function () {
    function myViewModel(firstName, lastName, email) {
        this.txtFirstName = ko.observable(firstName).extend({ required: true });
        this.txtLastName = ko.observable(lastName).extend({ required: false });
        this.txtEmail = ko.observable(email).extend({ email: true });
    };
    ko.applyBindings(new myViewModel("Sibeesh", "Venu", "sibikv4u@gmail.com"));
});

