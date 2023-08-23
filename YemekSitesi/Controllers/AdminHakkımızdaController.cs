using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminHakkımızdaController : Controller
    {
        // GET: AdminHakkımızda
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Guncelle()
        {
            var bul = db.Tbl_Hakkımızda.Find(1);
            return View(bul);
        }
        public ActionResult Guncelle(Tbl_Hakkımızda p)
        {
            var deger = db.Tbl_Hakkımızda.Find(1);
            deger.Baslık = p.Baslık;
            deger.Resim = p.Resim;
            deger.icerik1 = p.icerik1;
            deger.icerik2 = p.icerik2;
            deger.icerik3 = p.icerik3;
            deger.icerik4 = p.icerik4;
            db.SaveChanges();
            return RedirectToAction("Guncelle");
        }
    }
}