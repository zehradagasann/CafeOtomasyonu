using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Urunler
{
    public partial class frmÜrünKaydetme : DevExpress.XtraEditors.XtraForm
    {
        private MenuDal menuDal = new MenuDal();
        private UrunDal urunDal = new UrunDal();

        // Form içinde kullanacağımız aktif ürün değişkeni
        private Urun _entity;

        private CafeContext context = new CafeContext();
        public bool kaydet = false;

        public frmÜrünKaydetme(Urun entity)
        {
            InitializeComponent();

            _entity = entity;

            // 1. Menü Seçim Kutusunu (LookUpEdit) Doldurma
            lookUpMenu.Properties.DataSource = menuDal.GetAll(context);

            // 2. Veri Bağlama (DataBindings) İşlemleri
            // Veritabanındaki alanları formdaki kutucuklarla eşleştiriyoruz.
            lookUpMenu.DataBindings.Add("EditValue", _entity, "MenuId");
            txtUrunKodu.DataBindings.Add("Text", _entity, "UrunKodu");
            txtUrunAdi.DataBindings.Add("Text", _entity, "UrunAdi");
            calcBirimFiyatı1.DataBindings.Add("EditValue", _entity, "BirimFiyati1", true, DataSourceUpdateMode.OnPropertyChanged);
            calcBirimFiyatı2.DataBindings.Add("EditValue", _entity, "BirimFiyati2", true);
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
            dateEdit1.DataBindings.Add("Text", _entity, "Tarih");

            // 3. Resim Yükleme Kontrolü
            // Eğer düzenleme yapıyorsak (Id 0 değilse) ve kayıtlı bir resim varsa onu getir.
            if (_entity.Id != 0)
            {
                if (_entity.Resim != "")
                {
                    pictureEdit1.EditValue = _entity.Resim;

                }
            }
        }



        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            string kaynakDosya = pictureEdit1.GetLoadedImageLocation();

            if (!string.IsNullOrEmpty(kaynakDosya))
            {
                string hedefyol = $"{Application.StartupPath}\\Image\\{txtUrunAdi.Text}-{txtUrunKodu.Text}.png";

                // Klasör yoksa oluştur
                if (!Directory.Exists($"{Application.StartupPath}\\Image"))
                {
                    Directory.CreateDirectory($"{Application.StartupPath}\\Image");
                }

                // Resmi kopyala
                File.Copy(kaynakDosya, hedefyol, true);

                // Veritabanı için yol bilgisini güncelle
                _entity.Resim = $"Image\\{txtUrunAdi.Text}-{txtUrunKodu.Text}.png";
            }
            // --- RESİM KAYDETME İŞLEMİ (BİTİŞ) ---


            // --- VERİTABANI KAYIT İŞLEMİ ---
            if (urunDal.AddOrUpdate(context, _entity))
            {
                urunDal.Save(context);
                kaydet = true;
                this.Close();
            }
        }
    }
}