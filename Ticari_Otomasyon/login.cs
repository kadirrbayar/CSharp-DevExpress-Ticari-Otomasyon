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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public string nick;
        Database database = new Database();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from admin where kullaniciadi = @p1 and sifre = @p2",database.Connection());
            command.Parameters.AddWithValue("@p1", textEdit1.Text);
            command.Parameters.AddWithValue("@p2", textEdit2.Text);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                anamodul anamodul = new anamodul();
                nick = textEdit1.Text;
                anamodul.gelenveri = nick;
                anamodul.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
