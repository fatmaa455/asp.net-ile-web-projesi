using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamlicaProje1.Models;

namespace CamlicaProje1.ValidationRules
{
    public class KullaniciValidator:AbstractValidator<kullaniciBilgileri>
    {
        public KullaniciValidator()
        {
            RuleFor(x => x.ad).NotEmpty().WithMessage("İsim kısmı boş bırakılamaz !");
            RuleFor(x => x.soyad).NotEmpty().WithMessage("Soyisim kısmı boş bırakılamaz !");
            RuleFor(x => x.kullaniciAdi).NotEmpty().WithMessage("Kullanıcı adı kısmı boş bırakılamaz !");
            RuleFor(x => x.email).NotEmpty().WithMessage("Mail kısmı boş bırakılamaz !");
            RuleFor(x => x.sifre).NotEmpty().WithMessage("Şifre kısmı boş bırakılamaz !");

            RuleFor(x => x.kullaniciAdi).MinimumLength(5).WithMessage("Lütfen en az 3 karakter girişi yapınız !");
            RuleFor(x => x.kullaniciAdi).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla karakter girişi yapmayınız !");

            RuleFor(x => x.sifre).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız !");
            RuleFor(x => x.sifre).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla karakter girişi yapmayınız !");

            RuleFor(x => x.email).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz !");
        }
    }
}