$(document).ready(function () {

    GetStudentsSummary().then((response) => {
        if (response.result) {
            var name;
            var subject;
            var grade;
            var totalPoints=0;
            var status;
            var appendTr = '<tr id="trName"></tr>';
            var openingTr = '<tr>';
            var closingTr = '</tr>';
            var htmlToPrint = '';
            var isNamePublished = true;
            for (var i = 0; i < response.result.length; i++) {
                totalPoints = 0;
                status = response.result[i].Status;
                if (response.result[i].Result.length > 0) {
                    for (var z = 0; z < response.result[i].Result.length; z++) {
                        appendTr = $.parseHTML(appendTr);
                        grade = response.result[i].Result[z].Grade;
                        subject = response.result[i].Result[z].Subject.SubjectName;
                        totalPoints = totalPoints + parseInt(response.result[i].Result[z].Grades);
                        if (isNamePublished) {
                            name = response.result[i].FirstName + ' ' + response.result[i].Surname;
                            appendTr[0].append('<td rowspan="3">' + name + '</td>');
                            appendTr[0].append('<td >' +  subject + '</td>');
                            appendTr[0].append('<td >' +  grade + '</td>');
                            appendTr[0].append('<td rowspan="3" >' + 'xxtotalPointsxx' + '</td>');
                            appendTr[0].append('<td rowspan="3" >' + 'xxstatusxx' + '</td>');
                            isNamePublished = false;
                            htmlToPrint = htmlToPrint.concat(openingTr) + appendTr[0].innerText + closingTr;
                        } else {
                            console.log(isNamePublished);
                            var appendRemainingSubjects = '<tr></tr>';
                            appendRemainingSubjects = $.parseHTML(appendRemainingSubjects);
                            appendRemainingSubjects[0].append('<td >' + subject + '</td>');
                            appendRemainingSubjects[0].append('<td >' + grade + '</td>');
                            htmlToPrint = htmlToPrint + openingTr + appendRemainingSubjects[0].innerText + closingTr;
                            if (z == 2) {
                                isNamePublished = true;
                                appendTr = '<tr id="trName"></tr>';
                                htmlToPrint = htmlToPrint.replace('xxtotalPointsxx', totalPoints);
                                if (i > 15) {
                                    htmlToPrint = htmlToPrint.replace('xxstatusxx', '-');
                                } else {
                                    var Status = CalculateStatus(totalPoints);
                                    htmlToPrint = htmlToPrint.replace('xxstatusxx', Status);
                                }
                            }
                        }

                    }
                }


            }
            console.log(htmlToPrint);
            $("#table > tbody").append(htmlToPrint);
            
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

function CalculateStatus(totalPoints) {
    var status = 'Waiting';
    if (totalPoints < 10) {
        status = 'Rejected';
    }
    if (totalPoints > 10) {
        status = 'Approved';
    }

    return status;

}


