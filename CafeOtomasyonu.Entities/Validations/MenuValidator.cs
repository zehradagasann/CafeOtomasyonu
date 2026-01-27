using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(p => p.MenuAdi).NotEmpty().WithMessage("Menü Adı alanı boş geçilemez.");
            RuleFor(p => p.MenuAdi).MinimumLength(3).WithMessage("Menü Adı alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(p => p.MenuAdi).MaximumLength(12).WithMessage("Menü Adı alanı en fazla 3 karakterden oluşmalıdır.");
        }
    }
}
