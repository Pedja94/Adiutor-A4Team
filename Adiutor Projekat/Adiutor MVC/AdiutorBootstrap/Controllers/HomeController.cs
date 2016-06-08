using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DTO;
using Business.DataAccess;


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
            LogInModel model = new LogInModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            KorisnikDTO user = Korisnici.Nadji(model.username);
            if (ModelState.IsValid && user != null && user.Password == model.password && user.StatusId == 1)
            {
                Session["Id"] = user.Id;
                Session["Role"] = user.RoleId;
                Session["Username"] = user.Username;
                Session["Ime"] = user.Ime;
                Session["Prezime"] = user.Prezime;
                return RedirectToAction("Odabir_predmeta", "Odabir_predmeta");
            }
            else
            {
                ViewBag.BadLogin = true;
                return View("Pocetna", model);
            }
        }



        [HttpGet]//trebace nam i kontroler za odjavljivanje sa naloga, nakon sto se neko prijavi
        public ActionResult LogOut()
        {
            if (Session["Id"] != null) 
            {
                Session["Id"] = null;
                Session["Role"] = null;
                Session["Username"] = null;
                Session["Ime"] = null;
                Session["Prezime"] = null;

                return RedirectToAction("Pocetna", "Home");
            }
            else
            {
                return RedirectToAction("Pocetna", "Home");
            }
        }

    }
}