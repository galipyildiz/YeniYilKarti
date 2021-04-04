using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YeniYilKarti.Controllers
{
    public class HataController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }
    }
}