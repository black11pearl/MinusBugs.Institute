
$(function () {

getStaffList();

getCourseList();

getStudentList();

loadcalendar();

});
function loadcalendar() {

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        defaultDate: '2015-02-12',
        selectable: true,
        selectHelper: true,
        select: function (start, end) {
            var title = $("#txtBatchTitle").val();

            eventList.push({ id: 0, title: title, start: moment(start).format('MM/DD/YYYY hh:mm'), end: moment(end).format('MM/DD/YYYY hh:mm') });
            eventData = {
                title: title,
                start: start,
                end: end
            };
            $('#calendar').fullCalendar('renderEvent', eventData, true); // stick? = true

            $('#calendar').fullCalendar('unselect');

        },

        editable: true,
        eventLimit: true, // allow "more" link when too many events
        events: [
            //{
            //	title: 'All Day Event',
            //	start: '2015-02-01'
            //},
            //{
            //	title: 'Long Event',
            //	start: '2015-02-07',
            //	end: '2015-02-10'
            //},
            //{
            //	id: 999,
            //	title: 'Repeating Event',
            //	start: '2015-02-09T16:00:00'
            //},
            //{
            //	id: 999,
            //	title: 'Repeating Event',
            //	start: '2015-02-16T16:00:00'
            //},
            //{
            //	title: 'Conference',
            //	start: '2015-02-11',
            //	end: '2015-02-13'
            //},
            //{
            //	title: 'Meeting',
            //	start: '2015-02-12T10:30:00',
            //	end: '2015-02-12T12:30:00'
            //},


            //{
            //	title: 'Click for Google',
            //	url: 'http://google.com/',
            //	start: '2015-02-28'
            //}
        ],
        eventClick: function (calEvent, jsEvent, view) {

            alert('Event: ' + calEvent.title);
            alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
            alert('View: ' + view.name);
            // alert('Time :' + moment(calEvent.start).format('DD/MM/YYYY hh:mm') + ' End Time:' + moment(calEvent.end).format('DD/MM/YYYY hh:mm'))
            // change the border color just for fun
            alert(eventData);
            $(this).css('border-color', 'red');

        }

    });
}

function getStaffList() {
    $.ajax({
        type: 'POST',
        url: '/Staff/ViewFacultyNames',
        data: null,
        success: function (data) {

            $.each($.parseJSON(data), function (idx, obj) {

                $("#facList").append("<option value='" + obj.StaffId + "' >" + obj.StaffName + "</option>");



            });
            var config = {
                '.chosen-select1': {},
                '.chosen-select1-deselect': { allow_single_deselect: true },
                '.chosen-select1-no-single': { disable_search_threshold: 10 },
                '.chosen-select1-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select1-width': { width: "95%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        },
        error: Error,
        async: true,
        cache: true
    });
}

function getCourseList() {
    $.ajax({
        type: 'POST',
        url: '/Courses/GetCourseListJson',
        data: null,
        success: function (data) {

            $.each($.parseJSON(data), function (idx, obj) {

                $("#TechList").append("<option value='" + obj.CourseId + "' >" + obj.CourseTitle + "</option>");



            });
            var config1 = {
                '.chosen-select2': {},
                '.chosen-select2-deselect': { allow_single_deselect: true },
                '.chosen-select2-no-single': { disable_search_threshold: 10 },
                '.chosen-select2-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select2-width': { width: "95%" }
            }
            for (var selector in config1) {
                $(selector).chosen(config1[selector]);
            }
        },
        error: Error,
        async: true,
        cache: true
    });
}

function getStudentList() {
    $.ajax({
        type: 'POST',
        url: '/Student/GetStudentsDataJson',
        data: null,
        success: function (data) {

            $.each($.parseJSON(data), function (idx, obj) {

                $("#StudList").append("<option value='" + obj.Admno + "' >" + obj.FirstName + " " + obj.LastName + "</option>");



            });
            var config2 = {
                '.chosen-select3': {},
                '.chosen-select3-deselect': { allow_single_deselect: true },
                '.chosen-select3-no-single': { disable_search_threshold: 10 },
                '.chosen-select3-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select3-width': { width: "95%" }
            }
            for (var selector in config2) {
                $(selector).chosen(config2[selector]);
            }
        },
        error: Error,
        async: true,
        cache: true
    });
}

var eventList = new Array();


var eventData = null;


JsonTechs = {

    tech: []
};
JsonStud = {

    stud: []
};

function cont1() {
    // getFacValues();
    getTechValues();
    getStudentValues();
    postBatches();
}

$("#btnWarningClose").click(function () {

    $("#message-box-warning").fadeOut('slow');
})

function postBatches() {


    var Jsonlist = new Array();

    var jfacList = new Array();
    var jTechList = new Array();
    var jStudList = new Array();

    var things;


    //start loop thru faculty list item
    var listItems = $("#facList_chosen ul.chosen-choices ");

    listItems.find('li.search-choice').each(function () {

        var product = $(this).find("input");
        jfacList.push({ facid: product.val() });

    });

    //end loop faculty

    //start loop thru tech list item
    var listItems = $("#TechList_chosen ul.chosen-choices ");

    listItems.find('li.search-choice').each(function () {

        var product = $(this).find("input");
        jTechList.push({ CourseId: product.val() });


    });

    //end loop faculty

    //start loop thru Students list item
    var listItems = $("#StudList_chosen ul.chosen-choices ");

    listItems.find('li.search-choice').each(function () {

        var product = $(this).find("input");
        jStudList.push({ Admno: product.val() });


    });

    //end loop student

    duration = $("#txtDuration").val();
    about = $("#txtAbout").val();
    var batchData = { Duration: duration, Description: about };
    Jsonlist.push({ facList: jfacList, techList: jTechList, studList: jStudList, timList: eventList, batchData: batchData });
    //JsonFacList.push({ thingList: list2 });

    things = Jsonlist;

    things = JSON.stringify({ 'things': things });

    $.ajax({
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            //Upload progress
            xhr.upload.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var audioElement = document.createElement('audio');
                    audioElement.setAttribute('src', '/audio/alert.mp3');
                    audioElement.setAttribute('autoplay', 'autoplay');
                    var percentComplete = evt.loaded / evt.total;

                    $("#message-box-warning").fadeIn('slow');

                    console.log(percentComplete);
                }
            }, false);
            //Download progress
            xhr.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;

                    $("#message-box-warning").fadeIn('slow');
                    console.log(percentComplete);
                }
            }, false);
            return xhr;
        },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Batch/AddNewBatch',
        data: things,

        success: function (data) {
            // $('#result').html('"PassThings()" successfully called.');
            $("#message-box-warning").fadeOut('slow');

            toastr.success("Batch scheduling completed");
        },
        failure: function (response) {
            toastr.warning("Batch scheduling failed,please try with a lower duration");
        }
    });
}


function getTechValues() {
    var listItems = $("#TechList_chosen ul.chosen-choices ");
    listItems.find('li.search-choice').each(function () {

        var product = $(this).find("input");
        //   alert("TechIds  :"+product.val())
        JsonTechs.tech.push({

            "CourseId": product.val()

        });
        // alert("Techs  :"+JsonTechs);
        // and the rest of your code
    });

}

function getStudentValues() {
    var listItems = $("#StudList_chosen ul.chosen-choices ");
    listItems.find('li.search-choice').each(function () {

        var product = $(this).find("input");
        //     alert("Student Admno  :" + product.val())
        JsonStud.stud.push({

            "Admno": product.val()

        });
        //  alert("Students : "+ JsonStud);
        // and the rest of your code
    });

}

