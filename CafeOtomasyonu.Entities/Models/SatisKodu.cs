using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Models
{
    [Table("Satis Kodu")]
    public class SatisKodu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string SatisTanimi { get; set; }

        public int Sayi { get; set; }
    }
}
