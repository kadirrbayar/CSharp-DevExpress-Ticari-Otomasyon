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
using DevExpress.XtraBars.Ribbon.Internal;

namespace Ticari_Otomasyon
{
    public partial class musteriler : Form
    {
        Database database = new Database();
        sehirler sehirler = new sehirler();

        public musteriler()
        {
            InitializeComponent();
        }

        private void temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textSoyad.Text = "";
            maskedTel.Text = "";
            maskedTel2.Text = "";
            maskedTC.Text = "";
            textMail.Text = "";
            comboil.Text = "";
            comboilce.Text = "";
            richAdres.Text = "";
            textVergi.Text = "";
        }

        private void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM musteriler", database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {
            sehirler.iller(comboil);
            Listele();
            temizle();
        }

        private void comboil_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirler.ilceler(comboil.SelectedIndex + 1, comboilce);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into musteriler (ad,soyad,telefon,telefon2,tc,mail,il,ilce,adres,vergidaire) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", maskedTel.Text);
                cmd.Parameters.AddWithValue("@p4", maskedTel2.Text);
                cmd.Parameters.AddWithValue("@p5", maskedTC.Text);
                cmd.Parameters.AddWithValue("@p6", textMail.Text);
                cmd.Parameters.AddWithValue("@p7", comboil.Text);
                cmd.Parameters.AddWithValue("@p8", comboilce.Text);
                cmd.Parameters.AddWithValue("@p9", richAdres.Text);
                cmd.Parameters.AddWithValue("@p10", textVergi.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Müşteri başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Listele();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Müşteriyi gerçekten silmek istiyor musun ?", "Önemli", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from musteriler where id = @p1", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Müşteri başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Listele();
                temizle();
            }
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
                maskedTel2.Text = dataRow["telefon2"].ToString();
                maskedTC.Text = dataRow["tc"].ToString();
                textMail.Text = dataRow["mail"].ToString();
                comboil.Text = dataRow["il"].ToString();
                comboilce.Text = dataRow["ilce"].ToString();
                richAdres.Text = dataRow["adres"].ToString();
                textVergi.Text = dataRow["vergidaire"].ToString();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update musteriler set ad=@p1,soyad=@p2,telefon=@p3,telefon2=@p4,tc=@p5,mail=@p6,il=@p7,ilce=@p8,adres=@p9,vergidaire=@p10 where id = @p11", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", maskedTel.Text);
                cmd.Parameters.AddWithValue("@p4", maskedTel2.Text);
                cmd.Parameters.AddWithValue("@p5", maskedTC.Text);
                cmd.Parameters.AddWithValue("@p6", textMail.Text);
                cmd.Parameters.AddWithValue("@p7", comboil.Text);
                cmd.Parameters.AddWithValue("@p8", comboilce.Text);
                cmd.Parameters.AddWithValue("@p9", richAdres.Text);
                cmd.Parameters.AddWithValue("@p10", textVergi.Text);
                cmd.Parameters.AddWithValue("@p11", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Müşteri başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Listele();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
