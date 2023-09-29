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
    public partial class faturabilgi : Form
    {
        Database database = new Database();
        public faturabilgi()
        {
            InitializeComponent();
        }

        private void temizle()
        {
            textId.Text = string.Empty;
            textAlici.Text = string.Empty;
            textSeri.Text = string.Empty;
            textSiraNo.Text = string.Empty;
            textTeslimA.Text = string.Empty;
            textTeslimE.Text = string.Empty;
            textVergi.Text = string.Empty;
            maskedSaat.Text = string.Empty;
            maskedTarih.Text = string.Empty;
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from faturabilgi", database.Connection());
            sqlDataAdapter.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void faturabilgi_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                 textId.Text = dataRow["faturabilgiid"].ToString();
                 textAlici.Text = dataRow["alici"].ToString();
                 textSeri.Text = dataRow["seri"].ToString();
                 textSiraNo.Text = dataRow["sirano"].ToString();
                 textTeslimA.Text = dataRow["teslimalan"].ToString();
                 textTeslimE.Text = dataRow["teslimeden"].ToString();
                 textVergi.Text = dataRow["vergidaire"].ToString(); 
                 maskedSaat.Text = dataRow["saat"].ToString();
                 maskedTarih.Text = dataRow["tarih"].ToString();
                 comboBox1.Text = dataRow["cari"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    SqlCommand komut = new SqlCommand("insert into faturabilgi (seri,sirano,tarih,saat,vergidaire,alici,teslimeden,teslimalan,cari) OUTPUT INSERTED.faturabilgiid VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", database.Connection());
                    komut.Parameters.AddWithValue("@p1", textSeri.Text);
                    komut.Parameters.AddWithValue("@p2", textSiraNo.Text);
                    komut.Parameters.AddWithValue("@p3", maskedTarih.Text);
                    komut.Parameters.AddWithValue("@p4", maskedSaat.Text);
                    komut.Parameters.AddWithValue("@p5", textVergi.Text);
                    komut.Parameters.AddWithValue("@p6", textAlici.Text);
                    komut.Parameters.AddWithValue("@p7", textTeslimE.Text);
                    komut.Parameters.AddWithValue("@p8", textTeslimA.Text);
                    komut.Parameters.AddWithValue("@p9", comboBox1.Text);
                    int faturaID = Convert.ToInt32(komut.ExecuteScalar());
                    DialogResult dialogResult = MessageBox.Show("Fatura başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        listele();
                        temizle();
                        faturadetay faturadetay = new faturadetay();
                        faturadetay.faturaid = faturaID.ToString();
                        faturadetay.cariTuru = comboBox1.Text;
                        faturadetay.Show();
                    }
                    database.Connection().Close();
                }
                else
                    MessageBox.Show("Lütfen cari türü seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Faturayı gerçekten silmek istiyor musunuz ?", "Dikkat",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from faturabilgi where faturabilgiid = @p1", database.Connection());
                komut.Parameters.AddWithValue("@p1", textId.Text);
                komut.ExecuteNonQuery();
                database.Connection().Close();
                MessageBox.Show("Fatura başarıyla silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                temizle();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    SqlCommand komut = new SqlCommand("update faturabilgi set seri=@p1,sirano=@p2,tarih=@p3,saat=@p4,vergidaire=@p5,alici=@p6,teslimeden=@p7,teslimalan=@p8,cari=@p10 where faturabilgiid = @p9", database.Connection());
                    komut.Parameters.AddWithValue("@p1", textSeri.Text);
                    komut.Parameters.AddWithValue("@p2", textSiraNo.Text);
                    komut.Parameters.AddWithValue("@p3", DateTime.Parse(maskedTarih.Text));
                    komut.Parameters.AddWithValue("@p4", DateTime.Parse(maskedSaat.Text));
                    komut.Parameters.AddWithValue("@p5", textVergi.Text);
                    komut.Parameters.AddWithValue("@p6", textAlici.Text);
                    komut.Parameters.AddWithValue("@p7", textTeslimE.Text);
                    komut.Parameters.AddWithValue("@p8", textTeslimA.Text);
                    komut.Parameters.AddWithValue("@p9", textId.Text);
                    komut.Parameters.AddWithValue("@p10", comboBox1.Text);
                    komut.ExecuteNonQuery();
                    database.Connection().Close();
                    MessageBox.Show("Fatura başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                    temizle();
                }
                else
                    MessageBox.Show("Lütfen cari türü seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Hatalı veri girişi yapıldı. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            faturadetay faturadetay = new faturadetay();
            DataRow dt = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dt != null)
            {
                faturadetay.faturaid = dt["faturabilgiid"].ToString();
                faturadetay.cariTuru = dt["cari"].ToString();
            }
            faturadetay.Show();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
