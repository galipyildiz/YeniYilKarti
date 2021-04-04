using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YeniYilKarti.Models;

namespace YeniYilKarti.Controllers
{
    [Authorize]
    public class KartController : BaseController
    {
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            List<Kart> kartlar = db.Kartlar.Where(x => x.UserId == id).ToList();
            return View(kartlar);
        }

        public ActionResult Yeni()
        {
            //https://stackoverflow.com/questions/15989764/display-all-images-in-a-folder-in-mvc-with-a-foreach
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Img")).Select(fn => "~/Img/" + Path.GetFileName(fn));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yeni(KartVM vm)
        {
            string id = User.Identity.GetUserId();
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Img")).Select(fn => "~/Img/" + Path.GetFileName(fn));
            if (ModelState.IsValid)
            {
                string Mesaj1 = vm.Mesaj.Length < 55 ? vm.Mesaj : vm.Mesaj.Substring(0, 55);
                string Mesaj2 = vm.Mesaj.Length > 55 ? vm.Mesaj.Substring(55, 110) : null;
                string Mesaj3 = vm.Mesaj.Length > 110 ? vm.Mesaj.Substring(110) : null;
                Kart kart = new Kart()
                {
                    AliciAd = vm.AliciAd,
                    GonderenAd = vm.GonderenAd,
                    ResimYolu = vm.Resimyolu,
                    Mesaj1 = Mesaj1,
                    Mesaj2 = Mesaj2,
                    Mesaj3 = Mesaj3,
                    UserId = id,
                    Baslik = "Sevgili -" + vm.AliciAd
                };
                db.Kartlar.Add(kart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public ActionResult Sil(int id)
        {
            Kart kart = db.Kartlar.Find(id);
            if (kart == null)
            {
                return HttpNotFound();
            }
            db.Kartlar.Remove(kart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Indir(int id)
        {
            Kart kart = db.Kartlar.Find(id);
            if (kart == null)
            {
                return HttpNotFound();
            }
            return View(kart);
        }
    }
}