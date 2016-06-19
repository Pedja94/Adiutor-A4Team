using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DataAccess;
using Business.DTO;
using AdiutorBootstrap.Models;

namespace AdiutorBootstrap.Controllers
{
    public class KorisnickiPanelController : Controller
    {
        //
        // GET: /KorisnickiPanel/
        public ActionResult KorisnickiPanel()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Pocetna", "Home");
            }
        }

        public ActionResult KlikNaKorisnika(int korisnikId)
        {
            KorisnikDTO kor = Korisnici.Procitaj(korisnikId);
            KorisnickiPanelModel korisnickiPanel = new KorisnickiPanelModel();
            korisnickiPanel.Korisnik.Id = kor.Id;
            korisnickiPanel.Korisnik.Ime = kor.Ime;
            korisnickiPanel.Korisnik.Opis = kor.Opis;
            korisnickiPanel.Korisnik.Slika = kor.Slika;
            korisnickiPanel.Korisnik.Smer = kor.Smer;
            korisnickiPanel.Korisnik.Username = kor.Username;
            korisnickiPanel.Korisnik.Prezime = kor.Prezime;
            korisnickiPanel.Korisnik.GodinaStudija = kor.GodinaStudija.ToString();
            korisnickiPanel.Korisnik.Email = kor.Email;
            korisnickiPanel.Korisnik.BrojIndeksa = kor.BrojIndeksa;

            foreach(var pitanje in Pitanja.VratiSvaPitanjaKorisnika(korisnikId))
            {
                PitanjeModel pit = new PitanjeModel()
                {
                    Text=pitanje.Tekst,
                    Id=pitanje.Id,
                    DatumVreme=pitanje.DatumVreme,
                };
                korisnickiPanel.Pitanja.Add(pit);
            }


            return View("~/Views/Home/KorisnickiPanel.cshtml",korisnickiPanel);
        }
	}
}