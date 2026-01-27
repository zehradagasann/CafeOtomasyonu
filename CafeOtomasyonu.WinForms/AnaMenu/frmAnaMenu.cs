using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Hakkımızda;
using CafeOtomasyonu.WinForms.Kullanicilar;
using CafeOtomasyonu.WinForms.Masalar;
using CafeOtomasyonu.WinForms.Menuler;
using CafeOtomasyonu.WinForms.Musteriler;
using CafeOtomasyonu.WinForms.Urunler;
using CafeOtomasyonu.WinForms.Yardim;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.AnaMenu
{
    public partial class frmAnaMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        void FormGetir(Form frm)      // <-- Sadece "Form" yap
        {
            frm.MdiParent = this;
            frm.Show();
        }

        public frmAnaMenu()
        {
            InitializeComponent();
            frmKullaniciGirisi frm = new frmKullaniciGirisi();
            frm.ShowDialog();
        }

        private void btnÜrünler2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUrunler frm = new frmUrunler();
            // FormGetir(frm); // Bu satırı iptal et (başına // koy)

            frm.ShowDialog(); // Yerine bunu yaz
        }

        private void btnMenüler1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMenuler frm = new frmMenuler();
            frm.ShowDialog();
        }

        private void btnMasalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Burası sadece liste formunu açmalı
            Masalar.frmMasalar frm = new Masalar.frmMasalar();
            frm.ShowDialog();
        }

        private void btnMasaSiparisleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Renkli masaların olduğu form burada açılmalı
            Masalar.MasaDurumu frm = new Masalar.MasaDurumu();
            frm.ShowDialog();
        }

        private void btnMüsteriler_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm frm = new btnMüsteriler();
            frm.ShowDialog();
        }

        private void btnHakkımızda2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHakkimizda hakkimizdaFormu = new frmHakkimizda();

            hakkimizdaFormu.StartPosition = FormStartPosition.CenterScreen;

            hakkimizdaFormu.ShowDialog();
        }

        private void btnYardım2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmYardim yardimFormu = new frmYardim();
            yardimFormu.StartPosition = FormStartPosition.CenterScreen;
            yardimFormu.ShowDialog();
        }
    }
    }
    
    
    
