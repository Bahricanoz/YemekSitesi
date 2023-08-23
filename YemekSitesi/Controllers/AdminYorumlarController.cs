using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminYorumlarController : Controller
    {
        // GET: AdminYorumlar
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var yorumlar = db.Tbl_Yorum.ToList();
            return View(yorumlar);
        }
        public ActionResult Detay(Tbl_Yorum p)
        {
            var deger = db.Tbl_Yorum.Find(p.Id);
            return View(deger);
        }
        public ActionResult Aktifyap(int id)
        {
            var bul = db.Tbl_Yorum.Find(id);
            bul.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Pasifyap(int id)
        {
            var bul = db.Tbl_Yorum.Find(id);
            bul.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var bul = db.Tbl_Yorum.Find(id);
            return View("Guncelle", bul);
        }
        [HttpPost]
        public ActionResult Guncelle(Tbl_Yorum p)
        {
            var deger = db.Tbl_Yorum.Find(p.Id);
            deger.Durum = true;
            deger.Mail = p.Mail;
            deger.İcerik = p.İcerik;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}