$(function () {
    ko.extenders.isRequired = function (elm, customMessage) {

        //add some sub-observables to our observable
        elm.hasError = ko.observable();
        elm.message = ko.observable();

        //This is the function to validate the value entered in the text boxes

        function validateValueEntered(valEntered) {
            elm.hasError(valEntered ? false : true);
            //If the custom message is not given, the default one is taken
            elm.message(valEntered ? "" : customMessage || "I am required :( ");
        }

        //Call the validation function for the initial validation
        validateValueEntered(elm());

        //Validate the value whenever there is a change in value
        elm.subscribe(validateValueEntered);

        return elm;
    };

    ko.extenders.isEmail = function (elm, customMessage) {

        //add some sub-observables to our observable
        elm.hasError = ko.observable();
        elm.message = ko.observable();

        //This is the function to validate the value entered in the text boxes

        function validateEmail(valEntered) {
            var emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            //If the value entered is a valid mail id, return fals or return true
            elm.hasError((emailPattern.test(valEntered) === false) ? true : false);
            //If not a valid mail id, return custom message
            elm.message((emailPattern.test(valEntered) === true) ? "" : customMessage);
        }

        //Call the validation function for the initial validation
        validateEmail(elm());

        //Validate the value whenever there is a change in value
        elm.subscribe(validateEmail);

        return elm;
    };

    function myViewModel(firstName, lastName, email) {
        this.txtFirstName = ko.observable(firstName).extend({ isRequired: "You missed First Name" });
        this.txtLastName = ko.observable(lastName).extend({ isRequired: "" });
        this.txtEmail = ko.observable(email).extend({ isEmail: "Not a valid mail id" });
    };
    ko.applyBindings(new myViewModel("Sibeesh", "Venu", "sibikv4u@gmail.com"));
});

