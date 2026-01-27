using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models; // Modelleri kullanmak için
using DevExpress.XtraEditors;
using System;
using System.Linq; // FirstOrDefault için gerekli
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Kullanicilar
{
    public partial class frmParolamıUnuttum : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        // KullanicilarDal'ı devre dışı bıraktık, doğrudan Context kullanacağız.
        // private KullanicilarDal kullanicilarDal = new KullanicilarDal(); 

        public frmParolamıUnuttum()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Kullanıcıyı DAL yerine doğrudan Context ile buluyoruz (HATA ÇÖZÜMÜ BURADA)
            var entity = context.Kullanicilar.FirstOrDefault(k =>
                k.KullaniciAdi == txtKullaniciAdiEmail.Text ||
                k.Email == txtKullaniciAdiEmail.Text);

            if (entity != null)
            {
                // 2. Güvenlik sorusu ve cevabını kontrol et
                if (entity.HatirlatmaSorusu == txtSoru.Text && entity.Cevap == txtCevapp.Text)
                {
                    // 3. Yeni şifreler eşleşiyor mu?
                    if (txtYeniParola.Text == txtParolaTekrar.Text)
                    {
                        // Şifreyi güncelle
                        entity.Parola = txtYeniParola.Text;

                        // Entity Framework değişiklikleri zaten takip eder, doğrudan kaydediyoruz.
                        context.SaveChanges();

                        // --- HAREKET KAYDI ---
                        try
                        {
                            //KullaniciHareketleri hareket = new KullaniciHareketleri();
                           // hareket.Kullaniciİd = entity.Id;
                            //hareket.Aciklama = entity.KullaniciAdi + " adlı kullanıcının parolası yenilendi.";
                            //hareket.Tarih = DateTime.Now;

                            // Hareketi ekle ve kaydet
                            //context.KullaniciHareketleri.Add(hareket);
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            // Hareket kaydedilemese bile şifre değişti, program patlamasın.
                        }
                        // ---------------------

                        MessageBox.Show("Parolanız başarıyla değiştirildi.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor.");
                    }
                }
                else
                {
                    MessageBox.Show("Girilen soru veya cevap yanlış.");
                }
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
            }
        }

        private void btn_Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}