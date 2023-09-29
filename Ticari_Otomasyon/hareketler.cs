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
    public partial class hareketler : Form
    {
        public hareketler()
        {
            InitializeComponent();
        }

        Database database = new Database();
        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("exec firmahareket",database.Connection());
            dr.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void musterilistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("exec musterihareket", database.Connection());
            dr.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void hareketler_Load(object sender, EventArgs e)
        {
            musterilistesi();
            firmalistesi();
        }
    }
}
