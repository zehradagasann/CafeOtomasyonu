using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Mapping;
using CafeOtomasyonu.Entities.Models;
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

namespace CafeOtomasyonu.WinForms.Kullanicilar
{
    public partial class frmKaydol : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private KullanicilarDal kullanicilarDal = new KullanicilarDal();
        private Entities.Models.Kullanicilar _entity;

        // EKSİK OLAN KISIM BURADAYDI:
        public bool kaydet = false;

        public frmKaydol(Entities.Models.Kullanicilar entity)
        {
            InitializeComponent();
            _entity = entity;

            toggleAktifMi.DataBindings.Add("EditValue", _entity, "AktifMi");
            txtAdSoyad.DataBindings.Add("Text", _entity, "AdSoyad");
            txtTelefon.DataBindings.Add("Text", _entity, "Telefon");
            txtAdres.DataBindings.Add("Text", _entity, "Adres");
            txtEmail.DataBindings.Add("Text", _entity, "Email");

            // "txtGörevi" yanlış yazılmıştı, "txtGorevi" olarak düzelttim
            txtGorevii.DataBindings.Add("Text", _entity, "Gorevii");

            txtKullaniciAdi.DataBindings.Add("Text", _entity, "KullaniciAdi");
            txtParola.DataBindings.Add("Text", _entity, "Parola");
            txtSoru.DataBindings.Add("Text", _entity, "HatirlatmaSorusu");
            txtCevap.DataBindings.Add("Text", _entity, "Cevap");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtParola.Text == txtParolaTekrar.Text)
            {
                _entity.KayitTarihi = DateTime.Now;

                // Kullanıcıyı kaydet
                //if (kullanicilarDal.AddOrUpdate(context, _entity))
                {
                   // kullanicilarDal.Save(context);

                    // --- HATALARI DÜZELTEN KISIM ---

                    // 1. Veritabanı işlemini yapacak aracı sınıfı (DAL) oluştur
                   // KullaniciHareketleriDal kullaniciHareketleriDal = new KullaniciHareketleriDal();

                    // 2. İçine veri dolduracağımız hareket nesnesini oluştur (new)
                   // var kullaniciHareketleri = new Entities.Models.KullaniciHareketleri();

                    // 3. Son eklenen kullanıcının ID'sini bulup hareket nesnesine ata
                    var sonKullaniciId = context.Kullanicilar.Max(k => k.Id);
                   // kullaniciHareketleri.Kullaniciİd = sonKullaniciId;

                    // 4. Metodu çağır (Sınıf adıyla değil, oluşturduğun değişken adıyla)
                    string aciklama = "Yeni kullanıcı eklendi";
                   // kullaniciHareketleriDal.KullaniciHareketleriEkle(context, kullaniciHareketleri, aciklama);

                    // -------------------------------

                    kaydet = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}