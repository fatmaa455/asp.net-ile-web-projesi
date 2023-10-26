using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamlicaProje1.Models;
using CamlicaProje1.ValidationRules;
using FluentValidation.Results;

namespace CamlicaProje1.Controllers
{
    public class HomeController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();
        public ActionResult Index()
        {
            List<kullaniciBilgileri> bilgiler = model.kullaniciBilgileri.ToList();

            return View(bilgiler);
        }

        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            kullaniciBilgileri kullanici = new kullaniciBilgileri();

            return View(kullanici);
        }

        [HttpPost]
        public ActionResult KullaniciEkle(kullaniciBilgileri k)
        {
            kullaniciBilgileri kullanici = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciAdi == k.kullaniciAdi);

            if (kullanici != null)
            {
                ViewBag.Mesaj = "Hata";
                return RedirectToAction("KullaniciEkle", "Home");
            }

            else if (k.ad!=null && k.soyad!=null && k.sifre!=null && k.kullaniciAdi!=null && k.email!=null)
            {
                model.kullaniciBilgileri.Add(k);
                model.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.Mesaj = "Hata";
                return RedirectToAction("KullaniciEkle", "Home");
            }

        }

        public ActionResult AdresDetay(int id)
        {
            kullaniciBilgileri k = model.kullaniciBilgileri.FirstOrDefault(x => x.kullaniciId == id);

            List<adresBilgileri> adres = model.adresBilgileri.ToList();
            ViewBag.adres = adres;

            return View(k);
        }

        [HttpGet]
        public ActionResult AdresEkle(int id)
        {
            adresBilgileri adres = new adresBilgileri();

            adres.kullaniciId = id;
            model.SaveChanges();
            
            return View(adres);
        }

        [HttpPost]
        public ActionResult AdresEkle(adresBilgileri a,int id)
        {
            model.adresBilgileri.Add(a);
            a.kullaniciId = id;
            model.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}