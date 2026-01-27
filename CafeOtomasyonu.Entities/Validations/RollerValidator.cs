using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    // DİKKAT: Görselde <OdemeHareketleri> yazıyor ancak mantıken <Roller> olması gerekir.
    public class RollerValidator : AbstractValidator<OdemeHareketleri>
    {
        public RollerValidator()
        {

        }
    }
}
