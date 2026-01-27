using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.Entities.Repository;
using CafeOtomasyonu.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.DAL
{
    public class UrunDal : EntityRepositoryBase<CafeContext, Urun, UrunValidator>
    {
        public object UrunListele(CafeContext context)
        {
            var liste = (from u in context.Urun
                         select new
                         {
                             u.Id,
                             u.MenuId,
                             Menu = u.Menu.MenuAdi, 
                             u.UrunKodu,
                             u.UrunAdi,
                             u.BirimFiyati1,
                             u.BirimFiyati2,
                             u.Aciklama,
                             u.Resim,
                             u.Tarih
                         }).ToList();

            return liste;
        }
    }
}
