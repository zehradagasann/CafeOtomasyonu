using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Mapping;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.Ödemeler;
using CafeOtomasyonu.WinForms.Urunler;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaSiparisleri : DevExpress.XtraEditors.XtraForm
    {
        
        public string _satiskodu = null;
        private CafeContext context = new CafeContext();
        private MusterilerDal musterilerDal = new MusterilerDal();
        private int? _masaId = null;
        private MasaHareketleriDal masaHareketleriDal = new MasaHareketleriDal();
        private ÖdemeHareketleriDal ÖdemeHareketleriDal = new ÖdemeHareketleriDal();

        
        private static DateTime sonApiCagriZamani = DateTime.MinValue;
        private static int dakikadakiCagriSayisi = 0;
        private static DateTime dakikaBaslangici = DateTime.MinValue;
        private const int DAKIKA_BASINA_MAX_CAGRI = 15;
        private const int CAGRILER_ARASI_MS = 5000;
        private bool yapayZekaCalisiyorMu = false;

        public frmMasaSiparisleri(int? masaId = null, string masaAdi = null, string satisKodu = null)
        {
            InitializeComponent();
            _masaId = masaId;
            _satiskodu = satisKodu;

            // Veri Yükleme İşlemleri
            lookUpMüsteri.Properties.DataSource = musterilerDal.GetAll(context);
            context.MasaHareketleri.Where(m => m.SatisKodu == _satiskodu).Load();
            context.OdemeHareketleri.Where(o => o.SatisKodu == _satiskodu).Load();
            context.Urun.Load();

            gridControlSiparisler.DataSource = context.MasaHareketleri.Local.ToBindingList();
            gridControlÖdemeler.DataSource = context.OdemeHareketleri.Local.ToBindingList();

            if (_masaId != null)
            {
                lblBaslik.Text = masaAdi + " Siparişleri";
            }

            
            lblYapayZekaÖneri.Text = "Sipariş eklendiğinde AI öneri göreceksiniz";
            lblYapayZekaÖneri.ForeColor = Color.Gray;
        }

        
        private bool RateLimitKontrol()
        {
            var simdi = DateTime.Now;

            if ((simdi - dakikaBaslangici).TotalMinutes >= 1)
            {
                dakikaBaslangici = simdi;
                dakikadakiCagriSayisi = 0;
            }

            if (dakikadakiCagriSayisi >= DAKIKA_BASINA_MAX_CAGRI)
            {
                return false;
            }

            var gecenSure = (simdi - sonApiCagriZamani).TotalMilliseconds;
            if (gecenSure < CAGRILER_ARASI_MS)
            {
                return false;
            }

            return true;
        }

        // --- YAPAY ZEKA METODU ---
        public async Task<string> YapayZekaOnerisiAl(string urunAdi)
        {
            if (yapayZekaCalisiyorMu)
            {
                return "Önceki öneri hazırlanıyor, lütfen bekleyin...";
            }

            if (!RateLimitKontrol())
            {
                return "⏸️ Kota koruması: Lütfen birkaç saniye bekleyip tekrar deneyin.";
            }

            yapayZekaCalisiyorMu = true;

            try
            {
                var urunListesi = context.Urun
                .Select(u => u.UrunAdi)
                .ToList();

                string cafeMenusu = string.Join(", ", urunListesi);

                string apiKey = "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"; 
                string url = "https://api.groq.com/openai/v1/chat/completions";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                    var requestData = new
                    {
                        model = "llama-3.3-70b-versatile", 
                        messages = new[] {
                    new {
                        role = "system",
                        content = $@"Sen bir cafe satış asistanısın. 
                                    SADECE şu listedeki ürünlerden birini önerebilirsin: {cafeMenusu}. 
                                    Listenin dışından asla ürün önerme. 
                                    Müşterinin aldığı ürüne en çok yakışacak yan ürünü seç.
                                    Cevabın sadece ürün adı olsun, başka açıklama yapma."
                    },
                    new {
                        role = "user",
                        content = $"Müşteri '{urunAdi}' siparişi verdi. Menüden yanına ne önerirsin?"
                    }
                    },
                        temperature = 0.4, 
                        max_tokens = 50
                    };

                    var json = JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // 4. İstek Atma
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic result = JsonConvert.DeserializeObject(responseString);
                        string mesaj = result.choices[0].message.content;
                        return $"💡 Öneri: {mesaj.Trim()}";
                    }
                    else
                    {
                        return $"Groq Hatası: {response.StatusCode} \nDetay: {responseString}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Bağlantı sorunu: " + ex.Message;
            }
            finally
            {
                yapayZekaCalisiyorMu = false;
            }
        }

        void Hesapla()
        {
            try
            {
                decimal indirimToplami = 0;
                decimal indirimliToplam = 0;

                if (colindirimTutari != null && colindirimTutari.SummaryItem.SummaryValue != null)
                    indirimToplami = Convert.ToDecimal(colindirimTutari.SummaryItem.SummaryValue);

                if (colTutar != null && colTutar.SummaryItem.SummaryValue != null)
                    indirimliToplam = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);

                var ödemeler = context.OdemeHareketleri
                .Where(x => x.SatisKodu == _satiskodu)
                .Select(x => x.Odenen) 
                .DefaultIfEmpty(0)     
                .Sum();

                calcÖdenen.Text = ödemeler.ToString("C2");
                calcKalan.Text = (indirimliToplam - ödemeler).ToString("C2");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hesaplama hatası: {ex.Message}");
            }
        }

        
        private void btnYenileme_Click(object sender, EventArgs e)
        {
            try
            {
                context.MasaHareketleri.Where(m => m.SatisKodu == _satiskodu).Load();
                context.OdemeHareketleri.Where(o => o.SatisKodu == _satiskodu).Load();

                gridControlSiparisler.DataSource = context.MasaHareketleri
                    .Include("Urun")
                    .Where(x => x.SatisKodu == _satiskodu)
                    .ToList();

                gridControlÖdemeler.DataSource = context.OdemeHareketleri
                    .Where(x => x.SatisKodu == _satiskodu)
                    .ToList();

                Hesapla();
                MessageBox.Show("Veriler güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yenileme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("Değişiklikler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void Ödemeler_Click(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            frmÖdeme frm = new frmÖdeme(btn.Text, _satiskodu);
            frm.ShowDialog();

            if (frm.kaydedildi)
            {
                try
                {
                    ÖdemeHareketleriDal.AddOrUpdate(context, frm.odemeHareketleri);
                    context.SaveChanges();
                    gridControlÖdemeler.DataSource = context.OdemeHareketleri
                        .Where(x => x.SatisKodu == _satiskodu)
                        .ToList();
                    Hesapla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ödeme kayıt hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void btnMusteriResetle_Click(object sender, EventArgs e)
        {
            lookUpMüsteri.EditValue = null;
        }

        
        private void gridViewSiparisler_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Hesapla();
        }

        
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            context?.Dispose();
        }

        private async void btnSiparisEkle_Click_1(object sender, EventArgs e)
        {
            frmUrunSec frm = new frmUrunSec();
            frm.ShowDialog();

            if (frm.secildi)
            {
                MasaHareketleri entity = new MasaHareketleri();
                entity.SatisKodu = _satiskodu;

                
                string masaAdi = this.Text.Replace(" Siparişleri", "").Trim();

                var guncelMasa = context.Masalar.FirstOrDefault(m => m.MasaAdi == masaAdi);

                if (guncelMasa != null)
                {
                    entity.MasaId = guncelMasa.Id; 
                }
                else if (_masaId != null && context.Masalar.Any(m => m.Id == _masaId))
                {
                    entity.MasaId = _masaId.Value; 
                }
                else
                {
                   
                    var yedekMasa = context.Masalar.FirstOrDefault();
                    if (yedekMasa != null) entity.MasaId = yedekMasa.Id;
                    else { MessageBox.Show("Hata: Masalar tablosu boş!"); return; }
                }
                

                entity.UrunId = frm.urunModel.Id;
                entity.Miktari = 1;
                entity.BirimFiyati = frm.urunModel.BirimFiyati1;
                entity.indirimTutari = 0;
                entity.Aciklama = "";
                entity.Tarih = DateTime.Now;

                context.MasaHareketleri.Add(entity);

                try
                {
                    context.SaveChanges();

                    gridControlSiparisler.DataSource = context.MasaHareketleri
                        .Include("Urun")
                        .Where(x => x.SatisKodu == _satiskodu)
                        .ToList();

                    Hesapla();

                    string urunAdi = frm.urunModel.UrunAdi;
                    lblYapayZekaÖneri.Text = $"🤖 {urunAdi} için öneri hazırlanıyor...";
                    lblYapayZekaÖneri.ForeColor = Color.Blue;
                    string akilliPrompt = $"Müşteri şu an '{urunAdi}' siparişi verdi. " +
                         "Sen profesyonel bir cafe asistanısın. Bu ürünün yanına yakışacak " +
                         "tamamlayıcı bir İÇECEK veya TATLI öner. " +
                         "Asla ana yemek (hamburger, köfte, tost gibi) önerme. " +
                         "Sadece ürün ismini kısa yaz.";

                    string onerilen = await YapayZekaOnerisiAl(urunAdi);
                    lblYapayZekaÖneri.Text = onerilen;

                    if (onerilen.Contains("⚠️") || onerilen.Contains("❌") || onerilen.Contains("⏸️"))
                    {
                        lblYapayZekaÖneri.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblYapayZekaÖneri.ForeColor = Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    var mesaj = ex.InnerException?.InnerException?.Message ?? ex.Message;
                    MessageBox.Show("Veritabanı Hatası: " + mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSonuclandir_Click_1(object sender, EventArgs e)
        {
            decimal GetValue(string text)
            {
                if (string.IsNullOrEmpty(text)) return 0;
                string cleanText = text.Replace("₺", "").Replace("TL", "").Replace(",", ".").Trim();
                decimal.TryParse(cleanText, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal result);
                return result;
            }

            decimal kalanTutar = GetValue(calcKalan.Text);

            if (kalanTutar > 0)
            {
                var onay = MessageBox.Show("Ödenmemiş bir tutar var. Yine de masayı kapatmak istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.No) return;
            }

            try
            {
                var masa = context.Masalar.FirstOrDefault(x => x.Id == _masaId);
                if (masa != null) masa.Durumu = false;

                var satis = context.Satislar.FirstOrDefault(x => x.SatisKodu == _satiskodu);
                if (satis != null)
                {
                    satis.Odenen = GetValue(calcÖdenen.Text);
                    satis.Kalan = kalanTutar;
                    satis.SonIslemTarihi = DateTime.Now;
                }

                context.SaveChanges();
                if (Application.OpenForms["MasaDurumu"] != null)
                {
                    (Application.OpenForms["MasaDurumu"] as CafeOtomasyonu.WinForms.Masalar.MasaDurumu).MasalariGetir();
                }
                MessageBox.Show("Masa başarıyla sonlandırıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sonlandırma hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}