using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public class Books : IBooks
    {
        public int addbooks(SqlConnection conn, int id, string book_name, string Author_name, int book_stock)
        {

            SqlCommand cmd = new SqlCommand($"insert into books values(@book_id,@book_name,@Author_name,@book_stock)", conn);


            cmd.Parameters.AddWithValue("@book_id", id);
            cmd.Parameters.AddWithValue("@book_name", book_name);
            cmd.Parameters.AddWithValue("@Author_name", Author_name);
            cmd.Parameters.AddWithValue("@book_stock", book_stock);
            int res = cmd.ExecuteNonQuery();
            Console.WriteLine("database updated");
            return res;

        }
        public int updatebooks(SqlConnection conn, int id, string name, string Author_name, int book_stock)
        {

            SqlCommand cmd = new SqlCommand("update books set book_name=@name,Author_name=@Author_name,book_stock=@book_stock where book_id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@Author_name", Author_name);
            cmd.Parameters.AddWithValue("@book_stock", book_stock);
            int result1 = cmd.ExecuteNonQuery();
            if (result1 > 0)
            {
                Console.WriteLine("book updated successfully");
            }
            else
            {
                Console.WriteLine("book not found");
            }
            return result1;
        }
        public int deletebooks(SqlConnection conn, int id)
        {

            SqlCommand cmd = new SqlCommand($"delete from books where book_id=@id ", conn);
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
        public void issuebook(SqlConnection conn)
        {
            Console.WriteLine("Enter the student id");
            int student_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the book id");
            int bookid = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand($"select * from books where book_id=@bookid", conn);

            cmd.Parameters.AddWithValue("@bookid", bookid);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int book_stock = Convert.ToInt32(reader["book_stock"]);
                if (book_stock != 0)
                {
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand($"insert into issuebook values(@student_id,@bookid)", conn);
                    cmd2.Parameters.AddWithValue("@student_id", student_id);
                    cmd2.Parameters.AddWithValue("@bookid", bookid);


                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Succesfully issued book");
                    SqlCommand cmd3 = new SqlCommand($"update books set book_stock=@book_stock where book_id=@bookid", conn);
                    cmd3.Parameters.AddWithValue("@bookid", bookid);
                    cmd3.Parameters.AddWithValue("@book_stock", book_stock - 1);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Successfully update quantity");
                }
                else
                {
                    Console.WriteLine("Book stock is zero");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }

        }
        public void returnbook(SqlConnection conn)
        {
            Console.WriteLine("Enter the student id");
            int student_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the book id");
            int bookid = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand($"select * from issuebook where student_id=@student_id and bookid=@bookid", conn);
            cmd.Parameters.AddWithValue("@student_id", student_id);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand cmd2 = new SqlCommand($"delete from issuebook where bookid=@bookid AND student_id=@student_id", conn);
                cmd2.Parameters.AddWithValue("@student_id", student_id);
                cmd2.Parameters.AddWithValue("@bookid", bookid);
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Successfully return book");
                SqlCommand cmd3 = new SqlCommand($"update books set book_stock=book_stock +1 where book_id=@bookid", conn);
                cmd3.Parameters.AddWithValue("@bookid", bookid);
                cmd3.ExecuteNonQuery();
                Console.WriteLine("Successfully update quantity");
            }
            else
            {
                Console.WriteLine("No book issued to student");
            }
            reader.Close();
        }
        public string searchbyauthor(SqlConnection conn, string authorname)
        {
            string searchresult = "";
            SqlCommand cmd = new SqlCommand($"select * from books where Author_name=@authorname", conn);

            cmd.Parameters.AddWithValue("@authorname", authorname);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                searchresult = "there is no book with such other";
            }
            else
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        searchresult += ($"{reader[i]} |");
                    }

                }
            }
            reader.Close();
            return searchresult;



        }
        




public void students_having_bookcount(SqlConnection conn)

        {

            try

            {
                SqlCommand cmd = new SqlCommand("select students.Student_name, students.roll, students.department from issuebook join students on students.student_id = issuebook.student_id", conn);

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())

                {

                    Console.WriteLine($"{r["Student_name"]}, {r["roll"]}, {r["department"]}");

                }
                r.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }







    }
}
