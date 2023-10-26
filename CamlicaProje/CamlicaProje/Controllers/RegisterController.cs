using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CamlicaProje.Models;

namespace CamlicaProje.Controllers
{
    public class RegisterController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        [HttpGet]
        public ActionResult Register()
        {
            kullaniciBilgileri kullanici = new kullaniciBilgileri();

            return View(kullanici);
        }

        [HttpPost]
        public ActionResult Register(kullaniciBilgileri kullanici)
        {
            kullaniciBilgileri k = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciAdi == kullanici.kullaniciAdi);

            if(k != null)
            {
                ViewBag.Mesaj = "Zaten böyle bir kullanıcı var !";
                return View();
            }

            if(k.ad == null || k.soyad == null || k.kullaniciAdi == null || k.email == null || k.sifre == null)
            {
                ViewBag.Mesaj = "Bütün alanları doldurunuz !";
                return View();
            }
            else
            {
                model.kullaniciBilgileri.Add(kullanici);
                model.SaveChanges();

                FormsAuthentication.SetAuthCookie(kullanici.kullaniciAdi, false);

                return RedirectToAction("Index", "Home");
            }
        }
    }
}