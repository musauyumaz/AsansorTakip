using AsansorTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsansorTakip.Controllers
{
    public class AnasayfaController : Controller
    {
        BitirmeProjesiEntities1 bitirme = new BitirmeProjesiEntities1();
        // GET: Anasayfa
        public ActionResult Index()
        {
            var degerler = bitirme.Anasayfa.ToList();
            return View(degerler);
        }
        public ActionResult Hakkimizda()
        {
            var degerler = bitirme.Anasayfa.ToList();
            return View(degerler);
        }
        public ActionResult Iletisim()
        {
            var degerler = bitirme.Anasayfa.ToList();
            return View(degerler);
        }
    }
}