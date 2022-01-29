using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Appointment.Utility
{
    public static class Helper
    {
        static public readonly string Admin = "Admin";
        static public readonly string Patient = "Patient";
        static public readonly string Doctor = "Doctor";


        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Helper.Admin, Text = Helper.Admin },
                new SelectListItem { Value = Helper.Patient, Text = Helper.Patient },
                new SelectListItem { Value = Helper.Doctor, Text = Helper.Doctor },
            };
        }
    }

    
}
