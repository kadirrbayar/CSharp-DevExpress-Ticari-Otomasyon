using DevExpress.XtraGrid;
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
    public partial class anamodul : Form
    {
        urunler urunler;
        musteriler musteriler;
        firmalar firmalar;
        personeller personeller;
        rehber rehber;
        giderler giderler;
        bankalar bankalar;

        public anamodul()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {     

        }

        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(urunler == null)
            {
                urunler = new urunler();
                urunler.MdiParent = this;
                urunler.Show();
            }
        }

        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (musteriler == null)
            {
                musteriler = new musteriler();
                musteriler.MdiParent = this;
                musteriler.Show();
            }
        }

        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (firmalar == null)
            {
                firmalar = new firmalar();
                firmalar.MdiParent = this;
                firmalar.Show();
            }
        }

        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (personeller == null)
            {
                personeller = new personeller();
                personeller.MdiParent = this;
                personeller.Show();
            }
        }

        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rehber == null)
            {
                rehber = new rehber();
                rehber.MdiParent = this;
                rehber.Show();
            }
        }

        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (giderler == null)
            {
                giderler = new giderler();
                giderler.MdiParent = this;
                giderler.Show();
            }
        }

        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bankalar == null)
            {
                bankalar = new bankalar();
                bankalar.MdiParent = this;
                bankalar.Show();
            }
        }
    }
}
