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
    public class AdministracijaController : Controller
    {
        //
        // GET: /Administracija/
        public ActionResult Administracija()
        {
            return View();
        }

        public ActionResult AdministracijaSmerova()
        {
            List<SmerModel> model = new List<SmerModel>();
            List<SmerDTO> smerovi = Smerovi.VratiSve();

            foreach (SmerDTO smer in smerovi)
            {
                model.Add(new SmerModel() {
                    Id = smer.Id,
                    PocSem = smer.PocSem,
                    KrajSem = smer.KrajSem,
                    Ime = smer.Ime
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult IzmeniSmer(int smerId)
        {
            SmerModel model = new SmerModel();
            if (smerId == -1)
            {
                model.Id = -1;
                model.Error = false;
                return View("IzmeniSmer", model);
            }
            else
            {
                SmerDTO smer = Smerovi.Procitaj(smerId);
                model.Id = smer.Id;
                model.Ime = smer.Ime;
                model.KrajSem = smer.KrajSem;
                model.PocSem = smer.PocSem;
                model.Error = false;
                return View("IzmeniSmer", model);
            }
        }

        [HttpPost]
        public ActionResult IzmeniSmer(SmerModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PocSem >= model.KrajSem)
                {
                    model.Error = true;
                    return View(model);
                }

                SmerDTO smer = new SmerDTO()
                {
                    Ime = model.Ime,
                    PocSem = model.PocSem,
                    KrajSem = model.KrajSem
                };

                if (model.Id == -1)
                {
                    Smerovi.Dodaj(smer);
                }
                else
                {
                    smer.Id = model.Id;
                    Smerovi.Izmeni(smer);
                }

                return RedirectToAction("AdministracijaSmerova");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ObrisiSmer(int smerId)
        {
            Smerovi.Obrisi(smerId);
            return RedirectToAction("AdministracijaSmerova");
        }

        public ActionResult AdministracijaPredmeta()
        {
            List<AdminPredmetModel> model = new List<AdminPredmetModel>();
            List<PredmetDTO> predmeti = Predmeti.VratiSve();

            foreach (PredmetDTO predmet in predmeti)
            {
                AdminPredmetModel predmetModel = new AdminPredmetModel()
                {
                    Id = predmet.Id,
                    Naziv = predmet.Naziv,
                    GodinaStudija = predmet.GodinaStudija,
                    Semestar = predmet.Semestar
                };
                List<SmerDTO> lista = Smerovi.VratiSveSmerove(predmet.Id);
                if (lista.Count > 0)
                {
                    predmetModel.smerId = lista[0].Id;
                    predmetModel.smerIme = lista[0].Ime;
                }
                model.Add(predmetModel);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult DodajPredmet()
        {
            AdminPredmetModel model = new AdminPredmetModel();
            List<SmerDTO> smerovi = Smerovi.VratiSve();
            foreach (SmerDTO smer in smerovi)
            {
                model.listaSmerova.Add(new SmerModel() {
                    Id = smer.Id,
                    Ime = smer.Ime
                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DodajPredmet(AdminPredmetModel model)
        {
            if (ModelState.IsValid)
            {
                PredmetDTO predmet = new PredmetDTO()
                {
                    Naziv = model.Naziv,
                    Opis = model.Opis,
                    Semestar = model.Semestar,
                    GodinaStudija = (model.Semestar - 1) / 2 + 1,
                };
                int predmetId = Predmeti.Dodaj(predmet);
                Smerovi.DodajPredmetSmeru(predmetId, model.smerId);
                return RedirectToAction("AdministracijaPredmeta");
            }
            List<SmerDTO> smerovi = Smerovi.VratiSve();
            foreach (SmerDTO smer in smerovi)
            {
                model.listaSmerova.Add(new SmerModel()
                {
                    Id = smer.Id,
                    Ime = smer.Ime
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ObrisiPredmet(int predmetId)
        {
            Predmeti.Obrisi(predmetId);
            return RedirectToAction("AdministracijaPredmeta");
        }

        //[HttpGet]
        //public ActionResult PostaviZaduzenog(int predmetId)
        //{
 
        //}
	}
}