AI Destekli Akıllı Kafe Otomasyonu (Smart Cafe Automation)
Bu proje, geleneksel kafe yönetim süreçlerini Yapay Zeka (Generative AI) ile birleştiren modern bir otomasyon çözümüdür. Windows Forms tabanlı geliştirilen uygulama, Katmanlı Mimari yapısını kullanır ve garsonların sipariş alırken müşteriye en uygun yan ürünü önermesini sağlamak için Groq API entegrasyonuna sahiptir.

🚀 Projenin Amacı
İşletme içerisindeki masa takibi, sipariş yönetimi ve adisyon süreçlerini dijitalleştirmek; aynı zamanda yapay zeka desteği ile "Upselling" (Ek satış) yaparak işletme cirosunu artırmaktır.

✨ Özellikler
🧠 Groq AI Entegrasyonu: Müşterinin verdiği siparişi anlık olarak analiz eder ve yanına en iyi gidecek ürünü (içecekse tatlı, yemekse içecek vb.) gerekçesiyle birlikte önerir.

🗄️ Entity Framework & Database First: Güçlü ORM yapısı ile veritabanı yönetimi (.edmx altyapısı).

🪑 Masa Yönetimi: Masaların anlık durumu (Boş/Dolu), masa değiştirme ve birleştirme işlemleri.

📝 Sipariş Sistemi: FrmSiparis formu üzerinden hızlı ürün ekleme, iptal etme ve miktar güncelleme.

📊 Raporlama: Günlük ciro ve ürün bazlı satış takibi.

🛠️ Kullanılan Teknolojiler ve Mimari
Proje dosya yapısına göre aşağıdaki teknolojiler kullanılmıştır:

Dil: C#

Arayüz (UI): Windows Forms (.NET Framework)

Veritabanı: MS SQL Server

ORM: Entity Framework 6 (.edmx - Database First Approach)

Yapay Zeka: Groq Cloud API (LLM Entegrasyonu)

Paket Yönetimi: NuGet (packages.config)

Dosya Yapısı ve İşlevleri
Görüntülenen proje yapısına göre temel dosyaların görevleri:

CafeContext.edmx: Veritabanı tablolarının görsel modellemesi ve ilişki şeması.

CafeOtomasyonu.Entities/: Veritabanı tablolarına karşılık gelen saf sınıflar (POCO).

FrmSiparis.cs: Siparişlerin alındığı ve AI önerilerinin gösterildiği ana form.

Masalar.cs, Adisyonlar.cs, Urunler.cs: Veritabanı varlık sınıfları.

⚙️ Kurulum (Installation)
Projeyi kendi bilgisayarınızda çalıştırmak için adımları izleyin:

Projeyi Klonlayın:

Bash

git clone https://github.com/zehradagasann/CafeOtomasyonu/tree/master
Veritabanı Bağlantısı: App.config dosyasını açın ve connectionStrings bölümünü kendi yerel SQL Server bilgilerinize göre güncelleyin.

Veritabanını Oluşturun: Proje "Database First" yaklaşımı kullandığı için, SQL scriptini çalıştırarak veya .edmx modelinden veritabanını generate ederek tabloları oluşturun.

Groq API Kurulumu:

Groq Console'dan bir API Key alın.

Proje içerisindeki API ayar dosyasına (veya ilgili koda) bu anahtarı ekleyin.

Çalıştırın: Visual Studio üzerinden Start butonuna basarak uygulamayı başlatın.

🧠 Yapay Zeka (AI) Nasıl Çalışır?
Sistem şu akışı izler:

Kullanıcı FrmSiparis ekranında ürünleri adisyona ekler.

"Öneri Al" tetiklendiğinde, sepet içeriği metin formatına çevrilir.

Bu metin, özel bir prompt ile Groq API'ye gönderilir.

Prompt Örneği: "Müşteri [Çay, Tost] sipariş etti. Bir garson gibi düşün ve yanına ne önerirsin? Tek bir ürün öner."

Groq'tan gelen yanıt (Örn: "Portakal Suyu") ekranda garsona gösterilir.

📷 Ekran Görüntüleri
(Uygulamanın çalışır haldeki ekran görüntülerini buraya ekleyebilirsiniz)

🤝 Katkıda Bulunma
Pull request'ler kabul edilir. Büyük değişiklikler için lütfen önce tartışma başlatın.

📝 Lisans
MIT
