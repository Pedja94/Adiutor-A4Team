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
        public ActionResult Predmet()
        {
            PredmetModel predmet = new PredmetModel();
            predmet.NazivPredmeta = "Osnovi elektrotehnike 2";
            predmet.GodinaStudija = 1;
            predmet.ZaduzeniProfesor = "Branko Brejking";

            OblastModel oblast1 = new OblastModel
            {
                Naziv = "Elektrostatika",
                Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
            };

            OblastModel oblast2 = new OblastModel
            {
                Naziv = "Elektromagnetika",
                Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
            };

            OblastModel oblast3 = new OblastModel
            {
                Naziv = "Elektrostatika",
                Opis = "Ovo je elektrostatika, bavi se statickim naelektrisanjem i tako dalje cestica i tako dalje."
            };
            predmet.Oblasti.Add(oblast1);
            predmet.Oblasti.Add(oblast2);
            predmet.Oblasti.Add(oblast3);

            return View(predmet);
        }


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
            if (pred.ProfesorId != 0)
            {
                ProfesorDTO prof = Profesori.Procitaj(pred.ProfesorId);
                predmet.ZaduzeniProfesor = prof.PunoIme;
            }
            else
            {
                predmet.ZaduzeniProfesor = "Nema";
            }

            predmet.OpisPredmeta = pred.Opis;
            

            return View("Predmet", predmet);
        }

       
    }
}