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
using System.Data.Common;

namespace Ticari_Otomasyon
{
    public partial class firmalar : Form
    {
        Database database = new Database();
        sehirler sehirler = new sehirler();

        public firmalar()
        {
            InitializeComponent();
        }

        private void kodlar()
        {
            SqlCommand cmd = new SqlCommand("select firmakod1 from kodlar", database.Connection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                richKod1.Text = dr[0].ToString();
            }
            database.Connection().Close();
           
        }

        private void temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textSektor.Text = "";
            textYetkili.Text = "";
            textYetkiliGorev.Text = "";
            maskedTC.Text = "";
            maskedTel1.Text = "";
            maskedTel2.Text = "";
            maskedTel3.Text = "";
            maskedFax.Text = "";
            textMail.Text = "";
            comboil.Text = "";
            comboilce.Text = "";
            textvergi.Text = "";
            richAdres.Text = "";
            textKod1.Text = "";
            textKod2.Text = "";
            textKod3.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                textId.Text = dataRow["id"].ToString();
                textAd.Text = dataRow["ad"].ToString();
                textSektor.Text = dataRow["firmastatu"].ToString();
                textYetkili.Text = dataRow["yetkiliadsoyad"].ToString();
                textYetkiliGorev.Text = dataRow["yetkilistatu"].ToString();
                maskedTC.Text = dataRow["yetkilitc"].ToString();
                maskedTel1.Text = dataRow["telefon1"].ToString();
                maskedTel2.Text = dataRow["telefon2"].ToString();
                maskedTel3.Text = dataRow["telefon3"].ToString();
                maskedFax.Text = dataRow["fax"].ToString();
                textMail.Text = dataRow["mail"].ToString();
                comboil.Text = dataRow["il"].ToString();
                comboilce.Text = dataRow["ilce"].ToString();
                textvergi.Text = dataRow["vergidaire"].ToString();
                richAdres.Text = dataRow["adres"].ToString();
                textKod1.Text = dataRow["ozelkod1"].ToString();
                textKod2.Text = dataRow["ozelkod2"].ToString();
                textKod3.Text = dataRow["ozelkod3"].ToString();
            }
        }

        private void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM firmalar", database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void firmalar_Load(object sender, EventArgs e)
        {
            sehirler.iller(comboil);
            firmaListesi();
            temizle();
            kodlar();
        }

        private void comboilce_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into firmalar (ad,yetkilistatu,yetkiliadsoyad,yetkilitc,firmastatu,telefon1,telefon2,telefon3,mail,fax,il,ilce,vergidaire,adres,ozelkod1,ozelkod2,ozelkod3) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
                cmd.Parameters.AddWithValue("@p3", textYetkili.Text);
                cmd.Parameters.AddWithValue("@p4", maskedTC.Text);
                cmd.Parameters.AddWithValue("@p5", textSektor.Text);
                cmd.Parameters.AddWithValue("@p6", maskedTel1.Text);
                cmd.Parameters.AddWithValue("@p7", maskedTel2.Text);
                cmd.Parameters.AddWithValue("@p8", maskedTel3.Text);
                cmd.Parameters.AddWithValue("@p9", textMail.Text);
                cmd.Parameters.AddWithValue("@p10", maskedFax.Text);
                cmd.Parameters.AddWithValue("@p11", comboil.Text);
                cmd.Parameters.AddWithValue("@p12", comboilce.Text);
                cmd.Parameters.AddWithValue("@p13", textvergi.Text);
                cmd.Parameters.AddWithValue("@p14", richAdres.Text);
                cmd.Parameters.AddWithValue("@p15", textKod1.Text);
                cmd.Parameters.AddWithValue("@p16", textKod2.Text);
                cmd.Parameters.AddWithValue("@p17", textKod3.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Firma başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firmaListesi();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboil_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirler.ilceler(comboil.SelectedIndex + 1, comboilce);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update firmalar set ad=@p1,yetkilistatu=@p2,yetkiliadsoyad=@p3,yetkilitc=@p4,firmastatu=@p5,telefon1=@p6,telefon2=@p7,telefon3=@p8,mail=@p9,fax=@p10,il=@p11,ilce=@p12,vergidaire=@p13,adres=@p14,ozelkod1=@p15,ozelkod2=@p16,ozelkod3=@p17 where id=@p18", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
                cmd.Parameters.AddWithValue("@p3", textYetkili.Text);
                cmd.Parameters.AddWithValue("@p4", maskedTC.Text);
                cmd.Parameters.AddWithValue("@p5", textSektor.Text);
                cmd.Parameters.AddWithValue("@p6", maskedTel1.Text);
                cmd.Parameters.AddWithValue("@p7", maskedTel2.Text);
                cmd.Parameters.AddWithValue("@p8", maskedTel3.Text);
                cmd.Parameters.AddWithValue("@p9", textMail.Text);
                cmd.Parameters.AddWithValue("@p10", maskedFax.Text);
                cmd.Parameters.AddWithValue("@p11", comboil.Text);
                cmd.Parameters.AddWithValue("@p12", comboilce.Text);
                cmd.Parameters.AddWithValue("@p13", textvergi.Text);
                cmd.Parameters.AddWithValue("@p14", richAdres.Text);
                cmd.Parameters.AddWithValue("@p15", textKod1.Text);
                cmd.Parameters.AddWithValue("@p16", textKod2.Text);
                cmd.Parameters.AddWithValue("@p17", textKod3.Text);
                cmd.Parameters.AddWithValue("@p18", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Firma başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                firmaListesi();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Firmayı gerçekten silmek istiyor musun ?", "Önemli", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from firmalar where id = @p1", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Firma başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firmaListesi();
                temizle();
            }
        }
    }
}
