using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    internal class Database
    {
        public SqlConnection Connection() {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=KADIR\SQLEXPRESS;Initial Catalog=TicariOtomasyon;Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection; 
        }
    }
}
