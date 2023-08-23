using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var admin = db.Tbl_Admin.ToList();
            return View(admin);
        }
        public ActionResult Sil(int id)
        {
            var bul = db.Tbl_Admin.Find(id);
            db.Tbl_Admin.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Admin.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Admin.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(Tbl_Admin p)
        {
            var bul = db.Tbl_Admin.Find(p.Id);
            return View("Detay",bul);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tbl_Admin p)
        {
            db.Tbl_Admin.Add(p);
            p.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = db.Tbl_Admin.Find(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Admin p)
        {
            var deger = db.Tbl_Admin.Find(p.Id);
            deger.Ad = p.Ad;
            deger.sifre = p.sifre;
            deger.Soyad = p.Soyad;
            deger.Durum = true;
            deger.kullaniciadi = p.kullaniciadi;
            deger.Soyad = p.Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}