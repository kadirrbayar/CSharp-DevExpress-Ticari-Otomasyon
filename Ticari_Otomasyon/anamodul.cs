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
        musteriler musteriler;
        urunler urunler;
        firmalar firmalar;
        personeller personeller;
        rehber rehber;
        giderler giderler;
        bankalar bankalar;
        faturabilgi faturabilgi;
        notlar notlar;
        hareketler hareketler;
        raporlar raporlar;
        stoklar stoklar;
        anasayfa anasayfa;
        ayarlar ayarlar;
        kasa kasa;
        public string gelenveri;

        public anamodul()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (anasayfa == null || anasayfa.IsDisposed)
            {
                anasayfa = new anasayfa();
                anasayfa.MdiParent = this;
                anasayfa.Show();
            }
        }

        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(urunler == null || urunler.IsDisposed)
            {
                urunler = new urunler();
                urunler.MdiParent = this;
                urunler.Show();
            }
        }

        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (musteriler == null || musteriler.IsDisposed)
            {
                musteriler = new musteriler();
                musteriler.MdiParent = this;
                musteriler.Show();
            }
        }

        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (firmalar == null || firmalar.IsDisposed)
            {
                firmalar = new firmalar();
                firmalar.MdiParent = this;
                firmalar.Show();
            }
        }

        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (personeller == null || personeller.IsDisposed)
            {
                personeller = new personeller();
                personeller.MdiParent = this;
                personeller.Show();
            }
        }

        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rehber == null || rehber.IsDisposed)
            {
                rehber = new rehber();
                rehber.MdiParent = this;
                rehber.Show();
            }
        }

        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (giderler == null || giderler.IsDisposed)
            {
                giderler = new giderler();
                giderler.MdiParent = this;
                giderler.Show();
            }
        }

        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bankalar == null || bankalar.IsDisposed)
            {
                bankalar = new bankalar();
                bankalar.MdiParent = this;
                bankalar.Show();
            }
        }

        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (faturabilgi == null || faturabilgi.IsDisposed)
            {
                faturabilgi = new faturabilgi();
                faturabilgi.MdiParent = this;
                faturabilgi.Show();
            }
        }

        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (notlar == null || notlar.IsDisposed)
            {
                notlar = new notlar();
                notlar.MdiParent = this;
                notlar.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (raporlar == null || raporlar.IsDisposed)
            {
                raporlar = new raporlar();
                raporlar.MdiParent = this;
                raporlar.Show();
            }
        }

        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (hareketler == null || hareketler.IsDisposed)
            {
                hareketler = new hareketler();
                hareketler.MdiParent = this;
                hareketler.Show();
            }
        }

        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stoklar == null || stoklar.IsDisposed)
            {
                stoklar = new stoklar();
                stoklar.MdiParent = this;
                stoklar.Show();
            }
        }

        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (anasayfa == null || anasayfa.IsDisposed)
            {
                anasayfa = new anasayfa();
                anasayfa.MdiParent = this;
                anasayfa.Show();
            }
        }

        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ayarlar == null || ayarlar.IsDisposed)
            {
                ayarlar = new ayarlar();
                ayarlar.Show();
            }
        }
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kasa == null || kasa.IsDisposed)
            {
                kasa = new kasa();
                kasa.kullanici = gelenveri;
                kasa.MdiParent = this;
                kasa.Show();
            }
        }
    }
}
