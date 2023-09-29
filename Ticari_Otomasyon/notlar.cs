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
    public partial class notlar : Form
    {
        Database database = new Database();
        public notlar()
        {
            InitializeComponent();
        }
        private void temizle()
        {
            textBaslik.Text = "";
            textHitap.Text = "";
            textId.Text = "";
            textOlusturan.Text = "";
            maskedSaat.Text = "";
            maskedTarih.Text = "";
            richDetay.Text = "";
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from notlar", database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Not silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand sqlCommand = new SqlCommand("delete from notlar where id = @p1", database.Connection());
                sqlCommand.Parameters.AddWithValue("@p1", textId.Text);
                sqlCommand.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Not başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                temizle();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("insert into notlar (saat,tarih,baslik,detay,olusturan,hitap) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", database.Connection());
                sqlCommand.Parameters.AddWithValue("@p1", DateTime.Parse(maskedSaat.Text));
                sqlCommand.Parameters.AddWithValue("@p2", DateTime.Parse(maskedTarih.Text));
                sqlCommand.Parameters.AddWithValue("@p3", textBaslik.Text);
                sqlCommand.Parameters.AddWithValue("@p4", richDetay.Text);
                sqlCommand.Parameters.AddWithValue("@p5", textOlusturan.Text);
                sqlCommand.Parameters.AddWithValue("@p6", textHitap.Text);
                sqlCommand.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Not başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                temizle();
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("update notlar set saat=@p1,tarih=@p2,baslik=@p3,detay=@p4,olusturan=@p5,hitap=@p6 where id=@p7", database.Connection());
                sqlCommand.Parameters.AddWithValue("@p1", DateTime.Parse(maskedSaat.Text));
                sqlCommand.Parameters.AddWithValue("@p2", DateTime.Parse(maskedTarih.Text));
                sqlCommand.Parameters.AddWithValue("@p3", textBaslik.Text);
                sqlCommand.Parameters.AddWithValue("@p4", richDetay.Text);
                sqlCommand.Parameters.AddWithValue("@p5", textOlusturan.Text);
                sqlCommand.Parameters.AddWithValue("@p6", textHitap.Text);
                sqlCommand.Parameters.AddWithValue("@p7", textId.Text);
                sqlCommand.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Not başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
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
            if (dt != null)
            {
                maskedSaat.Text = dt["saat"].ToString();
                maskedTarih.Text = dt["tarih"].ToString();
                textBaslik.Text = dt["baslik"].ToString();
                richDetay.Text = dt["detay"].ToString();
                textOlusturan.Text = dt["olusturan"].ToString();
                textHitap.Text = dt["hitap"].ToString();
                textId.Text = dt["id"].ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            notonizleme notdetay = new notonizleme();
            DataRow dt = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dt != null)
            {
                notdetay.detay = dt["detay"].ToString();
            }
            notdetay.Show();
        }

        private void notlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
    }
}
