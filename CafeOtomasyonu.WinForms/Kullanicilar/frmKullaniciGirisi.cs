using System;
using System.Linq;
using System.Windows.Forms;
using CafeOtomasyonu.Entities.Models; // Context ve sınıfların olduğu yer
using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.WinForms.WinTools;    // Dal sınıflarının olduğu yer (Varsa)

namespace CafeOtomasyonu.WinForms.Kullanicilar
{
    public partial class frmKullaniciGirisi : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private bool girisBasariliMi = false; // Değişken ismini daha anlaşılır yaptım

        public frmKullaniciGirisi()
        {
            InitializeComponent();
            // Form açılırken kayıtlı bilgileri getir
            BilgileriGetir();
        }

        void BilgileriGetir()
        {
            if (Properties.Settings.Default.BeniHatirla)
            {
                txtKullaniciAdi.Text = Properties.Settings.Default.KullaniciAdi;
                txtParola.Text = Properties.Settings.Default.Parola;
                checkBeniHatirla.Checked = true;
            }
            else
            {
                txtKullaniciAdi.Text = "";
                txtParola.Text = "";
                checkBeniHatirla.Checked = false;
            }
        }

        void BilgileriKaydet()
        {
            if (checkBeniHatirla.Checked)
            {
                Properties.Settings.Default.KullaniciAdi = txtKullaniciAdi.Text;
                Properties.Settings.Default.Parola = txtParola.Text;
                Properties.Settings.Default.BeniHatirla = true;
            }
            else
            {
                Properties.Settings.Default.KullaniciAdi = "";
                Properties.Settings.Default.Parola = "";
                Properties.Settings.Default.BeniHatirla = false;
            }
            Properties.Settings.Default.Save();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // 69. SATIR HATASI BURADAYDI (Migration yapınca düzelir)
            var model = context.Kullanicilar.FirstOrDefault(k =>
                k.KullaniciAdi == txtKullaniciAdi.Text && k.Parola == txtParola.Text);

            if (model != null)
            {
                girisBasariliMi = true;

                // Beni Hatırla ayarlarını kaydet
                BilgileriKaydet();
                KullaniciAyarları.kullaniciId = model.Id;

                // Kullanıcı Hareketini Kaydet
                //KullaniciHareketleriDal hareketDal = new KullaniciHareketleriDal();
               // KullaniciHareketleri hareket = new KullaniciHareketleri();

               // hareket.Kullaniciİd = model.Id; // İd yazımı entity'de nasılsa öyle olmalı (Id veya KullaniciId)
                string aciklama = "Giriş yapıldı";

               // hareketDal.KullaniciHareketleriEkle(context, hareket, aciklama);

                this.Close(); // Formu kapat (Program.cs ana formu açacak)
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hatalı Giriş",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (!girisBasariliMi)
            {
                Application.Exit();
            }
        }

        private void frmKullaniciGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!girisBasariliMi)
            {
                Application.Exit();
            }
        }

        private void lblKaydol_Click(object sender, EventArgs e)
        {
            // 125. SATIR HATASI BURADAYDI
            // Eğer Migration yapmana rağmen burada hata alıyorsan;
            // frmKaydol formunun constructor (yapıcı) metodunda hata vardır.
            try
            {
                frmKaydol frm = new frmKaydol(new CafeOtomasyonu.Entities.Models.Kullanicilar());
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydol formu açılırken hata: " + ex.Message);
            }
        }

        private void btnParolamiUnuttum_Click(object sender, EventArgs e)
        {
            frmParolamıUnuttum frm = new frmParolamıUnuttum();
            frm.ShowDialog();
        }
    }
}


