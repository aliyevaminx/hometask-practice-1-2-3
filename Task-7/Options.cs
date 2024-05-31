using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    internal enum Options
    {
        Exit,
        AddGroup,
        ShowGroups,
        EditGroup,
        DeleteGroup,
        AddStudentToGroup,
        ShowStudentsInGroup,
        ShowAllStudents,
        SearchStudent,
        RemoveStudentFromGroup,
        EditStudent
    }

    internal enum EditOptions
    {
        Exit,
        EditGroupName,
        EditGroupLimit
    }
}
