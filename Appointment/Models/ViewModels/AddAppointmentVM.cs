using System.ComponentModel.DataAnnotations;

namespace Appointment.Models.ViewModels
{
    public class AddAppointmentVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Patient { get; set; }
        [Required]
        public string Duration { get; set; }
    }
}
