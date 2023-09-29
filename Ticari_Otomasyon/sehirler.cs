using DevExpress.Pdf;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    internal class sehirler
    {
        Database database = new Database();
        public void iller(ComboBoxEdit il)
        {
            il.Properties.Items.Clear();
            SqlCommand sqlCommand = new SqlCommand("Select sehir From iller", database.Connection());
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                il.Properties.Items.Add(reader[0].ToString());
            }
            database.Connection().Close();
        }
        public void ilceler(int il, ComboBoxEdit ilce)
        {
            ilce.Properties.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select ilce from ilceler where sehir = @p1", database.Connection());
            cmd.Parameters.AddWithValue("@p1", il);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ilce.Properties.Items.Add(reader[0].ToString());
            }
            database.Connection().Close();
        }
    }
}
