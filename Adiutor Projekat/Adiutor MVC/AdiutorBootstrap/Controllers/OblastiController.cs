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
                if (tagovi[0] == '#')
                { 

                    return View("~/Views/Oblasti/PrikazListePitanja.cshtml",VratiOblastPretrage(tagovi));
                }
                else if(Korisnici.Nadji(tagovi)!=null)
                {
                    //sada ovde treba da vratimo korinsicki panel trazenog korisnika
                    try
                    {
                        KorisnikDTO kor = Korisnici.Nadji(tagovi);
                        HomeController con = new HomeController();
                        return View("~/Views/Home/KorisnickiPanel.cshtml", con.KreirajKorisnickiPanelModel(kor.Id));
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                else
                {
                    //KorisnikDTO kor = Korisnici.Nadji(tagovi);
                    HomeController con = new HomeController();
                    return View("~/Views/Home/KorisnickiPanel.cshtml", con.KreirajKorisnickiPanelModel((int)Session["Id"]));
                }
            }
            catch (Exception e)
             {
                 return View("~/Views/Oblasti/PrikazListePitanja.cshtml", null);
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
                    List<OdgovorDTO> odgovori = Odgovori.VratiSve(pit.Id);

                    PitanjeModel p = new PitanjeModel()
                    {
                        Id = pit.Id,
                        DatumVreme = pit.DatumVreme,
                        Text = pit.Tekst,
                        AutorPitanja = autorPitanja.Ime,
                        AutorId = autorPitanja.Id,
                        NaslovPitanja = pit.Naslov,
                        Tagovi = TagoviController.TagoviPitanja(pit.Id),
                        BrojOdgovora=odgovori.Count,
                    };
                    PitanjaZaVracanje.Add(p);
                }

                return PitanjaZaVracanje;

            }
            else
            {
                //ukoliko je poceo da unosi korisnik nesto razlicito od taga, verovatno je pokusao da trazi  po imenu korisnika
                return null;
            }

        }

        [HttpPost]
        public JsonResult DodajLiteraturu(LiteraturaModel literatura)
        {
            LiteraturaDTO lit = new LiteraturaDTO();
            lit.Link ="https://"+literatura.Link;
            lit.Naziv = literatura.Naziv;
            lit.OblastId = literatura.OblastId;

            Literature.Dodaj(lit);


            return Json(literatura, JsonRequestBehavior.AllowGet);
        }


	}
}