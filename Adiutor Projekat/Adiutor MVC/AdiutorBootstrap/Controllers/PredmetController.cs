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
    public class PredmetController : Controller
    {
        // GET: Predmet
        //public ActionResult Predmet()
        //{
        //    PredmetModel predmet = new PredmetModel();
        //    predmet.NazivPredmeta = "Osnovi elektrotehnike 2";
        //    predmet.GodinaStudija = 1;
        //    predmet.ZaduzeniProfesor = "Branko Brejking";
        //    predmet.PregledaProfesor = true;
        //    predmet.Id = 33;
        //    predmet.OpisPredmeta = "Kurs Osnovi elektrotehnike 1 se, prema novom nastavnom programu, izvodi u prvom semestru osnovnih studija na Elektronskom fakultetu u Nišu.";

        //    OblastModel oblast1 = new OblastModel
        //    {
        //        Naziv = "Elektrostatika",
        //        Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
        //    };

        //    OblastModel oblast2 = new OblastModel
        //    {
        //        Naziv = "Elektromagnetika",
        //        Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
        //    };

        //    OblastModel oblast3 = new OblastModel
        //    {
        //        Naziv = "Elektrostatika",
        //        Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
        //    };
        //    predmet.Oblasti.Add(oblast1);
        //    predmet.Oblasti.Add(oblast2);
        //    predmet.Oblasti.Add(oblast3);

        //    return View(predmet);
        //}


        public ActionResult VratiPredmetPoId(int predmetId)
        {
            PredmetModel predmet = new PredmetModel();
            PredmetDTO pred = Predmeti.Procitaj(predmetId);

            predmet.GodinaStudija = pred.GodinaStudija;
            predmet.Id = pred.Id;
            predmet.NazivPredmeta = pred.Naziv;
            predmet.Semestar = pred.Semestar;



            //ovo samo zasad, jer je neprakticno
            foreach (var oblast in Oblasti.VratiSve())
            {
                if (oblast.PredmetId == pred.Id)
                {
                    OblastModel obl = new OblastModel
                    {
                        Naziv=oblast.Ime,
                        Opis=oblast.Opis,
                        Id=oblast.Id,
                    };
                    predmet.Oblasti.Add(obl);
                }
            }

            //List<ProfesorDTO> profes = Profesori.VratiSve(pred.Id);
            if (pred.ZaduzenId != 0)
            {
                KorisnikDTO prof = Korisnici.Procitaj(pred.ZaduzenId);
                if (prof.Id == (int)Session["Id"])
                    predmet.PregledaProfesor = true;
                else
                    predmet.PregledaProfesor = false;

                predmet.ZaduzeniProfesor = prof.Ime + " " + prof.Prezime;
            }
            else
            {
                predmet.ZaduzeniProfesor = "Nema";
            }

            predmet.OpisPredmeta = pred.Opis;
            

            return View("Predmet", predmet);
        }



        public ActionResult IzmeniPodatkeOPredmetuZahtev (int predmetId)
        {
            ViewBag.Izmena = true;
            PredmetDTO pred = Predmeti.Procitaj(predmetId);
            return View();
        }


        public JsonResult DodajNovuOblast(NovaOblastModel oblast)
        {
            OblastDTO obl=new OblastDTO();
            obl.Ime=oblast.ImeOblasti;
            obl.Opis=oblast.ImeOblasti;
            obl.PredmetId=oblast.PredmetId;

            Oblasti.Dodaj(obl);


            return Json(oblast, JsonRequestBehavior.AllowGet);
        }

    }
}