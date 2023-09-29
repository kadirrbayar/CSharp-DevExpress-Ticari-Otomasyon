using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class personeller : Form
    {
        Database database = new Database();
        sehirler sehirler = new sehirler();
        public personeller()
        {
            InitializeComponent();
        }

        private void listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dr = new SqlDataAdapter("SELECT * FROM personeller", database.Connection());
            dr.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }

        private void temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textMail.Text = "";
            textSoyad.Text = "";
            textGorev.Text = "";
            richAdres.Text = "";
            maskedTC.Text = "";
            comboil.Text = "";
            comboilce.Text = "";
            maskedTel.Text = "";
        }

        private void personeller_Load(object sender, EventArgs e)
        {
            sehirler.iller(comboil);
            listele();
            temizle();
        }

        private void comboil_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirler.ilceler(comboil.SelectedIndex + 1, comboilce);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                textId.Text = dataRow["id"].ToString();
                textAd.Text = dataRow["ad"].ToString();
                textSoyad.Text = dataRow["soyad"].ToString();
                maskedTel.Text = dataRow["telefon"].ToString();
                maskedTC.Text = dataRow["tc"].ToString();
                textMail.Text = dataRow["mail"].ToString();
                comboil.Text = dataRow["il"].ToString();
                comboilce.Text = dataRow["ilce"].ToString();
                richAdres.Text = dataRow["adres"].ToString();
                textGorev.Text = dataRow["gorev"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Personeli silmek istiyor musun ?","Önemli",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from personeller where id=@p1", database.Connection());
                komut.Parameters.AddWithValue("@p1", textId.Text);
                komut.ExecuteNonQuery();
                database.Connection().Close();
                listele();
                temizle();
                MessageBox.Show("Personel başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update personeller set ad=@p1,soyad=@p2,telefon=@p3,tc=@p4,mail=@p5,il=@p6,ilce=@p7,adres=@p8,gorev=@p9 where id=@p10", database.Connection());
                komut.Parameters.AddWithValue("@p1", textAd.Text);
                komut.Parameters.AddWithValue("@p2", textSoyad.Text);
                komut.Parameters.AddWithValue("@p3", maskedTel.Text);
                komut.Parameters.AddWithValue("@p4", maskedTC.Text);
                komut.Parameters.AddWithValue("@p5", textMail.Text);
                komut.Parameters.AddWithValue("@p6", comboil.Text);
                komut.Parameters.AddWithValue("@p7", comboilce.Text);
                komut.Parameters.AddWithValue("@p8", richAdres.Text);
                komut.Parameters.AddWithValue("@p9", textGorev.Text);
                komut.Parameters.AddWithValue("@p10", textId.Text);
                komut.ExecuteNonQuery();
                database.Connection().Close();
                listele();
                temizle();
                MessageBox.Show("Personel başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into personeller (ad,soyad,telefon,tc,mail,il,ilce,adres,gorev) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", database.Connection());
                komut.Parameters.AddWithValue("@p1", textAd.Text);
                komut.Parameters.AddWithValue("@p2", textSoyad.Text);
                komut.Parameters.AddWithValue("@p3", maskedTel.Text);
                komut.Parameters.AddWithValue("@p4", maskedTC.Text);
                komut.Parameters.AddWithValue("@p5", textMail.Text);
                komut.Parameters.AddWithValue("@p6", comboil.Text);
                komut.Parameters.AddWithValue("@p7", comboilce.Text);
                komut.Parameters.AddWithValue("@p8", richAdres.Text);
                komut.Parameters.AddWithValue("@p9", textGorev.Text);
                komut.ExecuteNonQuery();
                database.Connection().Close();
                listele();
                temizle();
                MessageBox.Show("Personel başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
