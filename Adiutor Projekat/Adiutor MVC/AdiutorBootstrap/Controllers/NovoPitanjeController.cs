using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DataAccess;
using Business.DTO;
using AdiutorBootstrap.Models;
using AdiutorBootstrap.Controllers;

namespace AdiutorBootstrap.Controllers
{
    public class NovoPitanjeController : Controller
    {
        //
        // GET: /NovoPitanje/

        public ActionResult NovoPitanje(int idOblasti)
        {
            if (idOblasti != 0) 
            { 
                NovoPitanjeModel mdl = new NovoPitanjeModel();
                mdl.IdOblasti = idOblasti.ToString();
                return View(mdl);
            }
            else
            {
                return View();
            }    
        }

        public ActionResult NovoPitanje1(NovoPitanjeModel model)
        {
            return View("NovoPitanje",model);
        }

        [ValidateInput(false)]
        //public ActionResult DodajPitanje(string naslovPitanja, string textarea, string tagovi, string oblast,string imeOblasti)
        public ActionResult DodajPitanje(NovoPitanjeModel pitanje)
        {
            try
            { 
            PitanjeDTO pit=new PitanjeDTO();
            pit.KorisnikId=(int)Session["Id"];
            pit.Tekst=pitanje.TekstPitanja;
            pit.Naslov=pitanje.NaslovPitanja;
            if (pitanje.NazivOblasti != null)
            {
                pit.OblastId = Oblasti.Nadji(pitanje.NazivOblasti).Id;
            }
            else
            {
                pit.OblastId = int.Parse(pitanje.IdOblasti);
            }
            pit.DatumVreme=DateTime.Now;

          
                
           

            PitanjeDTO pitproc = Pitanja.Nadji(pit.Naslov);

            Pitanja.Dodaj(pit);
           
           
            string primljeniTagovi = pitanje.Tagovi;
            if(primljeniTagovi[0]=='#')
            {
                char[] separatingChar = { '#', ' ' };
                string[] nizTagova = primljeniTagovi.Split(separatingChar, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var tag in nizTagova)
                {
                    TagDTO tag1 = Tagovi.Nadji(tag);
                    //Pitanja_
                    Pitanje_TagDTO pitanjeTag = new Pitanje_TagDTO()
                    {
                        PitanjeId=pitproc.Id,
                        TagId=tag1.Id,
                    };
                    Pitanja_Tagovi.Dodaj(pitanjeTag);
                }


            }

            

            PitanjeIOdgovoriController cont = new PitanjeIOdgovoriController();

            return cont.PitanjeIOdgovori1(pitproc.Id);//ovo treba da se ipsravi
            }
            catch (Exception e)
            {
                pitanje.Greska = true;
                return NovoPitanje1(pitanje);
            }

        }

        [HttpPost]
        public JsonResult VratiOblastiPoPrvomSlovu(ListaOblastiModel prvoS)
        {
            List<OblastDTO> OblastiTrazene = Oblasti.VratiSveKojePocinjuSa(prvoS.PrvoSlovo.ToString());
            foreach( var obl in OblastiTrazene)
            {
                prvoS.ListaOblasti.Add(obl.Ime);
            }


            return Json(prvoS, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult VratiSveTagove(ListaOblastiModel prvoS)
        {
            List<TagDTO> tagovi = Tagovi.VratiSve();
            List<string> ImenaTagova = new List<string>();
            foreach (var tag in tagovi)
            {
                ImenaTagova.Add(tag.TagIme);
            }
            //List<string> ImenaTagova = new List<string>();
            //ImenaTagova.Add("programiranje");
            //ImenaTagova.Add("web");
            //ImenaTagova.Add("mvc");
            //ImenaTagova.Add("niz");

            return Json(ImenaTagova, JsonRequestBehavior.AllowGet);
        }
       

    }
}