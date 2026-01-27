using CafeOtomasyonu.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Models
{
    [Table("MasaHareketleri")]
    public class MasaHareketleri:IEntity
    {
        public int Id { get; set; }

        public string SatisKodu { get; set; }

        public int MasaId { get; set; }
        public int MenuId { get; set; }

        public int UrunId { get; set; }
       
        public int Miktari { get; set; }

        public decimal BirimFiyati { get; set; }
        public decimal indirimTutari { get; set; }

        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }
        public string Resim { get; set; }
        public Masalar Masalar { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
