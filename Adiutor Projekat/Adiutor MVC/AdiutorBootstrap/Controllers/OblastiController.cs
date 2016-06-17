using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


	}
}