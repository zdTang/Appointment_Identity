using Appointment.Models.ViewModels;
using System.Collections.Generic;

namespace Appointment.Services
{
    public interface IAppointmentService
    {
        public List<DoctorVM> GetDoctorList();
        public List<PatientVM> GetPatientList();
    }
}
