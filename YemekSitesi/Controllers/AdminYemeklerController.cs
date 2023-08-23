using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminYemeklerController : Controller
    {
        // GET: AdminYemekler
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var yemekler = db.Tbl_Yemek.ToList();
            return View(yemekler);
        }
        public ActionResult Sil(int id)
        {
            var bul = db.Tbl_Yemek.Find(id);
            db.Tbl_Yemek.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Yemek.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Yemek.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int id)
        {
            var bul = db.Tbl_Yemek.Find(id);
            return View("Detay", bul);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kat = (from x in db.Tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.kat = kat;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Yemek p)
        {
            db.Tbl_Yemek.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            List<SelectListItem> kat = (from x in db.Tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.kat = kat;
            var bul = db.Tbl_Yemek.Find(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Yemek p)
        {
            var deger = db.Tbl_Yemek.Find(p.Id);
            deger.Durum = true;
            deger.icerik = p.icerik;
            deger.Yemekad = p.Yemekad;
            deger.Resim = p.Resim;
            deger.Tarih = p.Tarih;
            deger.Malzemeler = p.Malzemeler;
            deger.Kategoriid = p.Tbl_Kategori.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}