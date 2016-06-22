using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DataAccess;
using Business.DTO;
using AdiutorBootstrap.Models;
using AdiutorBootstrap.Controllers;


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
            korisnickiPanel.Korisnik = VratiKorisnikModel(korisnikId);

            foreach(var pitanje in Pitanja.VratiSvaPitanjaKorisnika(korisnikId))
            {
                korisnickiPanel.Pitanja.Add(VratiPitanjaKorisnikaModel(pitanje));
            }


            return View("~/Views/Home/KorisnickiPanel.cshtml",korisnickiPanel);
        }



        public KorisnikModel VratiKorisnikModel(int korisnikId)
        {
            KorisnikDTO kor = Korisnici.Procitaj(korisnikId);
            KorisnikModel Korisnik = new KorisnikModel();
            Korisnik.Id = kor.Id;
            Korisnik.Ime = kor.Ime;
            Korisnik.Opis = kor.Opis;
            Korisnik.Slika = kor.Slika;
            Korisnik.Smer = kor.Smer;
            Korisnik.Username = kor.Username;
            Korisnik.Prezime = kor.Prezime;
            Korisnik.GodinaStudija = kor.GodinaStudija.ToString();
            Korisnik.Email = kor.Email;
            Korisnik.BrojIndeksa = kor.BrojIndeksa;

            return Korisnik;
        }


        public  PitanjeModel VratiPitanjaKorisnikaModel(PitanjeDTO pitanje)
        {
            PitanjeModel pit = new PitanjeModel()
            {
                Text=pitanje.Tekst,
                Id = pitanje.Id,
                DatumVreme = pitanje.DatumVreme,
                AutorId=pitanje.KorisnikId,
                OblastId=pitanje.OblastId,
            };

            foreach(var tag in Pitanja.VratiSveTagovePitanja(pit.Id))
            {
                TagModel tg = new TagModel()
                {
                    TagID=tag.Id,
                    Ime=tag.Ime,
                    TagIme=tag.TagIme,
                    Opis=tag.Opis
                };
                pit.Tagovi.Add(tg);
            }

            return pit;

        }

	}
}