toastr.options.timeOut = 100000;

function EmailValidation(element) { 
    var emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (element.value.length == 0) {
        toastr.error("You must enter your email.");
    }
    else if (element.value.length < 8 || element.value.length > 50) {
        toastr.error("Incorrect email length");
        $("#emailErr").html("Length must be between 8 and 50");
    }
    else if (!emailRegex.test(element)) {
        toastr.error("Email is in an incorrect format");
    }
    else {
        $("#emailErr").html(""); 
    }
} 

function PasswordValidation(element) {
    if (element.value.length == 0) {
        toastr.error("You must enter your password.");
    }
    else if (element.value.length < 8 && element.value.length > 25) {
        toastr.error("Incorrect password length");
        $("#passwordErr").html("Password legnth must be between 8 and 25");
    }
    else {
        $("#passwordErr").html("");
    }
}

function FnameValidation(element) {
    if (element.value.length == 0) {
        toastr.error("You must enter your first name");
    }
    else if (element.value.length < 2 || element.value.length > 100) {
        toastr.error("Incorrect first name length");
        $("#fnameErr").html("First name length should be between 2 and 100");
    }
    else {
        $("#fnameErr").html("");
    }
} 

function SnameValidation(element) {
    if (element.value.length == 0) {
        toastr.error("You must enter your surname");
    }
    else if (element.value.length < 2 || element.value.length > 100) {
        toastr.error("Incorrect  surname length");
        $("#snameErr").html(" Surname length should be between 2 and 100");
    }
    else {
        $("#snameErr").html("");
    }
}

function NationalIdValidation(element) {
    var minLength = 9;
    var maxLength = 15;
    var NIDRegexCharacter = /^[a-zA-Z0-9]*$/; 
    if (element.value.length == 0) {
        toastr.error("You must enter your National ID");
    } 
    else if (element.value.length < minLength || element.value.length > maxLength) {
        toastr.error("Incorrect NID length"); 
        $("#NIDErr").html("National ID should be between 9 and 15");
    }
    else if (!NIDRegexCharacter.test(element.value)) {
        toastr.error("Invalid NID Format");    
    } 
    else {
        $("#NIDErr").html("");
    }
}

function AddressValidation(element) {
    if (element.value.length == 0) {
        toastr.error("You must enter your Address");
    } 
    else if (element.value.length < 2 || element.value.length > 100) {
        toastr.error("Incorrect Address length"); 
        $("#AddressErr").html("Address length should be between 2 and 100");
    } 
    else {
        $("#AddressErr").html("");
    }
}

function PhoneValidation(element) {
    if (element.value.length == 0) {
        toastr.error("You must enter your Phone Number");
    }
    else if
        (element.value.length != 8) {
        toastr.error("Invalid phone length");
        $("#PhoneErr").html("Phone number should be of 8 digits only"); 
    }
    else if (isNaN(parseInt(element.value))) {
        toastr.error("Phone number must contain numbers only");
    } 
    else {
        $("#PhoneErr").html("");
    }
} 
