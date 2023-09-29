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
    public partial class urunler : Form
    {
        Database database = new Database();
        public urunler()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM urunler", database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textMarka.Text = "";
            textModel.Text = "";
            maskedYıl.Text = "";
            numericAdet.Value = 0;
            textAlis.Text = "";
            textSatis.Text = "";
            richTextDetay.Text = "";
            textId.Text = "";
        }

        private void Urunler_Load(object sender, EventArgs e)
        {
            Listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into urunler (urunad,marka,model,yil,adet,alisfiyat,satisfiyat,detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textMarka.Text);
                cmd.Parameters.AddWithValue("@p3", textModel.Text);
                cmd.Parameters.AddWithValue("@p4", maskedYıl.Text);
                cmd.Parameters.AddWithValue("@p5", int.Parse((numericAdet.Value).ToString()));
                cmd.Parameters.AddWithValue("@p6", decimal.Parse(textAlis.Text));
                cmd.Parameters.AddWithValue("@p7", decimal.Parse(textSatis.Text));
                cmd.Parameters.AddWithValue("@p8", richTextDetay.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Başarıyla kayıt eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dt = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textId.Text = dt["id"].ToString();
            textAd.Text = dt["urunad"].ToString();
            textMarka.Text = dt["marka"].ToString();
            textModel.Text = dt["model"].ToString();
            maskedYıl.Text = dt["yil"].ToString();
            numericAdet.Value = int.Parse(dt["adet"].ToString());
            textAlis.Text = dt["alisfiyat"].ToString();
            textSatis.Text = dt["satisfiyat"].ToString();
            richTextDetay.Text = dt["detay"].ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kaydı silmek istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from urunler where id = @p1", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                Listele();
                temizle();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update urunler set urunad = @p1, marka = @p2, model = @p3, yil = @p4, adet = @p5, alisfiyat = @p6, satisfiyat = @p7, detay = @p8 where id = @p10", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textAd.Text);
                cmd.Parameters.AddWithValue("@p2", textMarka.Text);
                cmd.Parameters.AddWithValue("@p3", textModel.Text);
                cmd.Parameters.AddWithValue("@p4", maskedYıl.Text);
                cmd.Parameters.AddWithValue("@p5", int.Parse((numericAdet.Value).ToString()));
                cmd.Parameters.AddWithValue("@p6", decimal.Parse(textAlis.Text));
                cmd.Parameters.AddWithValue("@p7", decimal.Parse(textSatis.Text));
                cmd.Parameters.AddWithValue("@p8", richTextDetay.Text);
                cmd.Parameters.AddWithValue("@p10", textId.Text);
                cmd.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Başarıyla kayıt güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
