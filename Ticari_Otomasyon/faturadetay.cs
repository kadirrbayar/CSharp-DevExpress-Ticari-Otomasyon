using DevExpress.CodeParser;
using DevExpress.Utils.DPI;
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
    public partial class faturadetay : Form
    {
        public string faturaid;
        public string cariTuru;

        Database database = new Database();
        public faturadetay()
        {
            InitializeComponent();
        }
        private void temizle()
        {
            textUrunId.Text = "";
            textUrunAd.Text = "";
            numericFiyat.Value = 0;
            maskedTutar.Text = "";
            numericMiktar.Value = 0;
        }
        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from faturadetay where faturaid = @p1", database.Connection());
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@p1", textFaturaId.Text);
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;           

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("select id,ad+' '+soyad as adsoyad from personeller", database.Connection());
            sqlDataAdapter1.Fill(dataTable);
            lookPersonel.Properties.ValueMember = "id";
            lookPersonel.Properties.DisplayMember = "adsoyad";
            lookPersonel.Properties.DataSource = dataTable;
        }

        private void faturadetay_Load(object sender, EventArgs e)
        {
            textFaturaId.Text = faturaid;
            textCari.Text = cariTuru;
            if (cariTuru == "Müşteri")
            {
                firmaLabel.Text = "Müşteri:";
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select id,ad+' '+soyad as adsoyad from musteriler", database.Connection());
                sqlDataAdapter2.Fill(dataTable1);
                lookFirma.Properties.ValueMember = "id";
                lookFirma.Properties.DisplayMember = "adsoyad";
                lookFirma.Properties.DataSource = dataTable1;
            }
            else if (cariTuru == "Firma")
            {
                firmaLabel.Text = "Firma:";
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select id,ad from firmalar", database.Connection());
                sqlDataAdapter2.Fill(dataTable1);
                lookFirma.Properties.ValueMember = "id";
                lookFirma.Properties.DisplayMember = "ad";
                lookFirma.Properties.DataSource = dataTable1;
            }
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                textUrunId.Text = dataRow["faturaurunid"].ToString();
                textUrunAd.Text = dataRow["urunad"].ToString();
                numericFiyat.Value = decimal.Parse(dataRow["fiyat"].ToString());
                maskedTutar.Text = dataRow["tutar"].ToString();
                numericMiktar.Value = int.Parse(dataRow["miktar"].ToString());
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ürünü silmek istiyor musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from faturadetay where faturaurunid = @p1", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textUrunId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("ürün başarıyla silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                listele();
                temizle();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (textUrunId.Text != "" && lookPersonel.EditValue != null && lookFirma.EditValue != null)
            {
                SqlCommand komut = new SqlCommand("insert into faturadetay (faturaurunid,urunad,fiyat,tutar,miktar,faturaid) values(@p0,@p1,@p2,@p3,@p4,@p5)", database.Connection());
                komut.Parameters.AddWithValue("@p0", textUrunId.Text);
                komut.Parameters.AddWithValue("@p1", textUrunAd.Text);
                komut.Parameters.AddWithValue("@p2", numericFiyat.Value);
                komut.Parameters.AddWithValue("@p4", numericMiktar.Value);
                if (numericFiyat.Value != 0 && numericMiktar.Value != 0)
                {
                    decimal fiyat = numericFiyat.Value;
                    decimal miktar = fiyat * numericMiktar.Value;
                    komut.Parameters.AddWithValue("@p3", miktar);
                }
                komut.Parameters.AddWithValue("@p5", textFaturaId.Text);
                komut.ExecuteNonQuery();

                if (cariTuru == "Müşteri")
                {
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO musterihareketler (urunid,adet,personel,musteri,fiyat,toplam,faturaid) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7)", database.Connection());
                    sqlCommand.Parameters.AddWithValue("@k1", textUrunId.Text);
                    sqlCommand.Parameters.AddWithValue("@k2", numericMiktar.Value);
                    sqlCommand.Parameters.AddWithValue("@k3", lookPersonel.EditValue);
                    sqlCommand.Parameters.AddWithValue("@k4", lookFirma.EditValue);
                    sqlCommand.Parameters.AddWithValue("@k5", numericFiyat.Value);
                    if (numericFiyat.Value != 0 && numericMiktar.Value != 0)
                    {
                        decimal fiyat = numericFiyat.Value;
                        decimal miktar = fiyat * numericMiktar.Value;
                        sqlCommand.Parameters.AddWithValue("@k6", miktar);
                    }
                    sqlCommand.Parameters.AddWithValue("@k7", textFaturaId.Text);
                    sqlCommand.ExecuteNonQuery();
                }
                else if (cariTuru == "Firma")
                {
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO firmahareketler (urunid,adet,personel,firma,fiyat,toplam,faturaid) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7)", database.Connection());
                    sqlCommand.Parameters.AddWithValue("@k1", textUrunId.Text);
                    sqlCommand.Parameters.AddWithValue("@k2", numericMiktar.Value);
                    sqlCommand.Parameters.AddWithValue("@k3", lookPersonel.EditValue);
                    sqlCommand.Parameters.AddWithValue("@k4", lookFirma.EditValue);
                    sqlCommand.Parameters.AddWithValue("@k5", numericFiyat.Value);
                    if (numericFiyat.Value != 0 && numericMiktar.Value != 0)
                    {
                        decimal fiyat = numericFiyat.Value;
                        decimal miktar = fiyat * numericMiktar.Value;
                        sqlCommand.Parameters.AddWithValue("@k6", miktar);
                    }
                    sqlCommand.Parameters.AddWithValue("@k7", textFaturaId.Text);
                    sqlCommand.ExecuteNonQuery();
                }

                //stoktan düşme
                SqlCommand sqlCommand2 = new SqlCommand("update urunler set adet=adet-@h1 where id=@h2", database.Connection());
                sqlCommand2.Parameters.AddWithValue("@h1", numericMiktar.Text);
                sqlCommand2.Parameters.AddWithValue("@h2", textUrunId.Text);
                sqlCommand2.ExecuteNonQuery();

                database.Connection().Close();
                MessageBox.Show("ürün başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
                temizle();
            }
            else
                MessageBox.Show("ürün id, personel bilgisi ve müşteri bilgisi boş olmamalıdır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
         

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textUrunId.Text != "" && lookPersonel.EditValue != null && lookFirma.EditValue != null)
                {
                    SqlCommand komut = new SqlCommand("update faturadetay set faturaurunid=@p0,urunad=@p1,fiyat=@p2,tutar=@p3,miktar=@p4,faturaid=@p5 where faturaurunid = @p6", database.Connection());
                    komut.Parameters.AddWithValue("@p0", textUrunId.Text);
                    komut.Parameters.AddWithValue("@p1", textUrunAd.Text);
                    komut.Parameters.AddWithValue("@p2", numericFiyat.Value);
                    komut.Parameters.AddWithValue("@p4", numericMiktar.Value);
                    if (numericFiyat.Value != 0 && numericMiktar.Value != 0)
                    {
                        decimal fiyat = numericFiyat.Value;
                        decimal tutar = fiyat * numericMiktar.Value;
                        komut.Parameters.AddWithValue("@p3", tutar);
                    }
                    komut.Parameters.AddWithValue("@p5", textFaturaId.Text);
                    komut.Parameters.AddWithValue("@p6", textUrunId.Text);
                    komut.ExecuteNonQuery();
                    database.Connection().Close();
                    MessageBox.Show("ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                    temizle();
                }
                else
                    MessageBox.Show("ürün id, personel bilgisi ve müşteri bilgisi boş olmamalıdır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen tekrar deneyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select id,urunad,satisfiyat from urunler where id = @p1", database.Connection());
            komut.Parameters.AddWithValue("@p1", textUrunId.Text);
            SqlDataReader sqlDataReader = komut.ExecuteReader();
            while(sqlDataReader.Read())
            {
                textUrunId.Text = sqlDataReader[0].ToString();
                textUrunAd.Text = sqlDataReader[1].ToString();
                numericFiyat.Text = sqlDataReader[2].ToString();
            }
            database.Connection().Close();
        }
    }
}
