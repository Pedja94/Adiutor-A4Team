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

        public ActionResult KorisnickiPanel(KorisnikModel korisnik)
        {
            KorisnikDTO user = Korisnici.Nadji(korisnik.Username);
            if (Session["Id"] != null && (int)Session["Id"]==user.Id)
            {
                
            }
              return View("KorisnickiPanel");
        }



        public ActionResult Pocetna()
        {
            if (Session["Id"] == null)
            {

                return View();
            }
            else
            {
                LogInModel model=new LogInModel();
                model.username=(string)Session["Username"];
                model.password=(string)Session["Password"];
                return LogIn(model);
            }
        }

        public ActionResult KlikNaLink(int Id)
        {
            Console.WriteLine(Id);
            PitanjaOdgovoriKomentariModel model = new PitanjeIOdgovoriController().PitanjeIOdgovori1(Id);
            TempData["model"] = model;
            return RedirectToAction("Klik", "PitanjeIOdgovori");
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
                ViewBag.foto= user.Slika;
                ViewBag.Ime = user.Ime;
                ViewBag.Prezime = user.Prezime;
                ViewBag.Username = user.Username;

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

             
                
                List<PitanjeDTO> ListaPostavljenihPitanja = Pitanja.VratiSvaPitanjaKorisnika(user.Id);
                List<PitanjeModel> PitanjaKorisnika = new List<PitanjeModel>();

                foreach (var pitanjce in ListaPostavljenihPitanja)
                {
                    PitanjeModel pit = new PitanjeModel
                    {
                        DatumVreme=pitanjce.DatumVreme,
                        Id=pitanjce.Id,
                        Text=pitanjce.Tekst,
                        AutorPitanja=pitanjce.KorisnikId.ToString()
                    };
                    PitanjaKorisnika.Add(pit);
                }

                KorisnickiPanelModel panel = new KorisnickiPanelModel();
                panel.Korisnik = korisnik;
                panel.Pitanja = PitanjaKorisnika;
             
                return View("KorisnickiPanel",panel);

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
        public ActionResult IzmeniPodatkeZahtev(KorisnickiPanelModel model)
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

            KorisnickiPanelModel panel = new KorisnickiPanelModel();
            panel.Korisnik = korisnik;
            panel.Pitanja = model.Pitanja;

            return View("KorisnickiPanel", panel);
        }

        [HttpPost]
        public ActionResult IzmeniPodatke(KorisnickiPanelModel korisnik)
        {
            KorisnikDTO korisnikZaIzmenu = new KorisnikDTO();
            korisnikZaIzmenu.Ime = korisnik.Korisnik.Ime;
            korisnikZaIzmenu.Prezime = korisnik.Korisnik.Prezime;
            korisnikZaIzmenu.Email = korisnik.Korisnik.Email;
            korisnikZaIzmenu.Slika = korisnik.Korisnik.Slika;
            korisnikZaIzmenu.Password = (string)Session["Password"];
            korisnikZaIzmenu.Id = (int)Session["Id"];
            korisnikZaIzmenu.GodinaStudija = (decimal)Session["GodinaStudija"];
            korisnikZaIzmenu.RoleId= (int)Session["Role"];
            korisnikZaIzmenu.StatusId = (int)Session["Status"];
            korisnikZaIzmenu.Username = (string)Session["Username"];
            korisnikZaIzmenu.Opis = korisnik.Korisnik.Opis; 
            korisnikZaIzmenu.BrojIndeksa = korisnik.Korisnik.BrojIndeksa;
            korisnikZaIzmenu.Smer = korisnik.Korisnik.Smer;
            
        
            korisnik.Korisnik.Username = (string)Session["Username"];
            Korisnici.Izmeni(korisnikZaIzmenu);


            return View("KorisnickiPanel", korisnik);

        }

    }
}