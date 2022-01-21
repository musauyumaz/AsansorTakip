using AsansorTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AsansorTakip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        BitirmeProjesiEntities1 veriTabani = new BitirmeProjesiEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Giris(Adminler admin)
        {
            var bilgiler = veriTabani.Adminler.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);
            if (bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi,false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris","Login");
        }
    }
}