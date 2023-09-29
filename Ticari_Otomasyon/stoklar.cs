using DevExpress.DataProcessing.InMemoryDataProcessor;
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
    public partial class stoklar : Form
    {
        public stoklar()
        {
            InitializeComponent();
        }

        Database database = new Database();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("Select urunad,sum(adet) as 'Miktar' from urunler group by urunad", database.Connection());
            dr.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void sehirler()
        {
            SqlCommand sqlCommand = new SqlCommand("Select il, count(*) from firmalar group by il", database.Connection());
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            database.Connection().Close();
        }

        private void stoklar_Load(object sender, EventArgs e)
        {
            listele();
            SqlCommand sqlCommand = new SqlCommand("Select urunad,sum(adet) as 'Miktar' from urunler group by urunad", database.Connection());
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            database.Connection().Close();
            sehirler();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            stokdetay stokdetay = new stokdetay();
            DataRow dataRow = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dataRow != null )
            {
                stokdetay.ad = dataRow["urunad"].ToString();
            }
            stokdetay.Show();
        }
    }
}
