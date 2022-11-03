$(document).ready(function () {
    GetAllResults().then((response) => {
        if (response) {
            console.log(response);
            var openingTag = '<tr>';
            var closingTag = '</tr>';
            var html = '';
            for (var i = 0; i < response.length; i++) {
                html = html + openingTag + '<td>' + response[i].SubjectName + '</td>';
                html = html  + '<td>' + response[i].Grade + '</td>' + closingTag;
            }
            $("#table > tbody").append(html);
        }
        else {
            toastr.error('Incorrect Credentials');
            return false;
        }
    }).catch((error) => {
        toastr.error('Unable to retrieve results from database!');
        console.error(error);
    });
});

function GetAllResults() {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Result/GetResults",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}