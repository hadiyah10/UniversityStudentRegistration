$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
});


function signIn() {
    var email = $("#email").val(); // read email address input
    var password = $("#password").val(); // read password input
    // create object to map LoginModel
    var authObj = { Email: email, Password: password };

    sendData(authObj).then((response) => {
        if (response.result) {
            toastr.success("Authentication Succeed. Redirecting to relevent page.....");
            setTimeout(redirect, 2000);
        }
        else {
            toastr.error('Incorrect Credentials');
            return false;
        }
    })
        .catch((error) => {
            toastr.error('Unable to make request!!');
        });
}

function sendData(userCredential) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Login/Authentication",
            data: userCredential,
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


//Instead of using jquery ajax 

/* function postData(userCredential) {
    var url = "/Login/Authenticate";
    var request = mew XMLHttpRequest(); 

    request.open("POST", url, false);
    request.setRequestHeader("Content-Type", "application/json");
    request.onreadystatechange = function () {
        if (request.readyState == XMLHttpRequest.DONE) {
            var response = JSON.parse(request.responseText);
            if (response.result) {
                toastr.success("Authentication Succeed. Redirecting to relevant page....")
                window.location = response.url;
            }

            else {
                toastr.error("Unable to authenticate user");
                return false;
            }
        }
    }; 

    request.send(userCredential);
} */

function redirect() {
    window.location.href = "/Home/HomePage";
}