using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CamlicaProje1.Models;
using CamlicaProje1.ValidationRules;
using FluentValidation.Results;

namespace CamlicaProje1.Controllers
{
    public class RegisterController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        [HttpGet]
        public ActionResult register()
        {
            kullaniciBilgileri k = new kullaniciBilgileri();

            return View(k);
        }

        [HttpPost]
        public ActionResult register(kullaniciBilgileri k)
        {

            KullaniciValidator v = new KullaniciValidator();
            ValidationResult results = v.Validate(k);

            kullaniciBilgileri kullanici = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciAdi == k.kullaniciAdi);
            if(kullanici != null)
            {
                ViewBag.Mesaj = "Bu kullanıcı adı kullanılmakta !";

                return View();
            }

            if (results.IsValid)
            {
                model.kullaniciBilgileri.Add(k);
                model.SaveChanges();
                FormsAuthentication.SetAuthCookie(k.kullaniciAdi, false); // false : oturum, tarayıcı kapatıldığında kapanır

                return RedirectToAction("Index", "Home");
            }

            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}