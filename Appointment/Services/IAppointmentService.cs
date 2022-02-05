using Appointment.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Services
{
    public interface IAppointmentService
    {
        public List<DoctorVM> GetDoctorList();
        public List<PatientVM> GetPatientList();
        
        // Async cannot be used in the Interface
        public Task<int> AddUpdate(AppointmentVM model);
    }
}
