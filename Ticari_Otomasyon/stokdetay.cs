using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace Ticari_Otomasyon
{
    public partial class stokdetay : Form
    {
        public stokdetay()
        {
            InitializeComponent();
        }

        public string ad;
        Database database = new Database();
        private void stokdetay_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from urunler where urunad ='"+ ad +"'",database.Connection());
            sqlDataAdapter.Fill(dataTable);
            gridControl2.DataSource = dataTable;
        }
    }
}
