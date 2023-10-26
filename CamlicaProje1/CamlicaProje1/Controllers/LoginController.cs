using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CamlicaProje1.Models;

namespace CamlicaProje1.Controllers
{
    public class LoginController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(kullaniciBilgileri k)
        {

            kullaniciBilgileri kullanici = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciAdi == k.kullaniciAdi && x.sifre == k.sifre);

            if(k.kullaniciAdi == null)
            {
                ViewBag.Mesaj = "Lütfen kullanıcı adı kısmını doldurunuz !";
                return View();
            }

            if (k.sifre == null)
            {
                ViewBag.Mesaj= "Lütfen şifre kısmını doldurunuz !";
                return View();
            }

            if (kullanici == null)
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı !";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(kullanici.kullaniciAdi, false);

                return RedirectToAction("Index", "Home");
            }
        }
    }
}