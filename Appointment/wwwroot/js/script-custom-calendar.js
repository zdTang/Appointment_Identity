/*============================
 This Script will go with _Layout.cshtml, so that it will be available
 to all the views which use _Layout.cshtml
 ============================*/

var routeURL = location.protocol + "//" + location.host;

$(document).ready(function () {

    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput:false
    })
    InitializeCalendar();
})


function InitializeCalendar() {
    try {


        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                events: function (fetchInfo, successCallback, failureCallback) {
                    // pass params via URL, Is this a good approach?
                    // How many approaches we can retrive param from the URL?
                    // https://api.jquery.com/jquery.ajax/
                    let URL = routeURL + "/api/Appointment/GetCalendarData?doctorId=" + $("#doctorId").val();
                    console.log(URL);
                    $.ajax({
                        url: URL,
                        type: 'GET',
                        dataType: "json",
                        success: function (response) {
                            console.log("getEvent: ", response);
                            var event = [];
                            if (response.status === 1) {
                                $.each(response.dataEnum, function (i, data) {
                                    event.push({
                                        title: data.title,
                                        description: data.description,
                                        start: data.startDate,
                                        end: data.endDate,
                                        backgroundColor: data.isDoctorApproved ? "#28a745" : "#dc3545",
                                        borderColor: "#162466",
                                        textColor:"white",
                                        id:data.id
                                    })
                                })
                            }
                            console.log("getEvent: ", event);
                            successCallback(event);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error");
                        }
                    })
                }
            });
            calendar.render();
        }
        
    }
    catch (e) {
        alert(e);
    }

}

// to Display the "appointmentInput" partial view. and cover the underlying content as well.
function onShowModal(obj, isEventDetail) {
    $("#appointmentInput").modal("show");
}

// to remove the "appointmentInput" partial view. and display the underlying calendar as well.
function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

/*===============================
 * Function Name: onSubmitForm
 * 
 ===============================*/

const onSubmitForm = () => {

    if (checkValidation()) {
        // construct Data to post to Server
        // Here we are using JS object notation
        // JSON support int, string, bool, array, object....so that we convert string to Int here?
        var requestData = {
            Id: parseInt($("#id").val()),         // This is a hidden value
            Title: $("#title").val(),
            Description: $("#description").val(),
            StartDate: $("#appointmentDate").val(),
            Duration: $("#duration").val(),
            DoctorId: $("#doctorId").val(),       // this value is taken from Master View
            PatientId: $("#patientId").val(),
        }
        console.log(JSON.stringify(requestData));
        let URL = routeURL + "/api/Appointment/SaveCalendarData";
        //console.log(URL);

        $.ajax({
            url: URL,
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: "application/json",
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        })
    }
}

const checkValidation=()=> {
    var isValid = true;
    //  title
    if ($("#title").val() === undefined || $("#title").val() === "") {
        isValid = false;
        $("#title").addClass("error");
    }
    else {
        $("#title").removeClass("error");
    }
    //  description
    if ($("#description").val() === undefined || $("#description").val() === "") {
        isValid = false;
        $("#description").addClass("error");
    }
    else {
        $("#description").removeClass("error");
    }

    //  appointmentDate
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
        isValid = false;
        $("#appointmentDate").addClass("error");
    }
    else {
        $("#appointmentDate").removeClass("error");
    }

    

    return isValid;
}