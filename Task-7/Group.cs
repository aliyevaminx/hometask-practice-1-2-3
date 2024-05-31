using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_7
{
    internal class Group
    {
        private List<Student> students;
        private string name;
        private static int id = 1;
        private int limit;
        private int studentCount;

        public string Name { get; internal set; }
        public int ID { get; }
        public int Limit { get; internal set; }
        public List<Student> Students { get; }
        public int StudentCount { get; internal set; }

        public Group(string name, int limit)
        {
            ID = id++;
            Name = name;
            Limit = limit;
            Students = new List<Student>();
            StudentCount = 0;
        }

        public void AddStudent(Student student)
        {
            if (StudentCount < Limit)
            {
                if (Students.Any(s => s.ID == student.ID))
                    Console.WriteLine("This student already exists");
                else
                {
                    Students.Add(student);
                    Console.WriteLine("Student added successfully");
                    StudentCount++;
                }
            }
            else
                Console.WriteLine("This group is full");
        }

        public void ShowStudentsInGroup()
        {
            if (Students.Any())
            {
                for (int i = 0; i < Students.Count; i++)
                    Console.WriteLine($"{i + 1}. Student: " +
                                      $"{Students[i].ID} " +
                                      $"{Students[i].Name} " +
                                      $"{Students[i].Surname} " +
                                      $"{Students[i].BirthDate.Day}/{Students[i].BirthDate.Month}/{Students[i].BirthDate.Year} " +
                                      $"{Students[i].Grade}");
            }
            else
                Console.WriteLine(ErrorMessages.NotStudentInGroup);
        }

        public void RemoveStudentFromGroup(int newId)
        {
            if (Students.Any(s => s.ID == newId))
            {
                var selectedStudent = Students.FirstOrDefault(s => s.ID == newId);
                Students.Remove(selectedStudent);
                Console.WriteLine("Student Removed Successfully");
                StudentCount--;
            }
            else
                Console.WriteLine(ErrorMessages.StudentNotFound);
        }
        public void EditStudent(int newId)
        {
            if (Students.Any(s => s.ID == newId))
            {
                var selectedStudent = Students.FirstOrDefault(s => s.ID == newId);

                Console.WriteLine("Enter New Student Name: ");
                string newStudentName = Console.ReadLine();
                Console.WriteLine("Enter New Student Surname: ");
                string newStudentSurname = Console.ReadLine();
                Console.WriteLine("Enter New Student Grade: ");
                string newGrade = Console.ReadLine();
                int NewGrade;
                Console.WriteLine("Enter New Birth Date(dd.MM.yyyy): ");
                var newBirthDate = Console.ReadLine();
                DateTime NewBirthDate;
                bool isTrueBirthDate = DateTime.TryParseExact(newBirthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NewBirthDate);
                bool isTrueGrade = int.TryParse(newGrade, out NewGrade);

                if (isTrueGrade && isTrueBirthDate)
                {
                    selectedStudent.Name = newStudentName;
                    selectedStudent.Surname = newStudentSurname;
                    selectedStudent.BirthDate = NewBirthDate;
                    selectedStudent.Grade = NewGrade;
                }
            }
            else
                Console.WriteLine(ErrorMessages.StudentNotFound);
        }
    }
}
