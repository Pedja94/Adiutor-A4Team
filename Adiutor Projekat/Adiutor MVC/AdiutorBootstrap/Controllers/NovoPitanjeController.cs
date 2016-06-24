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

        public ActionResult NovoPitanje()
        {
            PitanjeModel novoPitanje = new PitanjeModel();
            




            return View();
        }

        [ValidateInput(false)]
        public ActionResult DodajPitanje(string naslovPitanja, string textarea, string tagovi)
        {
            PitanjeDTO pit=new PitanjeDTO();
            pit.KorisnikId=(int)Session["Id"];
            pit.Tekst=textarea;
            pit.Naslov=naslovPitanja;
            pit.OblastId=57;
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


	}
}