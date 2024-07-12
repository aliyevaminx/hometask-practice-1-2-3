using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask_practice_3
{
    internal class Doctor
    {
        private string doctorName;
        private List<Appointment> appointments;

        public string DoctorName { get; }
        public List<Appointment> Appointments { get; }

        public Doctor(string doctorName)
        {
            DoctorName = doctorName;
            Appointments = new List<Appointment>();
        }

        public void CreateAppointment(Appointment appointment)
        {
            if (Appointments.Count != 0)
            {
                for (int i = 0; i < Appointments.Count; i++)
                {
                    DateTime appointmentStart = Appointments[i].Date;
                    DateTime appointmentEnd = Appointments[i].Date.AddHours(1);

                    if (appointment.Date >= appointmentStart && appointment.Date <= appointmentEnd)
                        Console.WriteLine("This time is full");
                    else
                        Appointments.Add(appointment);
                }
            }
            else
                Appointments.Add(appointment);
        }
    }
}
