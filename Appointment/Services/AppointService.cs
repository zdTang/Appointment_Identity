using Appointment.Models;
using Appointment.Models.ViewModels;
using Appointment.Utility;
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
                           join userRole in _db.UserRoles on user.Id equals userRole.UserId
                           join role in _db.Roles.Where(x=>x.Name==Helper.Doctor) on userRole.RoleId equals role.Id                         
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
            var patients = (from user in _db.Users
                           join userRole in _db.UserRoles on user.Id equals userRole.UserId
                           join role in _db.Roles.Where(x => x.Name == Helper.Patient) on userRole.RoleId equals role.Id
                           // "select" is cast or project
                           select new PatientVM
                           {
                               Id = user.Id,
                               Name = user.Name
                           }).ToList();
            return patients;
        }
    }
}
