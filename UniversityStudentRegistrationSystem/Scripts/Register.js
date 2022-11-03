/// <reference path="bootstrap.js" />
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

    // create object to map LoginModel
    var studentObj = {
        FirstName: name, Surname: surname, Address: address, PhoneNumber: phone, GuardianName: guardian,
        Email: email, Password : password, NationalId: NID, DateOfBirth : date
    };


    sendData(studentObj).then((response) => {
        console.log(response);
        if (response.Flag) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
            setTimeout(redirect, 3000);
      
        }
        else {
            toastr.error(response.Message);
            return false;
        }
    })
        .catch((error) => {
            toastr.error('Unable to make request!!');
    });
    
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