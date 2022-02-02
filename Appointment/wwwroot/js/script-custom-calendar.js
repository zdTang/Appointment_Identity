/*============================
 This Script will go with _Layout.cshtml, so that it will be available
 to all the views which use _Layout.cshtml
 ============================*/

$(document).ready(function () {
    InitializeCalendar();
})


function InitializeCalendar() {
    try {
        $("#calendar").fullCalendar({
            timezone: false,
            header: {
                left: 'prev,next,today',
                center: 'title',
                right:'month,agendaWeek,agendaDay'
            },
            selectable: true,
            editable: false,
            select: function (event) {
                onShowModal(event, null);
            }
        })
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
    console.log("Submit !!");
    onCloseModal();
}