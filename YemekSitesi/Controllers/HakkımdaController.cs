using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YemekSitesi.Models.Entity;

namespace YemekSitesi.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        Db_YemekSitesiEntities db = new Db_YemekSitesiEntities();
        public ActionResult Index()
        {
            var hakkımda = db.Tbl_Hakkımızda.ToList();
            return View(hakkımda);
        }
        
    }
}