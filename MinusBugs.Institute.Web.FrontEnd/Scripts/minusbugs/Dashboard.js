$(function () {

    // var mo1, mo2, mo3, mo4, mo5, mo6, mo7, mo8, mo9, mo10, mo11, mo12;

    $.ajax({
        type: 'POST',
        url: '/Courses/LoadGraph',
        data: null,
        success: function (data) {
            var result = jQuery.parseJSON(data);



            mo1 = result[0].January;
            mo2 = result[0].February;
            mo3 = result[0].March;
            mo4 = result[0].April;
            mo5 = result[0].May;
            mo6 = result[0].June;
            mo7 = result[0].July;
            mo8 = result[0].August;
            mo9 = result[0].September;
            mo10 = result[0].October;
            mo11 = result[0].November;
            mo12 = result[0].December;

            var lineData = {
                labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                datasets: [
                    {
                        label: "Example dataset",
                        fillColor: "rgba(26,179,148,0.5)",
                        strokeColor: "rgba(220,220,220,1)",
                        pointColor: "rgba(220,220,220,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(220,220,220,1)",
                        data: [mo1, mo2, mo3, mo4, mo5, mo6, mo7, mo8, mo9, mo10, mo11, mo12]
                    },
                    {
                        label: "Example dataset",
                        fillColor: "rgba(26,179,148,0.5)",
                        strokeColor: "rgba(26,179,148,0.7)",
                        pointColor: "rgba(26,179,148,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(26,179,148,1)",
                        data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
                    }
                ]
            };

            var lineOptions = {
                scaleShowGridLines: true,
                scaleGridLineColor: "rgba(0,0,0,.05)",
                scaleGridLineWidth: 1,
                bezierCurve: true,
                bezierCurveTension: 0.4,
                pointDot: true,
                pointDotRadius: 4,
                pointDotStrokeWidth: 1,
                pointHitDetectionRadius: 20,
                datasetStroke: true,
                datasetStrokeWidth: 2,
                datasetFill: true,
                responsive: true,
            };


            var ctx = document.getElementById("lineChart").getContext("2d");
            var myNewChart = new Chart(ctx).Line(lineData, lineOptions);

        }


    });

    $(".bar_dashboard").peity("bar", {
        fill: ["#1ab394", "#d7d7d7"],
        width: 100

    });
    getMonthlyIncome()
    getPendingFees();
   
    getExpense();
});

function getExpense() {
    $.ajax({
        type: 'POST',
        url: '/Expense/GetMonthlyExpense',
        data: null,
        success: function (data) {

            var result = jQuery.parseJSON(data);
            $("#lblexpense").text(result);

        }

    });
}
function getMonthlyIncome() {
    $.ajax({
        type: 'POST',
        url: '/Payment/GetMonthlyCollection',
        data: null,
        success: function (data) {
            //var result = jQuery.parseJSON(data);
            //    alert(data);
            $("#monthlyincome").text(data);
        }
    });
}


function getPendingFees() {
    $("#pfList").empty();
    $.ajax({
        type: 'POST',
        url: '/Payment/GetPendFeeList',
        data: null,
        success: function (data) {
            $.each($.parseJSON(data), function (idx, obj) {

                $("#pfList").append(" <li class='list-group-item'><p><a class='text-info' href='#'>" + obj.StudentName + "</a> scheduled an amount of Rs " + obj.Amount + " for the course " + obj.CourseName + "</p><small class='block text-muted'><i class='fa fa-clock-o'></i>" + obj.SchDate + "</small></li>");


            });

        }
    });

}