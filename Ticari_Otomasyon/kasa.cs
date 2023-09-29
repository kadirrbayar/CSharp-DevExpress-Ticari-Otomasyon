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
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }

        public string kullanici;
        Database database = new Database();
        int timer,sayac = 0;

        void listele()
        {
            string sql = "exec firmahareket";
            string sql2 = "exec musterihareket";

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql,database.Connection());
            sqlDataAdapter.Fill(dataTable);
            gridControl2.DataSource = dataTable;

            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sql2, database.Connection());
            sqlDataAdapter2.Fill(dataTable2);
            gridControl3.DataSource = dataTable2;
        }

        void giderler()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from giderler", database.Connection());
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }

        void sql()
        {
            List<string> list = new List<string>() { 
                "select sum(tutar) from faturadetay",
                "select top 1 (elektrik+su+dogalgaz+internet+ekstra) from giderler order by id desc",
                "select top 1 maaslar from giderler order by id desc", 
                "select count(*) from musteriler", 
                "select count(*) from firmalar",
                "select count(distinct(il)) from firmalar", 
                "select count(distinct(il)) from musteriler", 
                "select count(*) from personeller", 
                "select sum(adet) from urunler" 
            };
            List<string> list1 = new List<string>();
            for(int i = 0; i < 9; i++)
            {
                SqlCommand sqlCommand = new SqlCommand(list[i], database.Connection());
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    list1.Add(dataReader[0].ToString());
                }
            }
            database.Connection().Close();
            toplamText.Text = list1[0] + "₺";
            odemeText.Text = list1[1] + "₺";
            personelText.Text = list1[2] + "₺";
            musteriText.Text = list1[3];
            firmaText.Text = list1[4];
            firmaSehirText.Text = list1[5];
            müsteriSehirText.Text = list1[6];
            personelSayiText.Text = list1[7];
            stokText.Text = list1[8];
        }

        private void kasa_Load(object sender, EventArgs e)
        {
            sql();
            listele();
            giderler();  
            activeText.Text = kullanici;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            string giderAdi = "";
            if (sayac > 25)
                sayac = 1;        
            if (sayac > 20)           
                giderAdi = "Ekstra";         
            else if (sayac > 15)            
                giderAdi = "İnternet";          
            else if (sayac > 10)          
                giderAdi = "Su";           
            else if (sayac > 5)           
                giderAdi = "Elektrik";      
            else if (sayac > 0)            
                giderAdi = "Doğalgaz";

            groupControl10.Text = giderAdi;
            chartControl1.Series["Aylar"].Points.Clear();
            string giderKolonAdi = "";
            switch (giderAdi)
            {
                case "Elektrik":
                    giderKolonAdi = "elektrik";
                    break;
                case "Su":
                    giderKolonAdi = "su";
                    break;
                case "Doğalgaz":
                    giderKolonAdi = "dogalgaz";
                    break;
                case "İnternet":
                    giderKolonAdi = "internet";
                    break;
                case "Ekstra":
                    giderKolonAdi = "ekstra";
                    break;
            }

            if (!string.IsNullOrEmpty(giderKolonAdi))
            {
                using (SqlCommand sqlCommand = new SqlCommand($"select top 4 ay, {giderKolonAdi} from giderler order by id desc", database.Connection()))
                {
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer++;
            string giderAdi = "";
            if (timer > 25)
                timer = 1;
            if (timer > 20)
                giderAdi = "Elektrik";
            else if (timer > 15)
                giderAdi = "Su";
            else if (timer > 10)
                giderAdi = "Doğalgaz";
            else if (timer > 5)
                giderAdi = "İnternet";
            else if (timer > 0)
                giderAdi = "Ekstra";

            groupControl11.Text = giderAdi;
            chartControl2.Series["Aylar"].Points.Clear();
            string giderKolonAdi = "";
            switch (giderAdi)
            {
                case "Elektrik":
                    giderKolonAdi = "elektrik";
                    break;
                case "Su":
                    giderKolonAdi = "su";
                    break;
                case "Doğalgaz":
                    giderKolonAdi = "dogalgaz";
                    break;
                case "İnternet":
                    giderKolonAdi = "internet";
                    break;
                case "Ekstra":
                    giderKolonAdi = "ekstra";
                    break;
            }

            if (!string.IsNullOrEmpty(giderKolonAdi))
            {
                using (SqlCommand sqlCommand = new SqlCommand($"select top 4 ay, {giderKolonAdi} from giderler order by id desc", database.Connection()))
                {
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                    }
                }
            }
        }
    }
}
