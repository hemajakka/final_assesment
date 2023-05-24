using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IStudents
    {
        int addstudent(SqlConnection conn, int id, string student_name, int roll, string department);
        int updatestudents(SqlConnection conn, int id, string studentname, int roll, string department);
        int deletestudent(SqlConnection conn, int id);
    }
}
