using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.Entities.Repository;
using CafeOtomasyonu.Entities.Validations;

namespace CafeOtomasyonu.Entities.DAL
{
    public class MasalarDal : EntityRepositoryBase<CafeContext, Masalar, MasalarValidator>
    {
        public object MasalariListele(CafeContext context)
        {
            var model = (from masa in context.Masalar
                         join k in context.Kullanicilar on masa.Kullaniciİd equals k.Id into kullanici
                         from kullanicimasa in kullanici.DefaultIfEmpty()
                         select new
                         {
                             masa.Aciklama,
                             masa.Durumu,
                             masa.EklenmeTarihi,
                             masa.Id,
                             masa.Islem,
                             masa.MasaAdi,
                             masa.RezerveMi,
                             masa.SonIslemTarihi,
                             Kullanici = kullanicimasa.KullaniciAdi
                         }).ToList();

            return model;
        }
    }
}