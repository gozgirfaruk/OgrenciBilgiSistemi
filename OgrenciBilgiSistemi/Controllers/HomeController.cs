using OgrenciBilgiSistemi.Attributes;
using OgrenciBilgiSistemi.Db;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciBilgiSistemi.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DersProgramiPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.OgrenciDers.Where(p => p.OgrenciId == session.Ogrenci.Id).ToList();
            return View(list);
        }
        public ActionResult AkademisyenDersProgramiPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.Ders.Where(p => p.Akademisyen.Id == session.Akademisyen.Id).ToList();
            return View(list);
        }
        public ActionResult NotListesiPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.OgrenciDers.Where(p => p.OgrenciId == session.Ogrenci.Id).ToList();
            return View(list);
        }
        public ActionResult DevamsizlikDurumuPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.OgrenciDers.Where(p => p.OgrenciId == session.Ogrenci.Id).ToList();
            return View(list);
        }
        public ActionResult Profilim()
        {
            return View();
        }

        public ActionResult DersEklePartial(Nullable<int> id)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            ViewBag.AkademisyenList = db.Akademisyen.ToList();
            Ders ders = new Ders();
            if (id != null) ders = db.Ders.Where(p => p.Id == id).FirstOrDefault();
            return View(ders);
        }
        public ActionResult DersEkle(Nullable<int> id, string adi, int gun, string saat, int kredi, string toplamDersSaati, int vizeOran, int finalOran, int akademisyenId)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            Ders ders = new Ders();
            if (id != null && id > 0)
            {
                ders = db.Ders.Where(p => p.Id == id).FirstOrDefault();

                ders.Adi = adi;
                ders.Gun = gun;
                ders.Saat = saat;
                ders.Kredi = kredi;
                ders.ToplamDersSaati = toplamDersSaati;
                ders.VizeOran = vizeOran;
                ders.FinalOran = finalOran;
                ders.AkademisyenId = akademisyenId;
                db.SaveChanges();

            }
            else
            {
                ders.Adi = adi;
                ders.Gun = gun;
                ders.Saat = saat;
                ders.Kredi = kredi;
                ders.ToplamDersSaati = toplamDersSaati;
                ders.VizeOran = vizeOran;
                ders.FinalOran = finalOran;
                ders.AkademisyenId = akademisyenId;
                db.Ders.Add(ders);
                db.SaveChanges();
            }
            ViewBag.Mesaj = "Kayit Basarili";
            ViewBag.AkademisyenList = db.Akademisyen.ToList();
            return View("DersEklePartial", ders);
        }
        public ActionResult NotGirisPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var dersList = db.Ders.Where(p => p.AkademisyenId == session.Akademisyen.Id).ToList();
            return View(dersList);
        }
        public ActionResult NotGiris(int dersId)
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var ogrenciList = db.OgrenciDers.Where(p => p.DersId == dersId).ToList();
            ViewBag.Ders = db.Ders.Where(p => p.Id == dersId).FirstOrDefault().Adi;
            return View(ogrenciList);
        }
        public ActionResult NotDuzenle(int ogrenciDersId)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            OgrenciDers ogrenci = db.OgrenciDers.Where(p => p.Id == ogrenciDersId).FirstOrDefault();
            return View(ogrenci);
        }
        public ActionResult NotKaydet(int ogrenciDersId, Nullable<int> vizeNotu, Nullable<int> finalNotu, Nullable<int> butNotu)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            OgrenciDers ogrenci = db.OgrenciDers.Where(p => p.Id == ogrenciDersId).FirstOrDefault();
            ogrenci.VizeNotu = vizeNotu;
            ogrenci.FinalNotu = finalNotu;
            ogrenci.ButNotu = butNotu;
            db.SaveChanges();
            ViewBag.Mesaj = "Kayıt başarıyla güncellendi!";
            return View("NotDuzenle", ogrenci);
        }
        public ActionResult DevamsizlikGirisPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var dersList = db.Ders.Where(p => p.AkademisyenId == session.Akademisyen.Id).ToList();
            return View(dersList);
        }
        public ActionResult DevamsizlikGiris(int dersId)
        {

            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var ogrenciList = db.OgrenciDers.Where(p => p.DersId == dersId).ToList();
            ViewBag.Ders = db.Ders.Where(p => p.Id == dersId).FirstOrDefault().Adi;
            return View(ogrenciList);
        }
        public ActionResult DevamsizlikDuzenle(int ogrenciDersId)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            OgrenciDers ogrenci = db.OgrenciDers.Where(p => p.Id == ogrenciDersId).FirstOrDefault();
            return View(ogrenci);
        }
        public ActionResult DevamsizlikKaydet(int ogrenciDersId, string devamsizlikSayisi)
        {
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            OgrenciDers ogrenci = db.OgrenciDers.Where(p => p.Id == ogrenciDersId).FirstOrDefault();
            ogrenci.DevamsizlikSayisi = devamsizlikSayisi;
            db.SaveChanges();
            ViewBag.Mesaj = "Kayıt başarıyla güncellendi!";
            return View("DevamsizlikDuzenle", ogrenci);
        }
        public ActionResult DerslerimPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.OgrenciDers.Where(p => p.OgrenciId == session.Ogrenci.Id).ToList();
            return View(list);
        }
        public ActionResult DerslerimAkademisyenPartial()
        {
            SessionModel session = (SessionModel)Session["session"];
            OgrenciBilgiSistemiEntities db = new OgrenciBilgiSistemiEntities();
            var list = db.Ders.Where(p => p.AkademisyenId == session.Akademisyen.Id).ToList();
            return View(list);
        }
    }
}