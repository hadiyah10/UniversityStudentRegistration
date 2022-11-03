$(document).ready(function () {
    GetStudentsSummary().then((response) => {
        if (response.result) {
            var name;
            var subject;
            var grade;
            var totalPoints;
            var status;
            var appendTr = '<tr id="trName"></tr>';
            var isNamePublished = true;
            appendTr = $.parseHTML(appendTr);
            for (var i = 0; i < response.result.length; i++) {
                totalPoints = 0;
                status = response.result[i].Status;
                if (response.result[i].Result.length > 0) {
                    for (var z = 0; z < response.result[i].Result.length; z++) {
                        grade = response.result[i].Result[z].Grade;
                        subject = response.result[i].Result[z].SubjectId;
                        if (isNamePublished) {
                            name = response.result[i].FirstName + ' ' + response.result[i].Surname;
                            appendTr[0].append('<td rowspan="3">' + name + '</td>');
                            appendTr[0].append('<td >' + 'subject' + z + '</td>');
                            appendTr[0].append('<td >' + 'grade' + z + '</td>');
                            appendTr[0].append('<td rowspan="3" >' + 'totalPoints' + '</td>');
                            appendTr[0].append('<td rowspan="3" >' + 'status' + '</td>');
                            isNamePublished = false;
                        } else {
                            console.log(isNamePublished);
                            var appendRemainingSubjects = '<tr></tr>';
                            appendRemainingSubjects = $.parseHTML(appendRemainingSubjects);
                            appendRemainingSubjects[0].append('<td >' + 'grade' + z + '</td>');
                            appendRemainingSubjects[0].append('<td >' + 'grade' + z + '</td>');
                            appendTr[0].after(appendRemainingSubjects[0]);
                            if (z = 2) {
                                isNamePublished = true;
                            }
                        }
                        
                    }
                }
                
                
            }
            $("#table > tbody").append(appendTr[0].outerText)
            //$("#table > tbody").append(appendTr[0].toString());
            console.log(JSON.stringify(response));
        }
      
    }).catch((error) => {
        toastr.error('Unable to retrieve student summary from database!');
        console.error(error);
    });
}); 

function GetStudentsSummary() {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Admin/GetStudentsSummary",
            success: function (data) {
                resolve(data)
            },
            error: function (error) {
                reject(error)
            }
        })
    });
}


   