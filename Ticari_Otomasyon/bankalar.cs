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
    public partial class bankalar : Form
    {
        Database database = new Database();
        sehirler sehirler = new sehirler();

        public bankalar()
        {
            InitializeComponent();
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter komut = new SqlDataAdapter("execute bankabilgisi",database.Connection());
            komut.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void firmalistesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select ad,id from firmalar", database.Connection());
            sqlDataAdapter.Fill(dataTable);
            lookFirma.Properties.ValueMember = "id";
            lookFirma.Properties.DisplayMember = "ad";
            lookFirma.Properties.DataSource = dataTable;
        }

        private void temizle()
        {
            textAd.Text = string.Empty;
            textHesap.Text = string.Empty;
            textId.Text = string.Empty;
            textSube.Text = string.Empty;
            textYetkili.Text = string.Empty;
            maskedHesap.Text = string.Empty;
            maskedIban.Text = string.Empty;
            maskedTarih.Text = string.Empty;
            maskedTel.Text = string.Empty;
            lookFirma.EditValue = string.Empty;
            comboil.Text = string.Empty;
            comboilce.Text = string.Empty;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void bankalar_Load(object sender, EventArgs e)
        {
            sehirler.iller(comboil);
            listele();
            firmalistesi();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Banka bilgisini silmek istiyor musunuz ?","Önemli",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from bankalar where id=@p1",database.Connection());
                cmd.Parameters.AddWithValue("@p1", textId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Banka bilgisi başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dt = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dt != null)
            {
                textId.Text = dt["id"].ToString();
                textAd.Text = dt["bankaadi"].ToString();
                comboil.Text = dt["il"].ToString();
                comboilce.Text = dt["ilce"].ToString();
                textSube.Text = dt["sube"].ToString();
                maskedTel.Text = dt["telefon"].ToString();
                maskedIban.Text = dt["iban"].ToString();
                maskedHesap.Text = dt["hesapno"].ToString();
                textYetkili.Text = dt["yetkili"].ToString();
                maskedTarih.Text = dt["tarih"].ToString();
                textHesap.Text = dt["hesapturu"].ToString();
                lookFirma.Text = dt["ad"].ToString();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update bankalar set bankaadi=@p1,il=@p2,ilce=@p3,sube=@p4,telefon=@p5,iban=@p6,hesapno=@p7,yetkili=@p8,tarih=@p9,hesapturu=@p10,firmaid=@p11 where id=@p12", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", comboil.Text);
                cmd.Parameters.AddWithValue("@p3", comboilce.Text);
                cmd.Parameters.AddWithValue("@p4", textSube.Text);
                cmd.Parameters.AddWithValue("@p5", maskedTel.Text);
                cmd.Parameters.AddWithValue("@p6", maskedIban.Text);
                cmd.Parameters.AddWithValue("@p7", maskedHesap.Text);
                cmd.Parameters.AddWithValue("@p8", textYetkili.Text);
                cmd.Parameters.AddWithValue("@p9", maskedTarih.Text);
                cmd.Parameters.AddWithValue("@p10", textHesap.Text);
                cmd.Parameters.AddWithValue("@p11", lookFirma.EditValue);
                cmd.Parameters.AddWithValue("@p12", textId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Banka bilgisi başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı işlem yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into bankalar (bankaadi,il,ilce,sube,telefon,iban,hesapno,yetkili,tarih,hesapturu,firmaid) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", comboil.Text);
                cmd.Parameters.AddWithValue("@p3", comboilce.Text);
                cmd.Parameters.AddWithValue("@p4", textSube.Text);
                cmd.Parameters.AddWithValue("@p5", maskedTel.Text);
                cmd.Parameters.AddWithValue("@p6", maskedIban.Text);
                cmd.Parameters.AddWithValue("@p7", maskedHesap.Text);
                cmd.Parameters.AddWithValue("@p8", textYetkili.Text);
                cmd.Parameters.AddWithValue("@p9", maskedTarih.Text);
                cmd.Parameters.AddWithValue("@p10", textHesap.Text);
                cmd.Parameters.AddWithValue("@p11", lookFirma.EditValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Banka bilgisi başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            } 
            catch
            {
                MessageBox.Show("Hatalı işlem yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboil_SelectedIndexChanged(object sender, EventArgs e)
        {
            sehirler.ilceler(comboil.SelectedIndex + 1, comboilce);
        }
    }
}
