using Appointment.Models;
using Appointment.Models.ViewModels;
using Appointment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Services
{
    public class AppointService : IAppointmentService
    {
        readonly ApplicationDbContext _db;
        public AppointService(ApplicationDbContext db)
        {
            _db = db;
        }
        // this volite "Single Responsibility Principle", will not easy for testing
        // will refector it later.
        public async Task<int> AddUpdate(AppointmentVM model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            if (model != null && model.Id > 0)
            {
                //update, Model has Id 
                return 1;
            }
            else
            {
                // create
                // Can we use Automapper here ?
                var appointment = new Appoint
                {
                    Title = model.Title,
                    StartDate = startDate,
                    EndDate = endDate,
                    Description = model.Description,
                    Duration = model.Duration,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    AdminId = model.AdminId,
                    IsDoctorApproved = model.IsDoctorApproved,
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;       // Return a magic number?
            }

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

        // Get all appointment based on PatientId
        // Todo: Need test if it works properly
        public List<AppointmentVM> PatientsEventsById(string patientId)
        {
            return _db.Appointments.Where(x => x.PatientId == patientId).Select(c => new AppointmentVM
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-mm-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsDoctorApproved = c.IsDoctorApproved
            }).ToList();
        }

        // Get all appointment based on DoctorId
        // Todo: Need test if it works properly
        public List<AppointmentVM> DoctorsEventsById(string doctorId)
        {
            return _db.Appointments.Where(x => x.DoctorId == doctorId).Select(c => new AppointmentVM
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-mm-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsDoctorApproved = c.IsDoctorApproved
            }).ToList();
        }
    }
}
