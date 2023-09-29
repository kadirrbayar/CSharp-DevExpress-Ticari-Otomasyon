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

namespace Ticari_Otomasyon
{
    public partial class rehber : Form
    {
        Database database = new Database();
        public rehber()
        {
            InitializeComponent();
        }

        private void listele()
        {
            //Müşteriler
            DataTable dataTable = new DataTable();
            SqlDataAdapter cmd = new SqlDataAdapter("select ad,soyad,telefon,telefon2,mail from musteriler", database.Connection());
            cmd.Fill(dataTable);
            gridControl1.DataSource = dataTable;

            //Firmalar
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter cmd2 = new SqlDataAdapter("select ad,yetkiliadsoyad,telefon1,telefon2,telefon3,mail,fax from firmalar", database.Connection());
            cmd2.Fill(dataTable2);
            gridControl2.DataSource = dataTable2;
        }

        private void rehber_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            mail mail = new mail();
            DataRow dataRow = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dataRow != null )
            {
                mail.mailadres = dataRow["mail"].ToString();
            }
            mail.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            mail mail = new mail();
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                mail.mailadres = dataRow["mail"].ToString();
            }
            mail.Show();
        }
    }
}
