using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.Entiteti;
using Business.Mapiranja;
using Business.Data_Access;


namespace AdiutorBootstrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Pocetna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            Korisnik user = Korisnici.Nadji(model.UserName);
            if (user != null && Korisnici.ProveriSifru(user.Id, model.Password))
            {
                Session["Id"] = user.Id;
                return RedirectToAction("KorisnickiPanel", "KorisnickiPanel");
            }
            else
            {
                return RedirectToAction("Pocetna", "Home");
            }
        }

    }
}