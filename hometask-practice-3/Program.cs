using hometask_practice_3;
using System.Globalization;

public static class Program
{
    public static void Main(string[] args)
    {
        Hospital hospital = new Hospital();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Remove Doctor");
            Console.WriteLine("3. View All Doctors");
            Console.WriteLine("4. Schedule Appointment");
            Console.WriteLine("5. View Appointments for Doctors");
            Console.WriteLine("0. Exit");

            string option = Console.ReadLine();
            int newOption;

            bool isTrueOption = int.TryParse(option, out newOption);

            if (isTrueOption)
            {
                switch (newOption)
                {
                    case (int) Options.AddDoctor:
                        Console.WriteLine();
                        Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine();

                        hospital.AddDoctor(name);
                        break;
                    case (int) Options.RemoveDoctor:
                        Console.WriteLine();
                        Console.WriteLine("Enter Name: ");
                        name = Console.ReadLine();

                        hospital.RemoveDoctor(name);
                        break;
                    case (int) Options.ViewAllDoctors:
                        hospital.ViewAllDoctors();
                        break;
                    case (int) Options.CreateAppointment:
                        Console.WriteLine();
                        Console.WriteLine("Enter Doctor to Schedule Appointment: ");
                        name = Console.ReadLine();

                        var doctor = hospital.Doctors.FirstOrDefault(d => d.DoctorName == name);

                        if (doctor is not null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter Patient Name: ");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter Date(dd-MM-yyyy HH:mm): ");
                            string date = Console.ReadLine();
                            DateTime newDate;

                            bool isTrueDateTime = DateTime.TryParseExact(date, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate);

                            if (isTrueDateTime)
                                doctor.CreateAppointment(new Appointment(name, newDate));
                            else
                                Console.WriteLine("Enter right date for appointment");
                        }
                        else
                            Console.WriteLine("Doctor is not available");
                        break;
                    case (int) Options.ViewAppointmentsForDoctors:
                        Console.WriteLine();
                        Console.WriteLine("Enter Doctor Name to Check Appointments: ");
                        name = Console.ReadLine();  

                        hospital.ViewAppointmentsForDoctor(name);   
                        break;
                    case (int)Options.Exit:
                        return;
                    default:
                        Console.WriteLine("Enter right choice");
                        break;
                }
            }

        }
    }
}