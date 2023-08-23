using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class LoginnController : Controller
    {
        // GET: Loginn
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        [HttpGet]
        public ActionResult Girisyap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Girisyap(Tbl_Admin p)
        {
            var bilgiler = db.Tbl_Admin.FirstOrDefault(x => x.kullaniciadi == p.kullaniciadi && x.sifre == p.sifre && x.Durum == true);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciadi, false);
                Session["kullaniciadi"] = bilgiler.kullaniciadi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Cikisyap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Girisyap", "Loginn");
        }
    }
}