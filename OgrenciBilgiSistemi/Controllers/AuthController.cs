using OgrenciBilgiSistemi.Db;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciBilgiSistemi.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string gridRadios, string ogrNo, string pass)
        {
            SessionModel session = new SessionModel();
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            if (gridRadios == "1")
            {
                session.Akademisyen = db.Akademisyen.Where(p => p.Email == ogrNo && p.Sifre == pass).FirstOrDefault();
                if (session.Akademisyen == null)
                {
                    ViewBag.Hata = "Böyle bir akademisyenimiz bulunmamakta.";
                    return View("Index");
                }
                session.GosterimUnvani = session.Akademisyen.Unvan;
                session.GosterimAdi = session.Akademisyen.AdiSoyadi;
                session.Resim = session.Akademisyen.Resim;
            }
            if(gridRadios == "0")
            {
                session.Ogrenci = db.Ogrenci.Where(p => p.OgrNo == ogrNo && p.Sifre == pass).FirstOrDefault();
                if (session.Ogrenci == null)
                {
                    ViewBag.Hata = "Böyle bir öğrencimiz bulunmamakta.";
                    return View("Index");
                }
                session.GosterimUnvani = "Öğrenci";
                session.GosterimAdi = session.Ogrenci.AdiSoyadi;
                session.Resim = session.Ogrenci.Resim;
            }
            Session["session"] = session;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChangePassword(string password, string newpassword)
        {
            SessionModel model = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            if (model.Akademisyen != null)
            {
                Akademisyen akademisyen = db.Akademisyen.Where(p => p.Id == model.Akademisyen.Id).FirstOrDefault();
                if (akademisyen.Sifre == password)
                {
                    akademisyen.Sifre = newpassword;
                    model.Akademisyen = akademisyen;
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Profilim", "Home");
                }
            }
            else if (model.Ogrenci != null)
            {
                Ogrenci ogrenci = db.Ogrenci.Where(p => p.Id == model.Akademisyen.Id).FirstOrDefault();
                if (ogrenci.Sifre == password)
                {
                    ogrenci.Sifre = newpassword;
                    model.Ogrenci = ogrenci;
                    db.SaveChanges();
                }
                else
                {
                    return RedirectToAction("Profilim", "Home");
                }
            }
            Session["session"] = model;
            return RedirectToAction("Profilim", "Home");
        }
        public ActionResult Logout()
        {
            Session["session"] = null;
            return View("Index");
        }
    }
}