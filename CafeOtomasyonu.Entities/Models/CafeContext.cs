using CafeOtomasyonu.Entities.Mapping;
using CafeOtomasyonu.Entities.Models;
using System.Data.Entity;

namespace CafeOtomasyonu.Entities.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext() : base("name=CafeContext")
        {
        }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Masalar> Masalar { get; set; }
        public DbSet<Satislar> Satislar { get; set; }
        public DbSet<MasaHareketleri> MasaHareketleri { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Roller> Roller { get; set; }
        public DbSet<OdemeHareketleri> OdemeHareketleri { get; set; }
       
        public DbSet<SatisKodu> SatisKodu { get; set; }
        // Yeni eklenen Müşteriler tablosu
        public DbSet<Musteriler> Musteriler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new UrunMap());
            modelBuilder.Configurations.Add(new MasalarMap());
            modelBuilder.Configurations.Add(new SatislarMap());
            modelBuilder.Configurations.Add(new MasaHareketleriMap());
            modelBuilder.Configurations.Add(new KullanicilarMap());
            modelBuilder.Configurations.Add(new RollerMap());
            modelBuilder.Configurations.Add(new OdemeHareketleriMap());
            //modelBuilder.Configurations.Add(new KullaniciHareketleriMap());
            // Eğer SatisKoduMap sınıfın varsa buraya eklemelisin, yoksa hata verebilir.
            // modelBuilder.Configurations.Add(new SatisKoduMap()); 
            modelBuilder.Configurations.Add(new MusterilerMap());
        }
    }
}