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
    public class MasalarMap : EntityTypeConfiguration<Masalar>
    {
        public MasalarMap()
        {
            this.ToTable("Masalar");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MasaAdi).HasColumnType("varchar").HasMaxLength(15);
            this.Property(p => p.SatısKodu).HasColumnType("varchar").HasMaxLength(20);
            this.Property(p => p.Aciklama).HasColumnType("varchar").HasMaxLength(300);
            this.Property(p => p.EklenmeTarihi).HasColumnType("Date");
            this.HasOptional(m => m.Kullanicilar).WithMany(m => m.Masalar).HasForeignKey(m => m.Kullaniciİd);
        }
    }
}
