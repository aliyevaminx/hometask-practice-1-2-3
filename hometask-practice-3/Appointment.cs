using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask_practice_3
{
    internal class Appointment
    {
        private string patientName;
        private DateTime date;

        public string PatientName { get; }
        public DateTime Date { get; }

        public Appointment(string patientName, DateTime date)
        {
            PatientName = patientName;
            Date = date;
        }
    }
}
