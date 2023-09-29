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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        Database database = new Database();
        private void listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select urunad,sum(adet) as 'adet' from urunler group by urunad having sum(adet) <= 20 order by sum(adet)", database.Connection());
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        private void notlar()
        {
            DataTable data = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select top 10 tarih,saat,baslik from notlar order by id desc", database.Connection());
            sqlDataAdapter.Fill(data);
            gridControl2.DataSource = data;
        }
        private void fihrist()
        {
            DataTable data = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select ad,telefon1 from firmalar", database.Connection());
            sqlDataAdapter.Fill(data);
            gridControl3.DataSource = data;
        }

        private void hareketler()
        {
            DataTable data = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec firmahareket", database.Connection());
            sqlDataAdapter.Fill(data);
            gridControl4.DataSource = data;
        }
        private void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while(xmloku.Read())
            {
                if(xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
            listele();
            haberler();
            notlar();
            hareketler();
            fihrist();
        }
    }
}
