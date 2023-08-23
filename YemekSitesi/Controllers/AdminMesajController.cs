using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;


namespace YemekSitesi.Controllers
{
    public class AdminMesajController : Controller
    {
        // GET: AdminMesaj
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [Authorize]
        public ActionResult Index()
        {
            var mesaj = db.Tbl_Mesaj.OrderByDescending(x => x.Id).ToList();
            return View(mesaj);
        }
        public ActionResult Sil(int id)
        {
            var bul = db.Tbl_Mesaj.Find(id);
            db.Tbl_Mesaj.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(Tbl_Mesaj p)
        {
            var bul = db.Tbl_Mesaj.Find(p.Id);
            return View("Detay",bul);
        }
    }
}