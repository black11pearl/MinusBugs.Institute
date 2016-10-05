$(function () {


   



});
$('.input-daterange').datepicker({
    keyboardNavigation: false,
    forceParse: false,

    autoclose: true
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
            url: '/Report/RegistrationReport',
            data: params,
            success: function (data) {
                var result = jQuery.parseJSON(data);
                $("#table_data_registration").empty();
                $.each($.parseJSON(data), function (idx, obj) {
                    $("#table_data_registration").append("<tr><td>" + obj.RegId + "</td><td>" + obj.Name + "</td><td>" + obj.Course + "</td><td>" + obj.CourseFee + "</td><td>" + obj.Discount + "</td><td>" + obj.CourseSold + "</td><td>" + obj.AmountPaid + "</td><td>" + obj.Balance + "</td><td>" + obj.RegistrationDate + "</td></tr>")


                });
                $("#expLoader").fadeOut('slow');
            }
        });

    })