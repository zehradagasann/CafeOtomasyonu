using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.Entities.Repository;
using CafeOtomasyonu.Entities.Validations;
using System;
using System.Linq;

namespace CafeOtomasyonu.Entities.DAL
{
    // Artık EntityRepositoryBase public olduğu için bu satır HATA VERMEYECEK.
    public class MusterilerDal : EntityRepositoryBase<CafeContext, Musteriler, MusterilerValidator>
    {
        // İçini boş bırak, buraya bir şey yazmana gerek yok.
        
        }
    }
