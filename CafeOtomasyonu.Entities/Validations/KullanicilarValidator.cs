using CafeOtomasyonu.Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOtomasyonu.Entities.Validations
{
    public class KullanicilarValidator : AbstractValidator<Kullanicilar>
    {
        public KullanicilarValidator()
        {
            RuleFor(p => p.AdSoyad).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.");
            RuleFor(p => p.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez.");
            RuleFor(p => p.KullaniciAdi).MinimumLength(5).WithMessage("Kullanıcı Adı alanı 5 karakterden az olmamalıdır.");
            RuleFor(p => p.KullaniciAdi).MaximumLength(20).WithMessage("Kullanıcı Adı alanı 20 karakterden fazla olmamalıdır.");
            RuleFor(p => p.Parola).NotEmpty().WithMessage("Parola alanı boş geçilemez.");
            RuleFor(p => p.Parola).MinimumLength(6).WithMessage("Kullanıcı Adı alanı 6 karakterden az olmamalıdır.");
            RuleFor(p => p.Parola).MaximumLength(12).WithMessage("Kullanıcı Adı alanı 12 karakterden fazla olmamalıdır.");
            RuleFor(p => p.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Yanlış email adres formatı.");
        }
    }
}