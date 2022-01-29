using Appointment.Models;
using Appointment.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Appointment.Services
{
    public class AppointService : IAppointmentService
    {
        readonly ApplicationDbContext _db;
        public AppointService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<DoctorVM> GetDoctorList()
        {
            // Using this pattern must import "Linq"
            var doctors = (from user in _db.Users
                           // "select" is cast or project
                           select new DoctorVM
                           {
                               Id = user.Id,
                               Name = user.Name
                           }).ToList();
            return doctors;
        }

        public List<PatientVM> GetPatientList()
        {
            throw new System.NotImplementedException();
        }
    }
}
