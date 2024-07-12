using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask_practice_3
{
    internal class Appointment
    {
        private string customerName;
        private DateTime dateForAppointment;

        public string CustomerName { get; }
        public DateTime DateForAppointment { get; }

        public Appointment(string customerName, DateTime dateForAppointment)
        {
            CustomerName = customerName;
            DateForAppointment = dateForAppointment;
        }
    }
}
