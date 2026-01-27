using CafeOtomasyonu.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Models
{
   
    public class Urun:IEntity
    {
        
        public int Id { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        
        public string UrunKodu { get; set; }

        
        public string UrunAdi { get; set; }

        public decimal BirimFiyati1 { get; set; }

        public decimal BirimFiyati2 { get; set; }

        
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }
        public string Resim { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<MasaHareketleri> MasaHareketleri{ get; set; }
    }
}