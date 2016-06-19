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



	}
}