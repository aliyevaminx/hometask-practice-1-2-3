using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    internal class Student
    {
        private static int id = 1;
        private string name;
        private string surname;
        private DateTime birthDate;
        private int grade;

        public int ID { get; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public int Grade { get; internal set; }
        public DateTime BirthDate { get; internal set; }

        public Student(string name, string surname, DateTime birthDate, int grade)
        {
            ID = id++;
            Name = name;    
            Surname = surname;  
            BirthDate = birthDate;  
            Grade = grade;
        }
    }
}
