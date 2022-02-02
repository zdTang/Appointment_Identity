using Appointment.Models.InputModels;
using Appointment.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            ViewBag.doctorList = _appointmentService.GetDoctorList();
            ViewBag.PatientList = _appointmentService.GetPatientList();
            ViewBag.Duration = Utility.Helper.GetTimeDropDown();
            return View();
        }
        [HttpPost]
        public IActionResult Index(AddAppointmentIM appointment)
        {
            ViewBag.doctorList = _appointmentService.GetDoctorList();
            ViewBag.PatientList = _appointmentService.GetPatientList();
            ViewBag.Duration = Utility.Helper.GetTimeDropDown();
            Console.WriteLine("ok");
            return View();
        }
    }
}
