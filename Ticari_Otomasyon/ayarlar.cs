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
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        Database database = new Database();
        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from admin",database.Connection());
            dataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from admin where kullaniciadi = @p1", database.Connection());
                cmd.Parameters.AddWithValue("@p1", textEdit1.Text);
                if (cmd.ExecuteReader().Read())
                {
                    SqlCommand sqlCommand = new SqlCommand("update admin set kullaniciadi = @p1, sifre = @p2 where kullaniciadi = @p3", database.Connection());
                    sqlCommand.Parameters.AddWithValue("@p1", textEdit1.Text);
                    sqlCommand.Parameters.AddWithValue("@p2", textEdit2.Text);
                    sqlCommand.Parameters.AddWithValue("@p3", textEdit1.Text);
                    sqlCommand.ExecuteNonQuery();
                    database.Connection().Close();
                    MessageBox.Show("kayıt başarıyla güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand("insert into admin values(@p1,@p2)", database.Connection());
                    sqlCommand.Parameters.AddWithValue("@p1", textEdit1.Text);
                    sqlCommand.Parameters.AddWithValue("@p2", textEdit2.Text);
                    sqlCommand.ExecuteNonQuery();
                    database.Connection().Close();
                    MessageBox.Show("kayıt başarıyla eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
            }
            catch
            {
                MessageBox.Show("Hatalı giriş yapıldı. Lütfen yeniden deneyiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }        
        }

        void temizle()
        {
            textEdit1.Text = "";
            textEdit2.Text = "";
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow read = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(read != null)
            {
                textEdit1.Text = read["kullaniciadi"].ToString();
                textEdit2.Text = read["sifre"].ToString();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Kaydı gerçekten silmek istiyor musunuz","Önemli",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes) {
                SqlCommand sqlCommand = new SqlCommand("delete from admin where kullaniciadi = @p1", database.Connection());
                sqlCommand.Parameters.AddWithValue("@p1", textEdit1.Text);
                sqlCommand.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("kayıt başarıyla silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();
            }
        }
    }
}
