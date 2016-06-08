using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using AdiutorBootstrap.Models;
using Business.DataAccess;
using Business.DTO;

namespace AdiutorBootstrap.Controllers
{
    public class RegistracijaController : Controller
    {
        //
        // GET: /Registracija/
        public ActionResult Registracija()
        {
            RegistracijaModels model = new RegistracijaModels();
            return View(model);
        }

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    RegistracijaModels model = new RegistracijaModels();
        //    return View(model);
        //}

        
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistracijaModels model)
        {
            if (ModelState.IsValid)
            {
                KorisnikDTO user = new KorisnikDTO()
                 {
                     BrojIndeksa = model.BrojIndeksa,
                     Email = model.Email,
                     GodinaStudija = 1,
                     Ime = model.Ime,
                     Opis = null,
                     Password = model.Password,
                     Prezime = model.Prezime,
                     Slika = null,
                     Smer = null,
                     Username = model.Username,
                     RoleId = 1,
                     StatusId = 1
                 };
                Korisnici.Dodaj(user);
                ViewBag.Articles = "one";
                return View("Registracija");
            }
            else
            {
                return View("Registracija", model);
            }
              
        }


        public ActionResult Popup()
        {
            return Content("Ovo je neki popap");
        }
        


	}
}