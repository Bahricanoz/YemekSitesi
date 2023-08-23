using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;
namespace YemekSitesi.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        public ActionResult Index()
        {
            var yemekler = db.Tbl_Yemek.Where(x => x.Durum == true).ToList();
            return View(yemekler);
        }
        public PartialViewResult Sonyemekler()
        {
            var sonyemek = db.Tbl_Yemek.OrderByDescending(x => x.Id).Take(3).Where(x=>x.Durum== true).ToList();
            return PartialView(sonyemek);
        }
        public PartialViewResult Sonyorumlar()
        {
            var sonyorum = db.Tbl_Yorum.OrderByDescending(x => x.Id).Take(3).Where(x => x.Durum == true).ToList();
            return PartialView(sonyorum);
        }
        public PartialViewResult Kategoriler()
        {
            var kat = db.Tbl_Kategori.ToList();
            return PartialView(kat);
        }
        public ActionResult Blogdetay(int id)
        {
            var bul = db.Tbl_Yemek.Where(x => x.Id == id).ToList();
            return View("Blogdetay", bul);
        }
        public PartialViewResult Yemekyorum(int id)
        {
            var bul = db.Tbl_Yorum.Where(x => x.Yemekid == id).ToList();
            return PartialView(bul);
        }
        [HttpGet]
        public PartialViewResult Yorumyapma(int id)
        {
            ViewBag.dgr = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Yorumyapma(Tbl_Yorum p, int id)
        {
            var bul = db.Tbl_Yemek.Find(id);
            db.Tbl_Yorum.Add(p);
            p.Durum = false;

            db.SaveChanges();
            return PartialView();
        }
    }
}