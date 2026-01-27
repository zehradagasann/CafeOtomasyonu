using CafeOtomasyonu.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Mapping
{
    public class SatislarMap : EntityTypeConfiguration<Satislar>
    {
        public SatislarMap()
        {
            this.ToTable("Satislar");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           
            this.Property(p => p.SatisKodu).HasColumnType("varchar").HasMaxLength(15);
            this.Property(p => p.Aciklama).HasColumnType("varchar").HasMaxLength(300);

           
            this.Property(p => p.Tutar).HasPrecision(28, 2);
            this.Property(p => p.Odenen).HasPrecision(28, 2);
            this.Property(p => p.Kalan).HasPrecision(28, 2);
            this.Property(p => p.SonIslemTarihi).HasColumnType("Date");
            this.HasOptional(s => s.Musteriler).WithMany(s => s.Satislar).HasForeignKey(s => s.musteriId);
        }
    }
}