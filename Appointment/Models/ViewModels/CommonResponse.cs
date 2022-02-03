﻿namespace Appointment.Models.ViewModels
{
    public class CommonResponse<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T dataEnum { get; set; }

    }
}
