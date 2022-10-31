$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});


function register() {
    var name = $("#name").val(); 
    var surname = $("#surname").val();   
    var address = $("#address").val();
    var phone = $("#phone").val(); 
    var guardian = $("#guardian").val(); 
    var email = $("#email").val(); 
    var password = $("#password").val();
    var NID = $("#NID").val();  
    var date = $("#date").val();

    var regEx = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/; 
   
    var errorMessages = [];
    if (name.length == 0) {
        errorMessages.push("You must enter your name.");
    } 

    else if
    (!/^[A-Za-z\s]+$/.test(name)) {
        errorMessages.push("Name must not contain numerical values.");
    }

    if (surname.length == 0) {
        errorMessages.push("You must enter your surname.");
    }

    else if
        (!/^[A-Za-z\s]+$/.test(surname)) {
        errorMessages.push("Surname must not contain numerical values.");
    }

    if (address.length == 0) {
        errorMessages.push("You must enter your address.");
    }
    if (phone.length == 0) {
        errorMessages.push("You must enter your phone.");
    }

    else if
        (phone.length != 8) {
        errorMessages.push("Phone number must be of 8 digits");
    }
 
    else if (isNaN(parseInt(phone))) {
        errorMessages.push("Phone must contain only numbers.");
    }
    
    if (guardian.length == 0) {
        errorMessages.push("You must enter your guardian.");
    }
    if (!isNaN(parseInt(guardian))) {
        errorMessages.push("Guardian name must not contain numerical values.");
    }
    if (email.length == 0) {
        errorMessages.push("You must enter your email.");
    }

    else if (!regEx.test(email)) {
        errorMessages.push("Email is in an incorrect format");
    } 

    if (password.length == 0) {
        errorMessages.push("You must enter your password.");
    }
    if (password.length < 6) {
        errorMessages.push("You must enter a password with more than 6 characters.");
    }
    if (NID.length == 0) {
        errorMessages.push("You must enter your NID.");
    }
    if (date.length == 0) {
        errorMessages.push("You must enter your date of birth.");
    }

    // create object to map LoginModel
    var studentObj = {
        FirstName: name, Surname: surname, Address: address, PhoneNumber: phone, GuardianName: guardian,
        Email: email, Password : password, NationalId: NID, DateOfBirth : date
    };

    if (errorMessages.length == 0) {
        sendData(studentObj).then((response) => {
            if (response.result) {
                toastr.success("Authentication Succeed. Redirecting to relevent page.....");
                setTimeout(redirect, 3000);
                

            }
            else {
                toastr.error('Unable to Register user');
                return false;
            }
        })
            .catch((error) => {
                toastr.error('Unable to make request!!');
            });
    } else {
        for (var i = 0; i < errorMessages.length; i++) {
            toastr.error(errorMessages[i]);
        }
        
    }
    
}

function sendData(student) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Register/CreateStudent",
            data: student,
            dataType: "json",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}

function redirect() {
    window.location.href = "/Login/Login";
}