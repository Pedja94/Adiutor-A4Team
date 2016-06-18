using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

       
	}
}