using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniYilKarti.Models;

namespace YeniYilKarti.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<Kart> kartlar = db.Kartlar.ToList();
            return View(kartlar);
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}