using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;

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
    }
}