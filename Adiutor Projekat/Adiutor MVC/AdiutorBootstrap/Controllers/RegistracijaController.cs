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
            model.BrojIndeksa = null;
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
                     BrojIndeksa = (decimal) model.BrojIndeksa,
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
                     StatusId = 2
                 };
                Korisnici.Dodaj(user);
                user = Korisnici.Nadji(model.Username);
                SendMail(user);
                ViewBag.Articles = "one";
                return View("Registracija");
            }
            else
            {
                return View("Registracija", model);
            }
              
        }

        public void SendMail(KorisnikDTO user)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                new System.Net.Mail.MailAddress("adiutorA4Team@outlook.com", "Web Registracija"),
                new System.Net.Mail.MailAddress(user.Email));
            m.Subject = "Potvrda e-mail adrese";
            m.Body = string.Format("Dear {0}<BR/>Hvala vam što ste se registrovali na naš sajt. Kliknite na link ispod da biste završili registaciju: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.Username, Url.Action("ConfirmEmail", "Registracija", new { Token = user.Id, Email = user.Email }, Request.Url.Scheme));
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp-mail.outlook.com");
            smtp.Credentials = new System.Net.NetworkCredential("adiutorA4Team@outlook.com", "9A4rules");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        [AllowAnonymous] 
        public ActionResult ConfirmEmail(string Token, string Email)
        {
            int id = Int32.Parse(Token);
            KorisnikDTO user = Korisnici.Procitaj(id);
            if (user != null)
            {
                Korisnici.PromeniStatus(user, 1);
            }

            return RedirectToAction("Pocetna", "Home");
        }

        public ActionResult Popup()
        {
            return Content("Ovo je neki popap");
        }
        


	}
}