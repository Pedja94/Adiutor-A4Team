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
            if (Session["Id"] == null)
            {
                LogInModel model = new LogInModel();
                return View(model);
            }
            else
            {
                LogInModel model=new LogInModel();
                model.username=(string)Session["Username"];
                model.password=(string)Session["Password"];
                return LogIn(model);
            }
        }

        public ActionResult KorisnickiPanel()
        {
            return View();
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
                Session["Password"] = user.Password;
                Session["GodinaStudija"] = user.GodinaStudija;
                ViewBag.foto = user.Slika;
                ViewBag.brIndeksa = user.BrojIndeksa;
                Session["Status"] = user.StatusId;

                //sada ovde treba da inicijalizujemo elemente korisnickog modela svim podacima iz baze

                KorisnikModel korisnik=new KorisnikModel();
                korisnik.Ime = user.Ime;
                korisnik.Prezime = user.Prezime;
                korisnik.Username = user.Username;
                korisnik.Opis = user.Opis;
                korisnik.Smer = user.Smer;
                korisnik.BrojIndeksa = user.BrojIndeksa;
                korisnik.Slika = user.Slika;
                korisnik.Email = user.Email;

                return View("KorisnickiPanel",korisnik);
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


        [HttpPost]
        public ActionResult IzmeniPodatkeZahtev()
        {
            ViewBag.Izmena = true;
            KorisnikDTO user = Korisnici.Nadji((string)Session["Username"]);
            KorisnikModel korisnik = new KorisnikModel();
            korisnik.Ime = user.Ime;
            korisnik.Prezime = user.Prezime;
            korisnik.Username = user.Username;
            korisnik.Opis = user.Opis;
            korisnik.Smer = user.Smer;
            korisnik.BrojIndeksa = user.BrojIndeksa;
            korisnik.Slika = user.Slika;
            korisnik.Email = user.Email;

            return View("KorisnickiPanel", korisnik);
        }

        [HttpPost]
        public ActionResult IzmeniPodatke(KorisnikModel korisnik)
        {
            KorisnikDTO korisnikZaIzmenu = new KorisnikDTO();
            korisnikZaIzmenu.Ime = korisnik.Ime;
            korisnikZaIzmenu.Prezime = korisnik.Prezime;
            korisnikZaIzmenu.Email = korisnik.Email;
            korisnikZaIzmenu.Slika = korisnik.Slika;
            korisnikZaIzmenu.Password = (string)Session["Password"];
            korisnikZaIzmenu.Id = (int)Session["Id"];
            korisnikZaIzmenu.GodinaStudija = (decimal)Session["GodinaStudija"];
            korisnikZaIzmenu.RoleId= (int)Session["Role"];
            korisnikZaIzmenu.StatusId = (int)Session["Status"];
            korisnikZaIzmenu.Username = (string)Session["Username"];
            korisnikZaIzmenu.Opis = korisnik.Opis; 
            korisnikZaIzmenu.BrojIndeksa = korisnik.BrojIndeksa;
            korisnikZaIzmenu.Smer = korisnik.Smer;
            
        
            korisnik.Username = (string)Session["Username"];
            Korisnici.Izmeni(korisnikZaIzmenu);

            return View("KorisnickiPanel", korisnik);

        }

    }
}