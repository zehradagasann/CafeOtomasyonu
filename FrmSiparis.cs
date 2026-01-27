using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CafeOtomasyonu
{
    public partial class FrmSiparis : Form
    {
        int _masaId = 0;
        CafeOtomasyonEntities db = new CafeOtomasyonEntities();
        List<AdisyonHareketler> siparisler = new List<AdisyonHareketler>();

        public FrmSiparis(int gelenMasaId)
        {
            InitializeComponent();
            _masaId = gelenMasaId;
        }
        private void FrmSiparis_Load_1(object sender, EventArgs e)
        {
            var masa = db.Masalar.Find(_masaId);
            if (masa != null)
            {
                this.Text = masa.MasaAdi + " - Sipariş Ekranı";
            }

            var aktifAdisyon = db.Adisyonlar
                           .FirstOrDefault(a => a.MasaId == _masaId && a.Durum == true);

            if (aktifAdisyon != null)
            {
                siparisler = db.AdisyonHareketler
                               .Where(h => h.AdisyonId == aktifAdisyon.Id)
                               .ToList();
            }

            gridSiparisler.DataSource = siparisler;
            MenuleriYukle();
        }

        void MenuleriYukle()
        {
            var gruplar = db.Kategoriler.ToList();

            foreach (var grup in gruplar)
            {
                XtraTabPage sayfa = new XtraTabPage();
                sayfa.Text = grup.KategoriAdi;

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Dock = DockStyle.Fill;
                panel.AutoScroll = true;
                panel.Tag = grup.Id;

                UrunleriYukle(grup.Id, panel);

                sayfa.Controls.Add(panel);

                tabMenu.TabPages.Add(sayfa);
            }
            tabMenu.Refresh();
        }
        void UrunleriYukle(int KategoriId, FlowLayoutPanel panel)
        {
            // Seçilen kategoriye ait ürünleri veritabanından çekelim
            var urunler = db.Urunler.Where(u => u.KategoriId == KategoriId).ToList();

            foreach (var urun in urunler)
            {
                // Her ürün için bir buton (kutucuk) oluşturalım
                SimpleButton btn = new SimpleButton();
                btn.Text = urun.UrunAdi + "\n" + urun.Fiyat.Value.ToString("C2"); // Fiyatı para formatında göster
                btn.Tag = urun.Id; // Ürün ID'sini butona sakla
                btn.Size = new System.Drawing.Size(120, 80); // Buton boyutunu ayarla

                // Butona tıklandığında siparişe ekleme işlemini yapacak metot (bir sonraki aşama)
                btn.Click += UrunButonu_Click;

                panel.Controls.Add(btn);
            }
        }

        private void UrunButonu_Click(object sender, EventArgs e)
        {
            SimpleButton tiklananButon = (SimpleButton)sender;
            int urunId = (int)tiklananButon.Tag;

            // GridControl adını 'gridControl1' olarak kabul ediyoruz. Eğer senin adın farklıysa düzelt.
            var siparisListesi = (List<AdisyonHareketler>)gridSiparisler.DataSource;

            var mevcutUrun = siparisListesi.FirstOrDefault(x => x.UrunId == urunId);

            if (mevcutUrun != null)
            {
                mevcutUrun.Miktar++;
            }
            else
            {
                var urun = db.Urunler.Find(urunId);

                AdisyonHareketler yeniSiparis = new AdisyonHareketler
                {
                    UrunId = urunId,
                    // Urun nesnesini eklemeyi kaldırıyoruz veya yorum satırı yapıyoruz.
                    // yeniSiparis.Urun = urun; // Bu satırı sildik veya yoruma aldık
                    Miktar = 1,
                    BirimFiyat = urun.Fiyat // urun.Fiyat.Value olarak da kullanabilirsin
                };
                siparisListesi.Add(yeniSiparis);
            }

            gridSiparisler.RefreshDataSource();
        }
        private void gridSiparisler_Click(object sender, EventArgs e)
        {

        }

        private void btnSiparisKaydet_Click(object sender, EventArgs e)
        {
            // 1. ADIM: Masa ve Mevcut Adisyon Kontrolü
            var masa = db.Masalar.Find(_masaId);
            int adisyonId = 0;

            // Masada aktif bir adisyon var mı kontrol et
            var aktifAdisyon = db.Adisyonlar
                                   .FirstOrDefault(a => a.MasaId == _masaId && a.Durum == true);

            if (aktifAdisyon == null)
            {
                // 1.1 Masa Boşsa: Yeni Adisyon Oluştur (Önceki kodumuzdaki gibi)
                Adisyonlar yeniAdisyon = new Adisyonlar
                {
                    MasaId = _masaId,
                    Tarih = DateTime.Now,
                    Durum = true // Adisyonu aktif (açık) olarak işaretle
                };
                db.Adisyonlar.Add(yeniAdisyon);
                db.SaveChanges();

                // Masa durumunu DOLU yap
                masa.Durumu = true;
                db.SaveChanges();

                adisyonId = yeniAdisyon.Id;
            }
            else
            {
                // 1.2 Masa Doluysa: Mevcut Adisyon ID'sini kullan
                adisyonId = aktifAdisyon.Id;
                // Masa zaten dolu olduğu için Durumunu değiştirmeye gerek yok.
            }

            // 2. ADIM: Adisyon Hareketlerini Kaydetme (YENİ SİPARİŞLERİ ekle)

            // Grid'e bağlı olan listemizdeki siparişleri (siparisler listesini) döngüye al.
            // Ancak sadece yeni eklenenleri değil, bütün listeyi kaydetmemeliyiz.
            // Bizim 'siparisler' listemiz, form açıldığında yüklenen ve yeni eklenen her şeyi içeriyor.
            // O yüzden mevcut listedeki her AdisyonHareketler kaydının veritabanında olup olmadığını kontrol etmeliyiz.

            foreach (var hareket in siparisler)
            {
                // Eğer hareketin bir ID'si yoksa veya ID'si 0'sa, bu YENİ EKLENMİŞ bir harekettir.
                // AdisyonHareketler tablosunun anahtarını (Id) kontrol etmelisin. 
                // Eğer Id 0'dan büyükse, zaten veritabanında var demektir (Load metoduyla yüklenenler).

                if (hareket.Id == 0) // Varsayalım ki AdisyonHareketler ID'si 0 ise yenidir.
                {
                    hareket.AdisyonId = adisyonId;
                    db.AdisyonHareketler.Add(hareket);
                }
                // Eğer Id > 0 ise, sadece miktarında değişiklik yapılmıştır. 
                // Bu durumda, hareket nesnesi zaten Entity Framework tarafından izlendiği için
                // db.SaveChanges() çağrıldığında değişiklikler otomatik kaydedilecektir.
            }

            // Tüm değişiklikleri ve yeni kayıtları kaydet
            db.SaveChanges();

            MessageBox.Show(masa.MasaAdi + " için sipariş başarıyla güncellendi.", "Sipariş Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}