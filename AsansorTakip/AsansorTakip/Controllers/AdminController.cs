using AsansorTakip.Models;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AsansorTakip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BitirmeProjesiEntities1 admin = new BitirmeProjesiEntities1();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = admin.Asansorler.ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult AsansorGetir(int id)
        {
            var asansor = admin.Asansorler.Find(id);
            return View("AsansorGetir",asansor);
        }
        [Authorize]
        public ActionResult AsansorGuncelle(Asansorler asansor)
        {
            var asnr = admin.Asansorler.Find(asansor.Id);
            asnr.MaxAgirlik = asansor.MaxAgirlik;
            asnr.QrCodeImageString = asansor.QrCodeImageString;
            asnr.SeriNumarasi = asansor.SeriNumarasi;
            asnr.ToplamMotorGucu = asansor.ToplamMotorGucu;
            admin.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniAsansor()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniAsansor(Asansorler asansor, Musteriler musteri,Bakimlar bakim)
        {
            musteri.EklenmeTarihi = DateTime.Now;
            musteri.IsActive = true;
            admin.Musteriler.Add(musteri);
            asansor.MusteriId = musteri.Id;
            asansor.IsActive = true;
            asansor.EklenmeTarihi = DateTime.Now;
            admin.Asansorler.Add(asansor);
            bakim.AsansorId = asansor.Id;
            bakim.BakimUcreti = 0;
            bakim.BakimTarihi = DateTime.Now;
            bakim.Aciklama = "Asansör Yeni Takıldı";
            admin.Bakimlar.Add(bakim);
            admin.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public ActionResult DetayListele(int id)
        {
            var deger = admin.Bakimlar.Find(id);
            return View(deger);
        }
        [HttpPost]
        [Authorize]
        public ActionResult DetayListele(Bakimlar bakim,int id)
        {
            var deger = admin.Bakimlar.Where(x=>x.AsansorId == id).FirstOrDefault();
            deger.AsansorId = id;
            deger.BakimUcreti = bakim.BakimUcreti;
            deger.Aciklama = bakim.Aciklama;
            deger.BakimTarihi = DateTime.Now;
            admin.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AsansorSil(int id)
        {
            var asansor = admin.Asansorler.Find(id);
            var musteri = admin.Musteriler.Find(asansor.MusteriId);
            var bakim = admin.Bakimlar.Where(x=>x.AsansorId==asansor.Id).FirstOrDefault();
            admin.Musteriler.Remove(musteri);
            admin.Bakimlar.Remove(bakim);
            admin.Asansorler.Remove(asansor);
            admin.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BakimlariListele()
        {
            var degerler = admin.Bakimlar.ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult MusteriListele()
        {
            var degerler = admin.Musteriler.ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult MusteriSil(int id)
        {
            var musteri = admin.Musteriler.Find(id);
            admin.Musteriler.Remove(musteri);
            admin.SaveChanges();
            return RedirectToAction("MusteriListele");
        }
       
    }
}