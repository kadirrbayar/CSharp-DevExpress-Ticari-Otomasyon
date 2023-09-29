using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class giderler : Form
    {
        Database database = new Database();
        public giderler()
        {
            InitializeComponent();
        }

        private void temizle()
        {
            textDogalgaz.Text = "";
            textEkstra.Text = "";
            textElektrik.Text = "";
            textInternet.Text = "";
            textMaaslar.Text = "";
            textSu.Text = "";
            richNotlar.Text = "";
            comboay.Text = "";
            comboyil.Text = "";
            textId.Text = "";
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from giderler",database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;       
        }

        private void giderler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow sqlDataReader = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (sqlDataReader != null)
            {
                textId.Text = sqlDataReader["id"].ToString();
                comboay.Text = sqlDataReader["ay"].ToString();
                comboyil.Text = sqlDataReader["yil"].ToString();
                textElektrik.Text = sqlDataReader["elektrik"].ToString();
                textSu.Text = sqlDataReader["su"].ToString();
                textDogalgaz.Text = sqlDataReader["dogalgaz"].ToString();
                textInternet.Text = sqlDataReader["internet"].ToString();
                textEkstra.Text = sqlDataReader["ekstra"].ToString();
                textMaaslar.Text = sqlDataReader["maaslar"].ToString();
                richNotlar.Text = sqlDataReader["notlar"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Kaydı gerçekten silmek istiyor musunuz ?", "Önemli", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from giderler where id=@p1", database.Connection());
                komut.Parameters.AddWithValue("@p1", textId.Text);
                komut.ExecuteNonQuery();
                listele();
                temizle();
                MessageBox.Show("Kayıt başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update giderler set ay=@p1,yil=@p2,elektrik=@p3,su=@p4,dogalgaz=@p5,internet=@p6,ekstra=@p7,maaslar=@p8,notlar=@p9 where id = @p10", database.Connection());
                komut.Parameters.AddWithValue("@p1", comboay.Text);
                komut.Parameters.AddWithValue("@p2", comboyil.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(textElektrik.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textSu.Text));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(textInternet.Text));
                komut.Parameters.AddWithValue("@p7", decimal.Parse(textEkstra.Text));
                komut.Parameters.AddWithValue("@p8", decimal.Parse(textMaaslar.Text));
                komut.Parameters.AddWithValue("@p9", richNotlar.Text);
                komut.Parameters.AddWithValue("@p10", textId.Text);
                komut.ExecuteNonQuery();
                listele();
                temizle();
                MessageBox.Show("Kayıt başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                SqlCommand komut = new SqlCommand("insert into giderler (ay,yil,elektrik,su,dogalgaz,internet,ekstra,maaslar,notlar) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", database.Connection());
                komut.Parameters.AddWithValue("@p1", comboay.Text);
                komut.Parameters.AddWithValue("@p2", comboyil.Text);
                komut.Parameters.AddWithValue("@p3", decimal.Parse(textElektrik.Text));
                komut.Parameters.AddWithValue("@p4", decimal.Parse(textSu.Text));
                komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(textInternet.Text));
                komut.Parameters.AddWithValue("@p7", decimal.Parse(textEkstra.Text));
                komut.Parameters.AddWithValue("@p8", decimal.Parse(textMaaslar.Text));
                komut.Parameters.AddWithValue("@p9", richNotlar.Text);
                komut.ExecuteNonQuery();
                listele();
                temizle();
                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
