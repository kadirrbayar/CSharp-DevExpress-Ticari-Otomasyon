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
    public partial class raporlar : Form
    {
        public raporlar()
        {
            InitializeComponent();
        }

        private void raporlar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TicariOtomasyonDataSet.musteriler' table. You can move, or remove it, as needed.
            this.musterilerTableAdapter.Fill(this.TicariOtomasyonDataSet.musteriler);
            // TODO: This line of code loads data into the 'TicariOtomasyonDataSet2.firmalar' table. You can move, or remove it, as needed.
            this.firmalarTableAdapter.Fill(this.TicariOtomasyonDataSet2.firmalar);
            // TODO: This line of code loads data into the 'TicariOtomasyonDataSet1.giderler' table. You can move, or remove it, as needed.
            this.giderlerTableAdapter.Fill(this.TicariOtomasyonDataSet1.giderler);
            // TODO: This line of code loads data into the 'TicariOtomasyonDataSet3.personeller' table. You can move, or remove it, as needed.
            this.personellerTableAdapter.Fill(this.TicariOtomasyonDataSet3.personeller);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
