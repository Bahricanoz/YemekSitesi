using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;
namespace YemekSitesi.Controllers
{
    public class TarifController : Controller
    {
        // GET: Tarif
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Oner()
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
        public ActionResult Oner(Tbl_Tarifler p)
        {
            db.Tbl_Tarifler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Oner");
        }
    }
}