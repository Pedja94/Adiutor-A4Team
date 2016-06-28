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
    public class Odabir_predmetaController : Controller
    {
        //
        // GET: /Odabir_predmeta/
        public ActionResult Odabir_predmeta()
        {
            if (Session["Id"] != null)
            {
                OdabirPredmetaModel model = new OdabirPredmetaModel();
                SpremiSmerove(model);
                return View(model);
            }
            else
            {
                return RedirectToAction("Pocetna", "Home");
            }
        }

        void SpremiSmerove(OdabirPredmetaModel model)
        {
            List<SmerDTO> smerovi = Smerovi.VratiSve();
            SmerCont cont;

            foreach (SmerDTO smer in smerovi)
            {
                cont = new SmerCont()
                    {
                        Id = smer.Id,
                        PocSem = smer.PocSem,
                        KrajSem = smer.KrajSem,
                        Ime = smer.Ime
                    };
 
                if (smer.Ime == "I godina")
                {
                    model.listaSmerova.Insert(0, cont);
                }
                else
                {
                    model.listaSmerova.Add(cont);
                }
            }    
        }

        [HttpGet]
        public JsonResult VratiPredmete(SmerSemestarModel model)
        {
            List<PredmetDTO> lista = Predmeti.VratiSvePredmete(model.smerId);
            PredmetCont cont;
            List<PredmetCont> predmeti = new List<PredmetCont>();

            foreach (PredmetDTO predmet in lista)
            {
                if (model.semestar == predmet.Semestar)
                {
                    cont = new PredmetCont()
                    {
                        Id = predmet.Id,
                        Ime = predmet.Naziv
                    };
                    predmeti.Add(cont);
                }
            }

            return Json(predmeti, JsonRequestBehavior.AllowGet);
        }
	}
}