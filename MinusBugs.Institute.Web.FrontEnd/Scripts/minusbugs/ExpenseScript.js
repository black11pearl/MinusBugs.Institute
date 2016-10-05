


$(function () {
  
    getGraph();
    getRecentexpenses();

 


    $.ajax({
        type: 'POST',
        url: '/Expense/GetMonthlyExpense',
        data: null,
        success: function (data) {

            var result = jQuery.parseJSON(data);
            $("#lblExpense").text(result);

        }

    });

  


   
    $("#btnWarningClose").click(function () {

        $("#message-box-warning").fadeOut();
    })
    
   





});


function getRecentexpenses() {

    $.ajax({
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            //Upload progress
            xhr.upload.addEventListener("progress1", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#expLoader").fadeIn('slow');

                }
            }, false);
            //Download progress
            xhr.addEventListener("progress1", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#expLoader").fadeIn('slow');

                }
            }, false);
            return xhr;
        },
        type: 'POST',
        url: '/Expense/GetRecentExpenses',
        data: null,
        success: function (data) {
            $("#table_data_expenses").empty();
            var result = jQuery.parseJSON(data);
            $.each($.parseJSON(data), function (idx, obj) {
                $("#table_data_expenses").append("<tr><td>" + obj.ExpenseId + "</td><td>" + obj.Exp_Date + "</td><td>" + obj.Exp_Title + "</td><td>" + obj.Exp_Amount + "</td><td>" + obj.Exp_Concerned + "</td><td>" + obj.Exp_Type + "</td><td><a href='javascript:DeleteExpense(" + obj.ExpenseId + "," + obj.Exp_Amount + ")'><i class='fa fa-times' style='color:rgb(175, 175, 175)'></i></a></td></tr>")

            });
            $("#expLoader").fadeOut('slow');
        }
    });
}

function DeleteExpense(expenseId,amount) {
    var data = { ExpenseId: expenseId }
    $.ajax({
        type: 'POST',
        url: '/Expense/DeleteExpense',
        data: data,
        success: function (data) {

       
            toastr.success("Expense removed!");
            var curExpense = $("#lblExpense").text();
            var balExpense = parseFloat(curExpense) - parseFloat(amount);
            $("#lblExpense").text(balExpense);
            getRecentexpenses();
            getGraph();
        }

    });
}
function getGraph() {

    var item1 = [], item2 = [];
    $.ajax({
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            //Upload progress
            xhr.upload.addEventListener("progress1", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#loaderGraph").fadeIn('slow');

                }
            }, false);
            //Download progress
            xhr.addEventListener("progress1", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#loaderGraph").fadeIn('slow');

                }
            }, false);
            return xhr;
        },
        type: 'POST',
        url: '/Expense/GetExpenseGraph',
        data: null,
        success: function (data) {

            $.each($.parseJSON(data), function (idx, obj) {

                if (obj.typeId == 0) {

                    item1 = [obj.travel, obj.lodging, obj.ads, obj.other, obj.food, obj.entertainment, obj.salary];

                }
                else if (obj.typeId == 1) {

                    item2 = [obj.travel, obj.lodging, obj.ads, obj.other, obj.food, obj.entertainment, obj.salary];

                }

                $("#loaderGraph").fadeOut('slow');
            });
            var radarData = {
                labels: ["Travel", "Lodging", "Ads", "Other", "Food", "Entertainment", "Salary"],
                datasets: [
                    {
                        label: "My First dataset",
                        fillColor: "rgba(220,220,220,0.2)",
                        strokeColor: "rgba(220,220,220,1)",
                        pointColor: "rgba(220,220,220,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(220,220,220,1)",
                        data: item2
                    },
                    {
                        label: "My Second dataset",
                        fillColor: "rgba(26,179,148,0.2)",
                        strokeColor: "rgba(26,179,148,1)",
                        pointColor: "rgba(26,179,148,1)",
                        pointStrokeColor: "#fff",
                        pointHighlightFill: "#fff",
                        pointHighlightStroke: "rgba(151,187,205,1)",
                        data: item1
                    }
                ]
            };

            var radarOptions = {
                scaleShowLine: true,
                angleShowLineOut: true,
                scaleShowLabels: false,
                scaleBeginAtZero: true,
                angleLineColor: "rgba(0,0,0,.1)",
                angleLineWidth: 1,
                pointLabelFontFamily: "'Arial'",
                pointLabelFontStyle: "normal",
                pointLabelFontSize: 10,
                pointLabelFontColor: "#666",
                pointDot: true,
                pointDotRadius: 3,
                pointDotStrokeWidth: 1,
                pointHitDetectionRadius: 20,
                datasetStroke: true,
                datasetStrokeWidth: 2,
                datasetFill: true,
                responsive: true,
            }

            var ctx = document.getElementById("radarChart").getContext("2d");
            var myNewChart = new Chart(ctx).Radar(radarData, radarOptions);
        }

    });

}

$("#exp_btn_save").click(function () {


    exp_expenseTitle = $("#txtTitle").val();
    exp_notes = $("#txtNotes").val();
    exp_Amount = $("#txtAmount").val();
    exp_Date = $("#txtdate").val();
    exp_ExpType = $("#Exp_Type").val();
    exp_ConcernedPer = $("#txtConcerned").val();

    var params = { Exp_Title: exp_expenseTitle, Exp_Notes: exp_notes, Exp_Amount: exp_Amount, Exp_Date: exp_Date, Exp_Type: exp_ExpType, Exp_Concerned: exp_ConcernedPer };

    $.ajax({
       
        type: 'POST',
        url: '/Expense/SaveNewExpense',
        data: params,
       
        success: function (data) {

            var result = jQuery.parseJSON(data);
            $("#table_data_expenses").append("<tr><td>" + result.ExpenseId + "</td><td>" + result.Exp_Date + "</td><td>" + result.Exp_Title + "</td><td>" + result.Exp_Amount + "</td><td>" + result.Exp_Concerned + "</td><td>" + result.Exp_Type + "</td><td><a href='javascript:DeleteExpense(" + result.ExpenseId + "," + result.Exp_Amount + ")'><i class='fa fa-times' style='color:rgb(175, 175, 175)'></i></a></td></tr>")

            var curExpense = $("#lblExpense").text();
            curExpense = parseFloat(curExpense) + parseFloat(exp_Amount);

            $("#lblExpense").text(curExpense);
            toastr.success("New expense added !");

            getGraph();
        }



    });

    });

