﻿$(function () {
  

  
});



$("#btnView").click(function () {
    var date1 = $("#start").val();
    var date2 = $("#end").val();
    var params = { fromDate: date1, toDate: date2 };

    $.ajax({
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            //Upload progress
            xhr.upload.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#expLoader").fadeIn('slow');

                }
            }, false);
            //Download progress
            xhr.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#expLoader").fadeIn('slow');

                }
            }, false);
            return xhr;
        },
        type: 'POST',
        url: '/Expense/ExpenseReport',
        data: params,
        success: function (data) {
            var result = jQuery.parseJSON(data);
            $("#table_data_expenses").empty();
            $.each($.parseJSON(data), function (idx, obj) {
                $("#table_data_expenses").append("<tr><td>" + obj.ExpenseId + "</td><td>" + obj.Exp_Date + "</td><td>" + obj.Exp_Title + "</td><td>" + obj.Exp_Amount + "</td><td>" + obj.Exp_Concerned + "</td><td>" + obj.Exp_Type + "</td></tr>")


            });
            $("#expLoader").fadeOut('slow');
        }
    });

})


