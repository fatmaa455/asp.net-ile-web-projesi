using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamlicaProje.Models;

namespace CamlicaProje.Controllers
{
    public class UsersController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        public ActionResult Index()
        {
            List<kullaniciBilgileri> kullanicilar = model.kullaniciBilgileri.ToList();

            return View(kullanicilar);
        }
    }
}