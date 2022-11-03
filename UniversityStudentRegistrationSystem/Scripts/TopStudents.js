$(document).ready(function () {
    GetTopStudents().then((response) => {
        if (response.result) {
            var name;
            var subject;
            var grade;
            var totalPoints = 0;
            var status;
            var appendTr = '<tr id="trName"></tr>';
            var openingTr = '<tr>';
            var closingTr = '</tr>';
            var htmlToPrint = '';
            var isNamePublished = true;
            var isApprovedCount = 0;
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
                            appendTr[0].append('<td >' + subject + '</td>');
                            appendTr[0].append('<td >' + grade + '</td>');
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
                                if (i >= 15) {
                                    var Status = CalculateStatus(totalPoints);
                                    if (Status == 'Approved') {
                                        htmlToPrint = htmlToPrint.replace('xxstatusxx', 'Waiting');
                                    }
                                    if (Status == 'Rejected') {
                                        htmlToPrint = htmlToPrint.replace('xxstatusxx', 'Rejected');
                                    }
                                } else {
                                    var Status = CalculateStatus(totalPoints);
                                    if (isApprovedCount > 15) {
                                        htmlToPrint = htmlToPrint.replace('xxstatusxx', 'Waiting');
                                    } else {
                                        if (Status == 'Approved') {
                                            htmlToPrint = htmlToPrint.replace('xxstatusxx', 'Approved');
                                            isApprovedCount++;
                                        }
                                    }
                                    
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
        toastr.error('Unable to retrieve top student  from database!');
        console.error(error);
    });
});

function GetTopStudents() {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "GET",
            url: "/Admin/GetTopStudents",
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
    if (totalPoints >= 10) {
        status = 'Approved';
    }

    return status;

}