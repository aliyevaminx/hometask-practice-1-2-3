using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask_practice_3
{
    internal class Hospital
    {
        List<Doctor> doctors;
        public List<Doctor> Doctors { get; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
        }
        public void AddDoctor(string name)
        {
            Doctors.Add(new Doctor(name));
            Console.WriteLine("Doctor added successfully");
        }
        public void RemoveDoctor(string name) 
        {
            var doctor = Doctors.FirstOrDefault(d => d.DoctorName == name);

            if (doctor is not null) 
            { 
                Doctors.Remove(doctor);
                Console.WriteLine("Doctor removed successfully");
            }
            else
                Console.WriteLine("This doctor is not available");
        }
        public void ViewAllDoctors()
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                Console.WriteLine($"Doctor: {Doctors[i].DoctorName}");
            }
        }

        public void ViewAppointmentsForDoctor(string name)
        {
            var doctor = Doctors.FirstOrDefault(d => d.DoctorName == name);

            if (doctor is not null)
            {
              for (int i = 0; i < doctor.Appointments.Count; i++)
                {
                    Console.WriteLine($"Doctor Name: {name} " +
                        $"Patient Name: {doctor.Appointments[i].PatientName} " +
                        $"Date: {doctor.Appointments[i].Date.ToString("dd-MM-yyyy HH:mm")}");
                }
            }
        }
    }
}
