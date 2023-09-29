using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class mail : Form
    {
        public string mailadres;

        public mail()
        {
            InitializeComponent();
        }

        private void mail_Load(object sender, EventArgs e)
        {
            textMailAdres.Text = mailadres;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            //Mail Gönderme Ayarları:
            MailMessage mail = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mail.To.Add(richMesaj.Text);
            mail.From = new MailAddress("Giden Mail");
            mail.Subject = textKonu.Text;
            mail.Body = richMesaj.Text;
            istemci.Send(mail);
        }
    }
}
