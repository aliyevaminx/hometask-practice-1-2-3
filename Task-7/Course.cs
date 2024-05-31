using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    internal class Course
    {
        private string name;
        private List<Group> groups;

        public string Name { get; }
        public List<Group> Groups { get; }

        public Course(string name)
        {
            Name = name;
            Groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            if (Groups.Any(g => g.Name == group.Name))
                Console.WriteLine("This group already exists");
            else if (group.Name.isValidNameFormat())
            {
                Groups.Add(group);
                Console.WriteLine("Group added successfully");
            }
            else
                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "Group Name"));
        }

        public void ShowGroups()
        {
                for (int i = 0; i < Groups.Count; i++)
                    Console.WriteLine($"ID: {Groups[i].ID} Name: {Groups[i].Name} Limit: {Groups[i].Limit} Current Students: {Groups[i].StudentCount} ");
        }

        public void EditGroupName(int id, string groupName)
        {
            if (Groups.Any(g => g.ID == id))
            {
                var group = Groups.FirstOrDefault(g => g.ID == id);

                group.Name = groupName;
                Console.WriteLine("Group Name changed successfully");
            }
            else
                Console.WriteLine(ErrorMessages.GroupNotFound);
        }

        public void EditGroupLimit(int id, int limit)
        {
            if (Groups.Any(g => g.ID == id))
            {
                var group = Groups.FirstOrDefault(g => g.ID == id);
                group.Limit = limit;

                if (group.Limit < group.StudentCount)
                {
                        while (group.Limit < group.StudentCount)
                        {
                            group.Students.Remove(group.Students[group.StudentCount - 1]);
                            group.StudentCount--;
                        }
                } 
                Console.WriteLine("Group Limit changed successfully");
            }
            else
                Console.WriteLine(ErrorMessages.GroupNotFound);
        }

        public void DeleteGroup(string name)
        {
            if (Groups.Any(g => g.Name == name))
            {
                var group = Groups.FirstOrDefault(g => g.Name == name);
                Groups.Remove(group);
                Console.WriteLine("Group removed successfully");
            }
            else
                Console.WriteLine(ErrorMessages.GroupNotFound);
        }


        public void ShowAllStudentsInCourse()
        {
            for (int i = 0; i < Groups.Count; i++)
                if (Groups[i].Students.Count > 0)
                {
                    for (int j = 0; j < Groups[i].Students.Count; j++)
                    {
                        Console.WriteLine($"{Groups[i].Students[j].ID} " +
                                          $"{Groups[i].Students[j].Name} " +
                                          $"{Groups[i].Students[j].Surname} " +
                                          $"{Groups[i].Students[j].BirthDate.Day}/{Groups[i].Students[j].BirthDate.Month}/{Groups[i].Students[j].BirthDate.Year} " +
                                          $"{Groups[i].Students[j].Grade} ");
                    }
                } 
                else
                    Console.WriteLine(ErrorMessages.NotStudentInGroup);
        }

        public void SearchStudent(string name)
        {
            int count = 0;

            for (int i = 0;i < Groups.Count;i++)
            {
                for (int j = 0; j < Groups[i].Students.Count; j++)
                {
                    if (Groups[i].Students[j].Name == name)
                    {
                        Console.WriteLine($"{Groups[i].Students[j].ID} " +
                                         $"{Groups[i].Students[j].Name} " +
                                         $"{Groups[i].Students[j].Surname} " +
                                         $"{Groups[i].Students[j].BirthDate.Day}/{Groups[i].Students[j].BirthDate.Month}/{Groups[i].Students[j].BirthDate.Year} " +
                                         $"{Groups[i].Students[j].Grade} ");
                        count++;    
                    }
                }
            }

            if (count == 0)
                Console.WriteLine(ErrorMessages.StudentIsNotAvailable);
        }
    }
}
