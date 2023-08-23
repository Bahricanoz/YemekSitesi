using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class KategoriController : Controller
    {
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            var kat = db.Tbl_Yemek.Where(x => x.Kategoriid == id).OrderByDescending(x => x.Id).ToList();
            return View("Index",kat);
        }
        public PartialViewResult SonYemekler()
        {
            var sonyemek = db.Tbl_Yemek.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(sonyemek);
        }
        public PartialViewResult Sonyorumlar()
        {
            var sonyorumlar = db.Tbl_Yorum.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(sonyorumlar);
        }
        public PartialViewResult Kategoriler()
        {
            var kat = db.Tbl_Kategori.ToList();
            return PartialView(kat);
        }
    }
}