using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DataAccess;
using Business.DTO;
using AdiutorBootstrap.Controllers;

namespace AdiutorBootstrap.Controllers
{
    public class OblastiController : Controller
    {
        //
        // GET: /Oblasti/
        public ActionResult Oblasti()
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


    


        public ActionResult TrazenjePoTagu(string tagovi){

            try
            {         
                return View("~/Views/Oblasti/Oblasti.cshtml",VratiOblastPretrage(tagovi));
              
            }
            catch (Exception e)
            {
                return View("~/Views/Home/KorisnickiPanel.cshtml");
            }

        }


        public OblastModel VratiOblastPretrage(string tagovi)
        {
            string primljeniTagovi = tagovi;
            List<PitanjeDTO> PronadjenaPitanja = new List<PitanjeDTO>();


            if (primljeniTagovi[0] == '#')
            {
                OblastModel oblast = new OblastModel();
                oblast.Naziv = "Nesto";
                oblast.Pitanja.ListaPitanja = PitanjaPoTagovima(tagovi);
                return oblast;
            }
            else
            {
                return null;
            }
        }


        public static List<PitanjeModel> PitanjaPoTagovima(string tagovi)
        {
            List<PitanjeDTO> PronadjenaPitanja = new List<PitanjeDTO>();
            List<PitanjeModel> PitanjaZaVracanje = new List<PitanjeModel>();

            string primljeniTagovi = tagovi;

            if (primljeniTagovi[0] == '#')
            {
                //ovde smo ako pretrazujemo po tagovima 
                char[] separatingChar = { '#', ' ' };
                string[] nizTagova = primljeniTagovi.Split(separatingChar, System.StringSplitOptions.RemoveEmptyEntries);

                List<PitanjeDTO> pitanja = Pitanja.VratiSvaPitanjaTaga(nizTagova[0]);

                string[] tagoviPitanja = new string[pitanja.Count];
                for (int k = 0; k < tagoviPitanja.Length; k++)
                {
                    tagoviPitanja[k] = "";
                }


                int i = 0;
                foreach (var pitanje in pitanja)
                {
                    List<TagDTO> Tagovi = Pitanja.VratiSveTagovePitanja(pitanje.Id);
                    foreach (var tag in Tagovi)
                    {
                        tagoviPitanja[i] = "" + tagoviPitanja[i] + tag.TagIme + " ";

                    }
                    i++;
                }

                //treba da konvertujemo listu pitanja u niz pitanja

                PitanjeDTO[] pitanjaNiz = pitanja.ToArray();

                int j = 0;
                for (int petlja = 0; petlja < tagoviPitanja.Length; petlja++)
                {
                    int brojac = 0;
                    foreach (var tag in nizTagova)
                    {
                        if (tagoviPitanja[j].Contains(tag))
                        {
                            brojac++;
                            if (brojac == nizTagova.Length)
                            {
                                PronadjenaPitanja.Add(pitanjaNiz[j]);
                            }
                        }
                    }
                    j++;
                }

                foreach (var pit in PronadjenaPitanja)
                {
                    KorisnikDTO autorPitanja = Korisnici.Procitaj(pit.KorisnikId);
                    PitanjeModel p = new PitanjeModel()
                    {
                        Id = pit.Id,
                        DatumVreme = pit.DatumVreme,
                        Text = pit.Tekst,
                        AutorPitanja = autorPitanja.Ime,
                        AutorId = autorPitanja.Id,
                        NaslovPitanja = pit.Naslov,
                        Tagovi = TagoviController.TagoviPitanja(pit.Id),
                    };
                    PitanjaZaVracanje.Add(p);
                }

                return PitanjaZaVracanje;

            }
            else
            {
                return null;
            }

        }



	}
}