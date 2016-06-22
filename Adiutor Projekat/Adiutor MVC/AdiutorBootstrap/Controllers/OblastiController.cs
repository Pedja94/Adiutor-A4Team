using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DataAccess;
using Business.DTO;

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


    

        //public ActionResult KlikNaPitanje(int idPitanja)
        //{
        //    PitanjaOdgovoriKomentariModel model = new PitanjeIOdgovoriController().PitanjeIOdgovori1(idPitanja);
        //    TempData["model"] = model;
        //    return View("~/Views/PitanjeIOdgovori/PitanjeIOdgovori.cshtml", model);
        //}

        public ActionResult TrazenjePoTagu(string tagovi){

            string primljeniTagovi = tagovi;
            List<PitanjeDTO> PronadjenaPitanja = new List<PitanjeDTO>();

            if (primljeniTagovi[0] == '#')
            {
                //ovde smo ako pretrazujemo po tagovima 
                char [] separatingChar = {'#',' '};
                string[] nizTagova = primljeniTagovi.Split(separatingChar, System.StringSplitOptions.RemoveEmptyEntries);

                List<PitanjeDTO> pitanja = Pitanja.VratiSvaPitanjaTaga(nizTagova[0]);

                string[] tagoviPitanja = new string[pitanja.Count];
                for (int k=0; k<tagoviPitanja.Length;k++)
                {
                    tagoviPitanja[k] = "";
                }
    

                int i=0;
                foreach (var pitanje in pitanja)
                {
                    List<TagDTO> Tagovi = Pitanja.VratiSveTagovePitanja(pitanje.Id);
                    foreach (var tag in Tagovi)
                    {
                        tagoviPitanja[i] = ""+tagoviPitanja[i]+tag.TagIme + " ";
                 
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
                
                       
                OblastModel oblast = new OblastModel();
                oblast.Naziv="Nesto";

                foreach(var pit in PronadjenaPitanja)
                {
                    KorisnikDTO autorPitanja=Korisnici.Procitaj(pit.KorisnikId);
                    PitanjeModel p =new PitanjeModel()
                    {
                            Id = pit.Id,
                            DatumVreme = pit.DatumVreme,
                            Text = pit.Tekst,
                            AutorPitanja = autorPitanja.Ime,
                            AutorId=autorPitanja.Id,
                    };
                    oblast.Pitanja.ListaPitanja.Add(p);
                
                }
                return View("~/Views/Oblasti/Oblasti.cshtml", oblast);
            }
            else
            {
                return View("~/Home/Pocetna");
            }

        }

	}
}