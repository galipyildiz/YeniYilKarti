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

    public class KartController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            List<Kart> kartlar = db.Kartlar.Where(x => x.UserId == id).ToList();
            return View(kartlar);
        }
        [Authorize]
        public ActionResult Yeni()
        {
            //https://stackoverflow.com/questions/15989764/display-all-images-in-a-folder-in-mvc-with-a-foreach
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Img")).Select(fn => "~/Img/" + Path.GetFileName(fn));
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yeni(KartVM vm)
        {
            string id = User.Identity.GetUserId();
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Img")).Select(fn => "~/Img/" + Path.GetFileName(fn));
            if (ModelState.IsValid)
            {
                var bolum = vm.Mesaj.Length / 3;
                var aralik = bolum * 2;
                string Mesaj1 = vm.Mesaj.Substring(0, bolum);
                string Mesaj2 = vm.Mesaj.Substring(bolum, bolum);
                string Mesaj3 = vm.Mesaj.Substring(aralik);
                Kart kart = new Kart()
                {
                    AliciAd = vm.AliciAd,
                    GonderenAd = vm.GonderenAd,
                    ResimYolu = vm.Resimyolu,
                    Mesaj1 = Mesaj1,
                    Mesaj2 = Mesaj2,
                    Mesaj3 = Mesaj3,
                    UserId = id,
                    Baslik = "Sevgili " + vm.AliciAd
                };
                db.Kartlar.Add(kart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        [Authorize]
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