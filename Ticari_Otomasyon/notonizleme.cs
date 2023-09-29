using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class notonizleme : Form
    {
        public notonizleme()
        {
            InitializeComponent();
        }
        public string detay;
        private void notonizleme_Load(object sender, EventArgs e)
        {
            detayTextBox.Text = detay;
        }
    }
}
