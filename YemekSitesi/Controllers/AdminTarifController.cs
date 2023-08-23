using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminTarifController : Controller
    {
        // GET: AdminTarif
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var tarif = db.Tbl_Tarifler.ToList();
            return View(tarif);
        }
        public ActionResult Sil(int id)
        {
            var bul = db.Tbl_Tarifler.Find(id);
            db.Tbl_Tarifler.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int id)
        {
            var bul = db.Tbl_Tarifler.Find(id);
            return View("Detay", bul);
        }
    }
}