using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Students:IStudents
    {
        public int addstudent(SqlConnection conn, int id, string student_name, int roll, string department)
        {
            SqlCommand cmd = new SqlCommand($"insert into students values(@student_id,@student_name,@roll,@department)", conn);

            cmd.Parameters.AddWithValue("@student_id", id);
            cmd.Parameters.AddWithValue("@student_name", student_name);
            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.Parameters.AddWithValue("@department", department);
            int res=cmd.ExecuteNonQuery();
            Console.WriteLine("student added successfully");
            return res;
        }
        public int updatestudents(SqlConnection conn, int id, string studentname, int roll, string department)
        {

            SqlCommand cmd = new SqlCommand("update students set student_name=@name,roll=@roll,department=@department where student_id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("@name", studentname);
            cmd.Parameters.AddWithValue("@roll", roll);
            cmd.Parameters.AddWithValue("@department", department);
            int result1 = cmd.ExecuteNonQuery();
            if (result1 > 0)
            {
                Console.WriteLine("student updated successfully");
            }
            else
            {
                Console.WriteLine("student not found");
            }
            return result1;
        }
        public int deletestudent(SqlConnection conn, int id)
        {

            SqlCommand cmd = new SqlCommand($"delete from students where id=@id ", conn);
            cmd.Parameters.AddWithValue("@id", id);
            int result2 = cmd.ExecuteNonQuery();
            if (result2 > 0)
            {
                Console.WriteLine("book deleted successfully");
            }
            else
            {
                Console.WriteLine("there is no book with such id");
            }
            return result2;
        }
        public string searchstudentbyroll(SqlConnection conn, int roll)
        {

            SqlCommand cmd = new SqlCommand($"select * from students where roll=@roll", conn);
            cmd.Parameters.AddWithValue("@roll", roll);
            SqlDataReader reader = cmd.ExecuteReader();
            string result = "";
            if (!reader.HasRows)
            {
                result = "There is no student with such roll number";
            }
            else
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result += $"{reader[i]} |";
                    }

                }
            }
            reader.Close();
            return result;
        }

    }
}
