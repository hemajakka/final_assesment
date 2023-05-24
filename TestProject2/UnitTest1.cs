using LibraryManagementSystem;
using System.Data.SqlClient;
using Moq;
namespace TestProject2
{
    public class Tests
    {
        private SqlConnection conn;
        private Books obj1;
        private Students obj2;

        [SetUp]
        public void Setup()
        {
            conn = new SqlConnection("Server=IN-9SB79S3;database=librarydb;Integrated Security=true");
            obj1 = new Books();
            obj2 = new Students();

        }

        [Test]
        public void SearchByAuthor_NoBooksFound_ReturnsErrorMessage()
        {

            string authorName = "John Doe";
            string expectedResult = "there is no book with such other";
            conn.Open();
            var result = obj1.searchbyauthor(conn, authorName);
            Assert.AreEqual(expectedResult, result);
            conn.Close();

        }
        [Test]
        public void SearchByAuthor_BooksFound_ReturnsBookDetails()
        {

            string authorname = "abc";
            string expectedBookDetails = "1 |python |abc |2 |";
            conn.Open();
            var result = obj1.searchbyauthor(conn, authorname);
            Assert.That(result, Is.EqualTo(expectedBookDetails));
            conn.Close();

        }
        [Test]
        public void SearchByRoll_NoStudentsFound_ReturnsErrorMessage()
        {

            int roll = 85;
            string expectedResult = "There is no student with such roll number";
            conn.Open();
            var result = obj2.searchstudentbyroll(conn, roll);
            Assert.AreEqual(expectedResult, result);
            conn.Close();

        }
        [Test]
        public void SearchByRoll_studentsFound_ReturnsStudentDetails()
        {

            int roll = 71;
            string expectedstudentDetails = "2 |abi |71 |ece |";
            conn.Open();
            var result = obj2.searchstudentbyroll(conn, roll);
            Assert.That(result, Is.EqualTo(expectedstudentDetails));
            conn.Close();

        }

        [Test]
        public void Add_student_Details_WhenCalled_Return_Count()
        {
            var student = new Mock<IStudents>();
            student.Setup(x => x.addstudent(conn,1,"hema",77,"cse")).Returns(1);
            var result = student.Object.addstudent(conn, 1, "hema", 77, "cse");
            Assert.That(result,Is.EqualTo(1));
        }
        [Test]
        public void Edit_student_Details_WhenCalled_Return_Count()
        {
            var student = new Mock<IStudents>();
            student.Setup(x => x.updatestudents(conn, 1, "hema", 78, "cse")).Returns(1);
            var result = student.Object.updatestudents(conn, 1, "hema", 78, "cse");
            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void Delete_student_Details_WhenCalled_Return()
        {
            var student= new Mock<IStudents>();
            student.Setup(x => x.deletestudent(conn,1)).Returns(1);
            var result = student.Object.deletestudent(conn,1);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Add_Book_Details_WhenCalled_Return()
        {
            var book = new Mock<IBooks>();
            book.Setup(x => x.addbooks(conn, 1,"python","abc",3)).Returns(1);
            var result = book.Object.addbooks(conn, 1, "python", "abc", 3);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void update_Book_Details_WhenCalled_Return()
        {
            var book = new Mock<IBooks>();
            book.Setup(x => x.updatebooks(conn, 1, "python", "abc", 4)).Returns(1);
            var result = book.Object.updatebooks(conn, 1, "python", "abc", 4);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void delete_Book_Details_WhenCalled_Return()
        {
            var book = new Mock<IBooks>();
            book.Setup(x => x.deletebooks(conn, 1)).Returns(1);
            var result = book.Object.deletebooks(conn, 1);
            Assert.That(result, Is.EqualTo(1));
        }
        





    }
    
}