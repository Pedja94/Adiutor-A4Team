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
            NovoPitanjeModel novoPitanje = new NovoPitanjeModel();
            novoPitanje.ImenaSvihOblasti.Add("Grafovi");
            novoPitanje.ImenaSvihOblasti.Add("Nizovi");
            novoPitanje.ImenaSvihOblasti.Add("Stabla");

            return View(novoPitanje);
        }

        [ValidateInput(false)]
        public ActionResult DodajPitanje(string naslovPitanja, string textarea, string tagovi, string oblast,string imeOblasti)
        {
            PitanjeDTO pit=new PitanjeDTO();
            pit.KorisnikId=(int)Session["Id"];
            pit.Tekst=textarea;
            pit.Naslov=naslovPitanja;
            pit.OblastId = Oblasti.Nadji(imeOblasti).Id;
            pit.DatumVreme=DateTime.Now;

          
                
            Pitanja.Dodaj(pit);

            PitanjeDTO pitproc = Pitanja.Nadji(pit.Naslov);

            string primljeniTagovi = tagovi;
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

        [HttpPost]
        public JsonResult VratiOblastiPoPrvomSlovu(ListaOblastiModel prvoS)
        {
            // ovo dole cemo otkomentarisati kad proradi fucking baza
            //List<OblastDTO> OblastiTrazene = Oblasti.VratiSveKojePocinjuSa(prvoS.PrvoSlovo.ToString());
            //foreach( var obl in OblastiTrazene)
            //{
            //    prvoS.ListaOblasti.Add(obl.Ime);
            //}
            
            prvoS.ListaOblasti.Add("Grafovi");
            prvoS.ListaOblasti.Add("Grabulje");
            prvoS.ListaOblasti.Add("Grofovi");


            return Json(prvoS, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult VratiSveTagove(ListaOblastiModel prvoS)
        {
            //List<TagDTO> tagovi = Tagovi.VratiSve();
            //List<string> ImenaTagova = new List<string>();
            //foreach(var tag in tagovi)
            //{
            //    ImenaTagova.Add(tag.TagIme);
            //}
            List<string> ImenaTagova = new List<string>();
            ImenaTagova.Add("programiranje");
            ImenaTagova.Add("web");
            ImenaTagova.Add("mvc");
            ImenaTagova.Add("niz");

            return Json(ImenaTagova, JsonRequestBehavior.AllowGet);
        }
       

    }
}