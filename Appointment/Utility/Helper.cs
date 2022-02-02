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


        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            var duration = new List<SelectListItem>();
            for(int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" } );
                minute += 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 30 min" });
                minute += 30;
            }
            return duration;
        }
    }

    
}
