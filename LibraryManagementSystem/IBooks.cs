using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IBooks
    {
        public int addbooks(SqlConnection conn, int id, string book_name, string Author_name, int book_stock);
        public int updatebooks(SqlConnection conn, int id, string name, string Author_name, int book_stock);
        public int deletebooks(SqlConnection conn, int id);

    }
}
