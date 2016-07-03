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
	}
}