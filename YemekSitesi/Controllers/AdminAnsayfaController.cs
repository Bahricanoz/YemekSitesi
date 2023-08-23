using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class AdminAnsayfaController : Controller
    {
        // GET: AdminAnsayfa
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        public ActionResult Index()
        {
            var degeryemek = db.Tbl_Yemek.Count();
            ViewBag.yemek = degeryemek;
            var degerkat = db.Tbl_Kategori.Count();
            ViewBag.kat = degerkat;
            var degeryorum = db.Tbl_Kategori.Count();
            ViewBag.yorum = degeryorum;
            var degermesaj = db.Tbl_Kategori.Count();
            ViewBag.mesaj = degermesaj;
            var aktifyemek = db.Tbl_Yemek.Where(x => x.Durum == true).Count();
            ViewBag.aktifyemek = aktifyemek;
            var aktifkat = db.Tbl_Kategori.Where(x => x.Durum == true).Count();
            ViewBag.aktifkat = aktifkat;
            var aktifyorum = db.Tbl_Yorum.Where(x => x.Durum == true).Count();
            ViewBag.aktifyorum = aktifyorum;
            var admin = db.Tbl_Admin.Where(x => x.Durum == true).Count();
            ViewBag.admin = admin;
            return View();
        }
    }
}