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
        public string[] role = {"Korisnik", "Profesor", "Administrator"};
        public string[] status = { "Aktivan", "Neaktivan", "Blokiran" };

        //
        // GET: /Administracija/
        public ActionResult Administracija(int korisnikId)
        {
            KorisnikDTO proveri = Korisnici.Procitaj(korisnikId);
            if(proveri.RoleId==3)
            {
                return View("~/Views/Administracija/Administracija.cshtml");
            }
            else{
                return null;
            }
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

        [HttpGet]
        public ActionResult PostaviZaduzenog(int predmetId, string predmetIme)
        {
            ZaduzeniModel model = new ZaduzeniModel();
            List<KorisnikDTO> korisnici = Korisnici.VratiSve(2);
            foreach (KorisnikDTO user in korisnici)
            {
                model.korisnici.Add(new KorisnikModel {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.Username,
                    Email = user.Email
                });
            }

            model.predmetId = predmetId;
            model.predmetIme = predmetIme;
            return View(model);
        }

        [HttpGet]
        public ActionResult UpamtiZaduzenog(int predmetId, int profesorId)
        {
            Predmeti.DodajZaduzenog(predmetId, profesorId);

            return RedirectToAction("AdministracijaPredmeta");
        }

        public ActionResult AdministracijaKorisnika()
        {
            List<AdminKorisnikModel> model = new List<AdminKorisnikModel>();
            List<KorisnikDTO> korisnici = Korisnici.VratiSve(3);
            foreach (KorisnikDTO user in korisnici)
            {
                model.Add(new AdminKorisnikModel()
                {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    RoleID = user.RoleId,
                    RoleName = role[user.RoleId - 1],
                    StatusID = user.StatusId,
                    StatusName = status[user.StatusId - 1]
                });
            }

            return View(model);
        }

        [HttpGet]
        public JsonResult VratiKorisnika(string username)
        {
            KorisnikDTO user = Korisnici.Nadji(username);
            List<AdminKorisnikModel> model = new List<AdminKorisnikModel>();

            if (user != null)
            {
                model.Add(new AdminKorisnikModel()
                {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    RoleID = user.RoleId,
                    RoleName = role[user.RoleId - 1],
                    StatusID = user.StatusId,
                    StatusName = status[user.StatusId - 1]
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VratiSveProfesore()
        {
            List<KorisnikDTO> korisnici = Korisnici.VratiSve(2);
            List<AdminKorisnikModel> model = new List<AdminKorisnikModel>();

            foreach (KorisnikDTO user in korisnici)
            {
                model.Add(new AdminKorisnikModel()
                {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    RoleID = user.RoleId,
                    RoleName = role[user.RoleId - 1],
                    StatusID = user.StatusId,
                    StatusName = status[user.StatusId - 1]
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult VratiSveKorisnike()
        {
            List<KorisnikDTO> korisnici = Korisnici.VratiSve();
            List<AdminKorisnikModel> model = new List<AdminKorisnikModel>();

            foreach (KorisnikDTO user in korisnici)
            {
                model.Add(new AdminKorisnikModel()
                {
                    Id = user.Id,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    RoleID = user.RoleId,
                    RoleName = role[user.RoleId - 1],
                    StatusID = user.StatusId,
                    StatusName = status[user.StatusId - 1]
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PromenaPodataka(int korisnikId)
        {
            AdminKorisnikModel model = new AdminKorisnikModel();
            KorisnikDTO user = Korisnici.Procitaj(korisnikId);

            model.Id = user.Id;
            model.Username = user.Username;
            model.Ime = user.Ime;
            model.Prezime = user.Prezime;
            model.Email = user.Email;
            model.RoleID = user.RoleId;
            model.StatusID = user.StatusId;

            return View(model);
        }

        [HttpPost]
        public ActionResult PromenaPodataka(AdminKorisnikModel model)
        {
            KorisnikDTO user = Korisnici.Procitaj(model.Id);
             if (model.RoleID != 0)
             {
                user.RoleId = model.RoleID;
             }
             if (model.StatusID != 0)
             {
                user.StatusId = model.StatusID;
             }
             if (model.Password != "" && model.Password != null)
             {
                user.Password = model.Password;
             }
             Korisnici.Izmeni(user);

             return RedirectToAction("AdministracijaKorisnika");
        }
	}
}