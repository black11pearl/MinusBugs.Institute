
$("#btnSearch").click(function () {
    keyword = $("#txtSearch").val();
    var key = { Keyword: keyword }
    $.ajax({
        type: 'POST',
        url: '/Student/SearchResults',
        data: key,
        success: function (data) {
            $("#searchResultBox").fadeIn();
            //  alert(result);
            $("#searchContent").empty()
            i = 0;
            $.each($.parseJSON(data), function (idx, obj) {
                i++;
                var name = obj.FirstName + " " + obj.LastName;
                admno = obj.Admno;
                $("#searchContent").append("<tr><td>"+obj.Admno+"</td><td>" + name + "</td><td>" + obj.Adress + "</td><td>" + obj.MobileNumber + "</td><td>" + obj.Email + "</td><td><a href='/Student/Profile/" + admno + "' class='btn btn-primary sm'>View Details </td></tr>");

            });
            $("#resultCount").text(i + ' results found for  ')
            $("#resultCount").append("<span class='text-navy'>" + keyword + "</span>");



        }
    });

});