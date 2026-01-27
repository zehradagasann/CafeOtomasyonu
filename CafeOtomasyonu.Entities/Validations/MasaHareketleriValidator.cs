using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MasaHareketleriValidator : AbstractValidator<MasaHareketleri>
    {
        public MasaHareketleriValidator()
        {
            RuleFor(p => p.SatisKodu).NotEmpty().WithMessage("Satış Kodu alanı boş geçilemez.");
            RuleFor(p => p.SatisKodu).Length(12).WithMessage("Satış kodu 12 karakterden oluşmalıdır..");

            RuleFor(p => p.Miktari).NotEmpty().WithMessage("Miktarı alanı boş geçilemez.");
            RuleFor(p => p.Miktari).GreaterThan(0).WithMessage("Miktarı alanı boş geçilemez.");
            

            RuleFor(p => p.BirimFiyati).NotEmpty().WithMessage("BirimFiyatı alanı boş geçilemez.");
            RuleFor(p => p.BirimFiyati).LessThanOrEqualTo(150).WithMessage("BirimFiyatı en fazla 150 olur.");
        }
    }
}
