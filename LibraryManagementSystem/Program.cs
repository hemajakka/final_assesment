using System.Data.SqlClient;
namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Server=IN-9SB79S3;database=librarydb;Integrated Security=true");
            conn.Open();
            Books books = new Books();
            Students st = new Students();
            string ans = " ";

            Console.WriteLine("enter username");
            string username = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("select count(*) from userlogin where user_name=@username AND password=@password ", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int count = (int)cmd.ExecuteScalar();
            do
            {
                


                if (count>0)
                {

                    Console.WriteLine("welcome to library management app");

                    Console.WriteLine("1.add book");
                    Console.WriteLine("2.update book");
                    Console.WriteLine("3.delete book");
                    Console.WriteLine("4.issue book");
                    Console.WriteLine("5.add student");
                    Console.WriteLine("6.update student");
                    Console.WriteLine("7.delete student");
                    Console.WriteLine("8.search book by author name");
                    Console.WriteLine("9.search student by roll");
                    Console.WriteLine("10.return book");
                    Console.WriteLine("11.students with books");


                    int choice = 0;
                    try
                    {
                        Console.WriteLine("enter your choice");
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("enter only integer values");
                    }
                    switch (choice)
                    {

                        case 1:
                            {
                                Console.WriteLine("enter book id");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("enter book name");
                                string book_name = Console.ReadLine();
                                Console.WriteLine("enter author name");
                                string Author_name = Console.ReadLine();
                                Console.WriteLine("enter book stock");
                                int book_stock = Convert.ToInt32(Console.ReadLine());
                                books.addbooks(conn, id, book_name, Author_name, book_stock);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("enter the book id you want to update");
                                int id = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("enter the new book name");
                                string name = Console.ReadLine();
                                Console.WriteLine("enter author name");
                                string Author_name = Console.ReadLine();
                                Console.WriteLine("enter new book stock");
                                int book_stock = Convert.ToInt16(Console.ReadLine());
                                books.updatebooks(conn, id, name, Author_name, book_stock);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("enter the id you want to delete");
                                int id = Convert.ToInt16(Console.ReadLine());

                                books.deletebooks(conn, id);

                                break;
                            }
                        case 4:
                            {
                                books.issuebook(conn);
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("enter student id");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("enter student name");
                                string student_name = Console.ReadLine();
                                Console.WriteLine("enter roll number");
                                int roll = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("enter department");
                                string department = Console.ReadLine();
                                st.addstudent(conn, id, student_name, roll, department);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("enter the student id you want to update");
                                int id = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("enter the new student name");
                                string studentname = Console.ReadLine();
                                Console.WriteLine("enter roll number");
                                int roll = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("enter the department");
                                string department = Console.ReadLine();
                                st.updatestudents(conn, id, studentname, roll, department);
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("enter the id you want to delete");
                                int id = Convert.ToInt16(Console.ReadLine());
                                st.deletestudent(conn, id);
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("Enter the authorname to get");
                                string authorname = Console.ReadLine();
                                string searchresult = books.searchbyauthor(conn, authorname);
                                Console.WriteLine(searchresult);
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("Enter the roll number ");
                                int roll = Convert.ToInt16(Console.ReadLine());
                                string result = st.searchstudentbyroll(conn, roll);
                                Console.WriteLine(result);
                                break;
                            }
                        case 10:
                            {
                                books.returnbook(conn);
                                break;
                            }
                        case 11:
                            {
                                books.students_having_bookcount(conn);
                                break;
                            }

                    }
                }
                else
                {
                    Console.WriteLine("please enter correct details");
                    break;
                }

                Console.WriteLine("do you want to continue");
                ans = Console.ReadLine();
                
            } while (ans.ToLower() == "y");
            conn.Close();
        }
    }
    }
