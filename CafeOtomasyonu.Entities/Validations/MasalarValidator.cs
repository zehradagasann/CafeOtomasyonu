using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MasalarValidator : AbstractValidator<Masalar>
    {
        public MasalarValidator()
        {
           
            RuleFor(p => p.MasaAdi).NotEmpty().WithMessage("Masa Adı alanı boş geçilemez.");
        }
    }
}