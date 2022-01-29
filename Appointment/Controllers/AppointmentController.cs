using Appointment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    public class AppointmentController : Controller
    {
        readonly IAppointmentService _appointmentService; 
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService=appointmentService;
        }
        public IActionResult Index()
        {
            var doctors=_appointmentService.GetDoctorList();
            return Ok(doctors);
        }
    }
}
