using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DTO;
using Business.DataAccess;

namespace AdiutorBootstrap.Controllers
{
    public class PitanjeIOdgovoriController : Controller
    {
        //
        // GET: /PitanjaIOdgovori/
        public ActionResult PitanjeIOdgovori(int idPitanja)
        {
            PitanjaOdgovoriKomentariModel model = new PitanjaOdgovoriKomentariModel();
            PitanjeModel pitanje = new PitanjeModel();


            List<OdgovorDTO> odgovori = Odgovori.VratiSve(pitanje.Id);
            //u listi sada imamo sve odgovore, ostaje da njihove parametre prosledimo modelu

            OdgovoriModel odgovoriModel = new OdgovoriModel();
            int i=0;
            foreach (var odg in odgovori)
            {
                odgovoriModel.ListaOdgovora[i].Text = odg.Tekst;
                odgovoriModel.ListaOdgovora[i].Pozitivno = odg.Plus;
                odgovoriModel.ListaOdgovora[i].Negativno = odg.Minus;
                odgovoriModel.ListaOdgovora[i].Id = odg.Id;
              
            }

            pitanje.Text = "Kako koristiti HTML editor na svom sajtu i koji je najbolji?";
            pitanje.AutorPitanja = "Miloš Mladenović";
            pitanje.DatumVreme = DateTime.Now;
            pitanje.Oblast = "Web programiranje";
          

            TagModel tag1 = new TagModel();
            tag1.Ime = "programiranje";
            TagModel tag2 = new TagModel();
            tag2.Ime = "web";
            TagModel tag3 = new TagModel();
            tag3.Ime = "javascript";
            pitanje.Tagovi.Add(tag1);
            pitanje.Tagovi.Add(tag2);
            pitanje.Tagovi.Add(tag3);
            
           
            model.Pitanje = pitanje;

            OdgovorModel odgovor = new OdgovorModel();
            odgovor.Pozitivno = 65;
            odgovor.Negativno = 31;
            odgovor.Text = "Pokusaj sa CKE Editorom.";
            odgovor.Odobreno = true;
            odgovor.DatumVreme = DateTime.Now;

            OdgovorModel odgovor1 = new OdgovorModel();
            odgovor1.Pozitivno = 115;
            odgovor1.Negativno = 23;
            odgovor1.Text = "Pokusaj sa CKE Editorom.";
            odgovor1.Odobreno = true;
            odgovor1.DatumVreme = DateTime.Now;

            var broj = pitanje.Tagovi.Count;
            foreach(var tag in pitanje.Tagovi)
            {
               
            }

            model.Odgovori.Add(odgovor);
            model.Odgovori.Add(odgovor1);

            return View(model);
        }

        public ActionResult Klik()
        {
            PitanjaOdgovoriKomentariModel model1 = (PitanjaOdgovoriKomentariModel)TempData["model"];
            return View("PitanjeIOdgovori",model1);
        }


        public PitanjaOdgovoriKomentariModel PitanjeIOdgovori1(int idPitanja)
        {
            PitanjaOdgovoriKomentariModel model = new PitanjaOdgovoriKomentariModel();
            PitanjeModel pitanje = new PitanjeModel();


            List<OdgovorDTO> odgovori = Odgovori.VratiSve(pitanje.Id);
            //u listi sada imamo sve odgovore, ostaje da njihove parametre prosledimo modelu

            OdgovoriModel odgovoriModel = new OdgovoriModel();
            int i = 0;
            foreach (var odg in odgovori)
            {
                odgovoriModel.ListaOdgovora[i].Text = odg.Tekst;
                odgovoriModel.ListaOdgovora[i].Pozitivno = odg.Plus;
                odgovoriModel.ListaOdgovora[i].Negativno = odg.Minus;
                odgovoriModel.ListaOdgovora[i].Id = odg.Id;

            }
            PitanjeDTO pit = Pitanja.Procitaj(idPitanja);
            KorisnikDTO kor = Korisnici.Procitaj(pit.KorisnikId);
            OblastDTO obl=Oblasti.Procitaj(pit.OblastId);

            pitanje.Text = pit.Tekst;
            pitanje.AutorPitanja = kor.Ime;
            pitanje.DatumVreme = pit.DatumVreme;
            pitanje.Oblast = obl.Ime;


            TagModel tag1 = new TagModel();
            tag1.Ime = "programiranje";
            TagModel tag2 = new TagModel();
            tag2.Ime = "web";
            TagModel tag3 = new TagModel();
            tag3.Ime = "javascript";
            pitanje.Tagovi.Add(tag1);
            pitanje.Tagovi.Add(tag2);
            pitanje.Tagovi.Add(tag3);


            model.Pitanje = pitanje;

            OdgovorModel odgovor = new OdgovorModel();
            odgovor.Pozitivno = 65;
            odgovor.Negativno = 31;
            odgovor.Text = "Pokusaj sa CKE Editorom.";
            odgovor.Odobreno = true;
            odgovor.DatumVreme = DateTime.Now;

            OdgovorModel odgovor1 = new OdgovorModel();
            odgovor1.Pozitivno = 115;
            odgovor1.Negativno = 23;
            odgovor1.Text = "Pokusaj sa CKE Editorom.";
            odgovor1.Odobreno = true;
            odgovor1.DatumVreme = DateTime.Now;

            var broj = pitanje.Tagovi.Count;
            foreach (var tag in pitanje.Tagovi)
            {

            }

            model.Odgovori.Add(odgovor);
            model.Odgovori.Add(odgovor1);

            return model;
        }

	}
}