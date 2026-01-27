☕ AI Destekli Akıllı Kafe Otomasyonu

Bu proje, geleneksel kafe işletmeciliğini Yapay Zeka (Generative AI) gücüyle modernize eden kapsamlı bir otomasyon sistemidir. C# dili kullanılarak Visual Studio ortamında geliştirilmiş olup, veri tabanı altyapısında MS SQL Server kullanılmıştır.

Sistemin en çarpıcı özelliği, sipariş anında garsona müşterinin tercihleri ve mevcut sipariş uyumuna göre akıllı ürün önerileri (Upselling) sunmasıdır.

Shutterstock
Keşfet

🚀 Projenin Amacı
İşletme içerisindeki masa takibi, sipariş yönetimi, adisyon ve ödeme süreçlerini dijitalleştirirken; entegre yapay zeka asistanı sayesinde satışları ve müşteri memnuniyetini artırmayı hedefler.

✨ Temel Özellikler
🤖 Groq AI Entegrasyonu: Müşterinin verdiği siparişi analiz eder (Örn: "Türk Kahvesi") ve saniyeler içinde yanına en iyi gidecek ürünü (Örn: "Çifte Kavrulmuş Lokum") mantıklı bir gerekçeyle önerir.

🗄️ Güçlü Veritabanı Mimarisi: MS SQL Server ve Entity Framework (Database First) kullanılarak güvenli ve ilişkisel veri yönetimi sağlanır.

🏗️ Katmanlı Mimari: Proje, sürdürülebilirliği sağlamak adına Entity, Data Access ve Presentation katmanlarına ayrılmıştır.

🪑 Masa & Adisyon Yönetimi: Masaların doluluk durumu, sipariş ekleme/iptal etme, masa taşıma ve birleştirme işlemleri.

📊 Raporlama: Günlük satışlar ve ürün bazlı performans analizleri.

🛠️ Teknolojiler ve Araçlar
Bu proje aşağıdaki teknoloji yığını ile geliştirilmiştir:

Geliştirme Ortamı (IDE): Visual Studio 2019 / 2022

Programlama Dili: C# (.NET Framework)

Veritabanı: Microsoft SQL Server

ORM (Veri Erişim): Entity Framework 6 (.edmx / Database First)

Yapay Zeka API: Groq Cloud (LLM Modelleri)

Arayüz: Windows Forms (WinForms)

📂 Mimari Yapı
Proje dosya yapısı şu şekildedir:

CafeOtomasyonu.Entities: Veritabanı tablolarına karşılık gelen varlık sınıfları.

CafeContext.edmx: SQL Server veritabanı şeması ve ilişkilerinin modellendiği EF dosyası.

WinForms (UI): Kullanıcı etkileşiminin olduğu formlar (FrmSiparis, Masalar vb.).

⚙️ Kurulum (Installation)
Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

Repoyu Klonlayın:

Bash

git clone https://github.com/zehradagasann/CafeOtomasyonu/tree/master
Veritabanı Kurulumu (SQL Server):

Local SQL Server'ınızda yeni bir veritabanı oluşturun.

Proje içerisindeki SQL script dosyasını çalıştırarak tabloları oluşturun (veya Update-Database komutunu kullanın).

Bağlantı Ayarı:

App.config dosyasını açın.

connectionStrings bölümündeki Data Source alanını kendi SQL Server adınızla güncelleyin.

Groq API Key:

Groq Cloud üzerinden ücretsiz API anahtarınızı alın.

Projede ilgili alana (veya App.config dosyasına) API anahtarınızı yapıştırın.

Başlatma:

Visual Studio'da Start tuşuna basarak projeyi çalıştırın.

🧠 Yapay Zeka Nasıl Çalışır?
Garson sipariş ekranında ürünleri seçer.

"AI Öneri" butonuna basıldığında, sepet içeriği bir "Prompt" (İstem) haline getirilir.

Sistem, Groq API ile iletişime geçer.

Yapay zeka, ürünlerin içerik uyumuna göre bir tavsiye üretir.

Sonuç, garsonun ekranında bilgi notu olarak belirir.
📷 Ekran Görüntüleri
<img width="1482" height="1004" alt="image" src="https://github.com/user-attachments/assets/a816b939-db83-4ed8-bcf9-ccfc81dd9585" />
<img width="1490" height="1040" alt="image" src="https://github.com/user-attachments/assets/adbd7844-dbc3-42f7-9ff5-0de239e72d12" />
<img width="1461" height="1040" alt="image" src="https://github.com/user-attachments/assets/fc764834-e323-4c67-a2ba-87eb1577a846" />
<img width="1303" height="967" alt="image" src="https://github.com/user-attachments/assets/d703c6c6-b899-4ee9-beae-82b414c4cd60" />
<img width="1445" height="1016" alt="image" src="https://github.com/user-attachments/assets/de3b4ce0-8419-4fa6-9444-07bc60caff40" />
<img width="1024" height="668" alt="image" src="https://github.com/user-attachments/assets/39797a36-d7a7-4392-abf9-f68368417740" />
📝 Lisans
Bu proje MIT lisansı ile lisanslanmıştır.

📄 Proje Raporu ve Dokümantasyon

Projenin teknik detaylarını, mimari kararlarını ve geliştirme sürecini içeren detaylı proje raporuna aşağıdaki linkten ulaşabilirsiniz:

[📘 Proje Raporunu İncele (PDF)](https://github.com/zehradagasann/CafeOtomasyonu/blob/master/Ntp_Proje_%C3%96devi.pdf)






