using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DTO;
using Business.DataAccess;
using AdiutorBootstrap.Controllers;
using System.IO;

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



        public  ActionResult Pocetna()
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

        //public ActionResult KlikNaLink(int Id)
        //{
        //    Console.WriteLine(Id);
        //    PitanjaOdgovoriKomentariModel model = new PitanjeIOdgovoriController().PitanjeIOdgovori1(Id);
        //    TempData["model"] = model;
        //    return RedirectToAction("Klik", "PitanjeIOdgovori");
        //}


        public ActionResult KorisnickiPanel()
        {
            return View();

        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            KorisnikDTO user = Korisnici.Nadji(model.username);
            if (ModelState.IsValid && user != null && user.Password == model.password && user.StatusId == 1 )
            {
                if (user.RoleId != 3) 
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
                    korisnik.Id = user.Id;
                    korisnik.Role = user.RoleId;

                    List<PitanjeDTO> ListaPostavljenihPitanja = Pitanja.VratiSvaPitanjaKorisnika(user.Id);
                    List<PitanjeModel> PitanjaKorisnika = new List<PitanjeModel>();
                    KorisnickiPanelController con = new KorisnickiPanelController();
                    foreach (var pitanjce in ListaPostavljenihPitanja)
                    {
                        PitanjeModel pit = con.VratiPitanjaKorisnikaModel(pitanjce);
                        PitanjaKorisnika.Add(pit);
                    }

                    KorisnickiPanelModel panel = new KorisnickiPanelModel();
                    panel.Korisnik = korisnik;
                    panel.Pitanja = PitanjaKorisnika;

                    if (korisnik.Role == 2)
                    {
                        List<PredmetDTO> ZaduzeniPredmeti = Predmeti.VratiSvePredmeteZaduzenog(korisnik.Id);

                        foreach (var pr in ZaduzeniPredmeti)
                        {
                            PredmetModel pred = new PredmetModel()
                            {
                                PregledaProfesor = true,
                                GodinaStudija = pr.GodinaStudija,
                                Id = pr.Id,
                                NazivPredmeta = pr.Naziv,
                                OpisPredmeta = pr.Opis,
                                ZaduzeniProfesor = (string)Session["Username"],
                            };
                            panel.ListaZaduzenihPredmeta.Add(pred);
                        }
                    }
             
                
               
             
                    return View("KorisnickiPanel",panel);
                }
                else
                {
                    AdministracijaController admin = new AdministracijaController();
                    return admin.Administracija(user.Id);
                }
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
            korisnik.Role = user.RoleId;

            


            List<PitanjeDTO> ListaPostavljenihPitanja = Pitanja.VratiSvaPitanjaKorisnika(user.Id);
            List<PitanjeModel> PitanjaKorisnika = new List<PitanjeModel>();
            KorisnickiPanelController con = new KorisnickiPanelController();
            foreach (var pitanjce in ListaPostavljenihPitanja)
            {
                PitanjeModel pit = con.VratiPitanjaKorisnikaModel(pitanjce);
                PitanjaKorisnika.Add(pit);
            }

            KorisnickiPanelModel panel = new KorisnickiPanelModel();
            panel.Korisnik = korisnik;
            panel.Pitanja = PitanjaKorisnika;

            if (korisnik.Role == 2)
            {
                List<PredmetDTO> ZaduzeniPredmeti = Predmeti.VratiSvePredmeteZaduzenog(korisnik.Id);

                foreach (var pr in ZaduzeniPredmeti)
                {
                    PredmetModel pred = new PredmetModel()
                    {
                        PregledaProfesor = true,
                        GodinaStudija = pr.GodinaStudija,
                        Id = pr.Id,
                        NazivPredmeta = pr.Naziv,
                        OpisPredmeta = pr.Opis,
                        ZaduzeniProfesor = (string)Session["Username"],
                    };
                    panel.ListaZaduzenihPredmeta.Add(pred);
                }
            }
             

            return View("KorisnickiPanel", panel);
        }

        public KorisnickiPanelModel KreirajKorisnickiPanelModel(int korisnikId)
        {
            ViewBag.Izmena = false;
            KorisnikDTO user = Korisnici.Procitaj(korisnikId);
            //KorisnikDTO user = Korisnici.Nadji((string)Session["Username"]);
            KorisnikModel korisnik = new KorisnikModel();
            korisnik.Ime = user.Ime;
            korisnik.Prezime = user.Prezime;
            korisnik.Username = user.Username;
            korisnik.Opis = user.Opis;
            korisnik.Smer = user.Smer;
            korisnik.BrojIndeksa = user.BrojIndeksa;
            korisnik.Slika = user.Slika;
            korisnik.Email = user.Email;
            korisnik.Id = korisnikId;
            korisnik.Role = user.RoleId;

            List<PitanjeDTO> ListaPostavljenihPitanja = Pitanja.VratiSvaPitanjaKorisnika(user.Id);
            List<PitanjeModel> PitanjaKorisnika = new List<PitanjeModel>();
            KorisnickiPanelController con = new KorisnickiPanelController();
            foreach (var pitanjce in ListaPostavljenihPitanja)
            {
                PitanjeModel pit = con.VratiPitanjaKorisnikaModel(pitanjce);
                PitanjaKorisnika.Add(pit);
            }

            KorisnickiPanelModel panel = new KorisnickiPanelModel();
            panel.Korisnik = korisnik;
            panel.Pitanja = PitanjaKorisnika;

            if (korisnik.Role == 2)
            {
                List<PredmetDTO> ZaduzeniPredmeti = Predmeti.VratiSvePredmeteZaduzenog(korisnik.Id);

                foreach (var pr in ZaduzeniPredmeti)
                {
                    PredmetModel pred = new PredmetModel()
                    {
                        PregledaProfesor = true,
                        GodinaStudija = pr.GodinaStudija,
                        Id = pr.Id,
                        NazivPredmeta = pr.Naziv,
                        OpisPredmeta = pr.Opis,
                       
                    };
                    panel.ListaZaduzenihPredmeta.Add(pred);
                }
            }
             


            return panel;
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
            korisnikZaIzmenu.RoleId = korisnik.Role;

           
            string slikaputanja;
            if (korisnik.FajlSlika != null) { 
                if (korisnik.FajlSlika.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(korisnik.FajlSlika.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    korisnik.FajlSlika.SaveAs(path);
                    slikaputanja = "/Content/Images/" + fileName;
                    korisnikZaIzmenu.Slika = slikaputanja;
                    int startIndex = slikaputanja.IndexOf("Upload");



                    string proba = "Ne vjeruj mi nocas";
                    int pocetni = proba.IndexOf("vjeruj");

                }
            }

            
        
            korisnik.Username = (string)Session["Username"];
            Korisnici.Izmeni(korisnikZaIzmenu);


            return View("KorisnickiPanel", KreirajKorisnickiPanelModel((int)Session["Id"]));

        }

    }
}