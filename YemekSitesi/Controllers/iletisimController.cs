using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Mesajgonder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mesajgonder(Tbl_Mesaj p)
        {
            db.Tbl_Mesaj.Add(p);
            db.SaveChanges();
            return RedirectToAction("Mesajgonder");
        }
    }
}