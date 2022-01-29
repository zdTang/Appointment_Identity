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
            ViewBag.doctorList=_appointmentService.GetDoctorList();
            return View();
        }
    }
}
