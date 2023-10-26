using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CamlicaProje.Models;

namespace CamlicaProje.Controllers
{

    public class LoginController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(kullaniciBilgileri kullanici)
        {
            kullaniciBilgileri k = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciAdi == kullanici.kullaniciAdi && x.sifre == kullanici.sifre);

            if (k == null)
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