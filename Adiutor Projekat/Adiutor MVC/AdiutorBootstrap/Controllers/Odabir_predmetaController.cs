﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return View();
            }
            else
            {
                return RedirectToAction("Pocetna", "Home");
            }
        }
	}
}