using System.ComponentModel.Design;
using System.Globalization;
using Task_7;

public static class Program
{
    public static void Main(string[] args)
    {
        Course course1 = new Course("Course");

        while (true)
        {
            Console.WriteLine();
        Menu: Console.WriteLine("1. Add Group");
            Console.WriteLine("2. Show Groups");
            Console.WriteLine("3. Edit Group");
            Console.WriteLine("4. Delete Group");
            Console.WriteLine("5. Add Student to Group");
            Console.WriteLine("6. Show Students in Group");
            Console.WriteLine("7. Show All Students");
            Console.WriteLine("8. Search Student");
            Console.WriteLine("9. Remove Student from Group");
            Console.WriteLine("10. Edit Student");
            Console.WriteLine("0. Exit");

            string option = Console.ReadLine();
            int enumOption;

            bool isTrueOption = int.TryParse(option, out enumOption);

            if (isTrueOption)
            {
                switch (enumOption)
                {
                    case (int)Options.AddGroup:
                        Console.WriteLine();
                        Console.WriteLine("Enter Group Name (Group Name Length must be at least 3 letters and non white space): ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Group Limit: ");
                        string limit = Console.ReadLine();
                        int groupLimit;

                        bool isTrueLimitFormat = int.TryParse(limit, out groupLimit);
                        if (isTrueLimitFormat)
                            course1.AddGroup(new Group(name, groupLimit));
                        else
                            Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "limit"));
                        break;
                    case (int)Options.ShowGroups:
                        Console.WriteLine();
                        if (course1.Groups.Count > 0)
                            course1.ShowGroups();
                        else
                            Console.WriteLine(ErrorMessages.NotGroupInCourse);
                        break;
                    case (int)Options.EditGroup:
                        Console.WriteLine();
                        if (course1.Groups.Count > 0)
                        {
                            Console.WriteLine("Enter Group ID to Edit: ");
                            course1.ShowGroups();
                            string id = Console.ReadLine();
                            int groupId;
                            bool isTrueGroupID = int.TryParse(id, out groupId);

                            if (isTrueGroupID)
                            {
                                Console.WriteLine("What do you want to edit?");
                                Console.WriteLine("1. Group Name");
                                Console.WriteLine("2. Group Limit");
                                Console.WriteLine("0. Exit");

                                option = Console.ReadLine();
                                int editOption;

                                bool isTrueEditOption = int.TryParse(option, out editOption);

                                if (isTrueEditOption)
                                {
                                    switch (editOption)
                                    {
                                        case (int)EditOptions.EditGroupName:
                                        NewGroupNameLine: Console.WriteLine("Enter New Group Name:");
                                            string newGroupName = Console.ReadLine();

                                            if (newGroupName.isValidNameFormat())
                                                course1.EditGroupName(groupId, newGroupName);
                                            else
                                            {
                                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "Group Name"));
                                                goto NewGroupNameLine;
                                            }
                                            break;
                                        case (int)EditOptions.EditGroupLimit:
                                            Console.WriteLine("Enter New Group Limit: ");
                                            string newGroupLimit = Console.ReadLine();
                                            int NewGroupLimit;

                                            bool isTrueGroupLimit = int.TryParse(newGroupLimit, out NewGroupLimit);

                                            if (isTrueGroupLimit)
                                                course1.EditGroupLimit(groupId, NewGroupLimit);
                                            else
                                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "Limit"));
                                            break;
                                        case (int)EditOptions.Exit:
                                            goto Menu;
                                        default:
                                            Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "option"));
                                            break;
                                    }
                                }
                            }
                        }
                        else
                            Console.WriteLine(ErrorMessages.NotGroupInCourse);
                        break;
                    case (int)Options.DeleteGroup:
                        Console.WriteLine();
                        if (course1.Groups.Count > 0)
                        {
                            Console.WriteLine("Enter Group Name to Delete: ");
                            course1.ShowGroups();
                            name = Console.ReadLine();

                            course1.DeleteGroup(name);
                        }
                        else
                            Console.WriteLine(ErrorMessages.NotGroupInCourse);
                        break;
                    case (int)Options.AddStudentToGroup:
                        Console.WriteLine();
                        course1.ShowGroups();
                        Console.WriteLine("Enter Group Name To Add Student: ");
                        name = Console.ReadLine();

                        if (course1.Groups.Any(g => g.Name == name))
                        {
                            var selectedGroup = course1.Groups.FirstOrDefault(g => g.Name == name);

                            Console.WriteLine("Enter Student Name: ");
                            string studentName = Console.ReadLine();
                            Console.WriteLine("Enter Student Surname: ");
                            string studentSurname = Console.ReadLine();
                            Console.WriteLine("Enter Student Grade: ");
                            string grade = Console.ReadLine();
                            int Grade;
                            Console.WriteLine("Enter Birth Date(dd.MM.yyyy): ");
                            var birthDate = Console.ReadLine();
                            DateTime BirthDate;
                            bool isTrueBirthDate = DateTime.TryParseExact(birthDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out BirthDate);
                            bool isTrueGrade = int.TryParse(grade, out Grade);

                            if (isTrueGrade && isTrueBirthDate)
                                selectedGroup.AddStudent(new Student(studentName, studentSurname, BirthDate, Grade));
                        }
                        else
                            Console.WriteLine(ErrorMessages.GroupNotFound);
                        break;
                    case (int)Options.ShowStudentsInGroup:
                        Console.WriteLine();
                        course1.ShowGroups();
                        Console.WriteLine("Enter Group Name To Show Students: ");
                        name = Console.ReadLine() ?? string.Empty;

                        var showedGroup = course1.Groups.FirstOrDefault(g => g.Name == name);

                        if (course1.Groups.Any(g => g.Name == name))
                            showedGroup.ShowStudentsInGroup();
                        else
                            Console.WriteLine(ErrorMessages.GroupNotFound);
                        break;
                    case (int)Options.ShowAllStudents:
                        Console.WriteLine();
                        if (course1.Groups.Count > 0)
                            course1.ShowAllStudentsInCourse();
                        else
                            Console.WriteLine(ErrorMessages.NotGroupInCourse);
                        break;
                    case (int)Options.SearchStudent:
                        Console.WriteLine();
                        Console.WriteLine("Enter Student Name: ");
                        name = Console.ReadLine() ?? string.Empty;

                        course1.SearchStudent(name);
                        break;
                    case (int)Options.RemoveStudentFromGroup:
                        Console.WriteLine();
                        Console.WriteLine("Enter Group Name To Delete Student: ");
                        course1.ShowGroups();
                        name = Console.ReadLine() ?? string.Empty;

                        if (course1.Groups.Any(g => g.Name == name))
                        {
                            showedGroup = course1.Groups.FirstOrDefault(g => g.Name == name);
                            Console.WriteLine("Enter Student ID: ");
                            showedGroup.ShowStudentsInGroup();

                            string id = Console.ReadLine();
                            int newId;
                            bool isTrueId = int.TryParse(id, out newId);
                            if (isTrueId)
                                showedGroup.RemoveStudentFromGroup(newId);
                            else
                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "ID"));
                        }
                        else
                            Console.WriteLine(ErrorMessages.GroupNotFound);
                        break;
                    case (int)Options.EditStudent:
                        Console.WriteLine();
                        Console.WriteLine("Enter Group Name To Edit Student: ");
                        course1.ShowGroups();
                        name = Console.ReadLine() ?? string.Empty;

                        if (course1.Groups.Any(g => g.Name == name))
                        {
                            showedGroup = course1.Groups.FirstOrDefault(g => g.Name == name);
                            Console.WriteLine("Enter Student ID: ");
                            showedGroup.ShowStudentsInGroup();

                            string id = Console.ReadLine();
                            int newId;
                            bool isTrueId = int.TryParse(id, out newId);
                            if (isTrueId)
                                showedGroup.EditStudent(newId);
                            else
                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "ID"));
                        }
                        else
                            Console.WriteLine(ErrorMessages.GroupNotFound);
                        break;
                    case (int)Options.Exit:
                        return;
                    default:
                        Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{propertyName}", "option"));
                        break;
                }
            }
        }
    }
}