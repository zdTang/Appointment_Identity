namespace Appointment.Models.InputModels
{
    public class AddAppointmentIM
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Patient { get; set; }
        public string Duration { get; set; }
    }
}
