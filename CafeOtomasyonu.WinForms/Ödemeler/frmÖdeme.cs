using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Mapping;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Ödemeler;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Ödemeler
{
    public partial class frmÖdeme : DevExpress.XtraEditors.XtraForm
    {
        public string _satisKodu;
        public string _odemeTuru;
        public OdemeHareketleri odemeHareketleri;
        public bool kaydedildi;
        public ÖdemeHareketleriDal frm = new ÖdemeHareketleriDal();
        public frmÖdeme(string odemeTuru, string satisKodu)
        {
            InitializeComponent();
            _odemeTuru = odemeTuru;
            _satisKodu = satisKodu;
            if (_odemeTuru == "Nakit")
            {
                lblBaslik.Text = "Nakit Ödeme";
            }
            else if (_odemeTuru == "Kredi Kartı")
            {
                lblBaslik.Text = "Kredi Kartı ile Ödeme";
            }
        }


        private void btnOnay_Click(object sender, EventArgs e)
        {
            odemeHareketleri = new OdemeHareketleri
            {
                SatisKodu = _satisKodu,
                OdemeTuru = _odemeTuru,
                Odenen = calcÖdenecekTutar.Value,
                Aciklama = txtAciklama.Text,
                Tarih = Convert.ToDateTime(dateEditTarih.Text)
            };

            kaydedildi = true;
            this.Close();
        }


        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
