﻿$(document).ready(function () {
    GetAllSubjects().then((response) => {
        if (response.result) {
            for (var i = 0; i < response.result.length; i++) {
                for (var y = 1; y < 4; y++) {
                    $('.subjectDetails'+y).append($('<option>', {
                        value: response.result[i].SubjectId,
                        text: response.result[i].SubjectName
                    }));
                }
            }
        }
        else {
            toastr.error('Incorrect Credentials');
            return false;
        }
    }).catch((error) => {
        toastr.error('Unable to retrieve subjects from database!');
        console.error(error);
    });   


    $("#next").click(function () { 
        var resultList = [];
        for (var y = 1; y < 4; y++) { 
            var subjectValue = $('.subjectDetails'+y + ' :selected').val(); 
            var gradeValue = $('.gradeDetails'+y + ' :selected').val(); 
            const result = { SubjectId: subjectValue, Grade: gradeValue, StudentId : null};
            resultList.push(result);
        }

        CreateResult(resultList).then((response) => {
            if (response.result) {
               toastr.success('Result Created Successfully')
            }
            else {
                toastr.error('Unable to create result');
                return false;
            }
        }).catch((error) => {
            toastr.error('Unable to create result!');
            console.error(error);
        });   

    }); 

});

function CreateResult(resultList) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Register/CreateResult",
            data: JSON.stringify(resultList),
            dataType: 'application/json',
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}

function GetAllSubjects() {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Register/GetSubjects",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}