using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DataAccess;
using Business.DTO;

namespace AdiutorBootstrap.Controllers
{
    public class KorisnickiPanelController : Controller
    {
        //
        // GET: /KorisnickiPanel/
        public ActionResult KorisnickiPanel()
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

        public ActionResult KlikNaKorisnika(int korisnikId)
        {
            KorisnikDTO kor = Korisnici.Procitaj(korisnikId);

            return View();
        }
	}
}