using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminKategoriController : Controller
    {
        // GET: AdminKategori
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var kat = db.Tbl_Kategori.ToList();
            return View(kat);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Kategori.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Kategori.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Kategori p)
        {
            db.Tbl_Kategori.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = db.Tbl_Kategori.Find(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Kategori p)
        {
            var deger = db.Tbl_Kategori.Find(p.Id);
            deger.KategoriAd = p.KategoriAd;
            deger.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}