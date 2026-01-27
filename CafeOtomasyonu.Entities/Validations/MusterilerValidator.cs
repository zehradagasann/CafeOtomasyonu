using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MusterilerValidator:AbstractValidator<Musteriler>
    {
       public MusterilerValidator()
        {
            RuleFor(p => p.AdiSoyadi).NotEmpty().WithMessage("Adı Soyadı alanı boş geçilemez.");
            RuleFor(p => p.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
        }
    }
}
