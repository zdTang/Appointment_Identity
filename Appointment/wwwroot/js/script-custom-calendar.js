/*============================
 This Script will go with _Layout.cshtml, so that it will be available
 to all the views which use _Layout.cshtml
 ============================*/

$(document).ready(function () {
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

const onSubmitForm = () => {
    
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

    console.log(requestData);
    console.log(JSON.stringify(requestData));
    onCloseModal();
}