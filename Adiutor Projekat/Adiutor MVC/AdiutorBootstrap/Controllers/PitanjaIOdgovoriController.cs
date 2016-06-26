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
            odgovor.Odobreno = 1;
            odgovor.DatumVreme = DateTime.Now;

            OdgovorModel odgovor1 = new OdgovorModel();
            odgovor1.Pozitivno = 115;
            odgovor1.Negativno = 23;
            odgovor1.Text = "Pokusaj sa CKE Editorom.";
            odgovor1.Odobreno = 1;
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

        public ActionResult KlikNaLink(int idOblasti)
        {
       
            OblastModel oblast = new OblastModel();

            OblastDTO obl = Business.DataAccess.Oblasti.Procitaj(idOblasti);
            oblast.Naziv = obl.Ime;
            oblast.Opis = obl.Opis;

            foreach (var liter in Literature.VratiSve(idOblasti))
            {
                LiteraturaModel l = new LiteraturaModel()
                {
                    Id = liter.Id,
                    Naziv = liter.Naziv,
                    Link = liter.Link
                };
                oblast.Literatura.Add(l);
            }

            foreach (var pit in Pitanja.VratiSvaPitanjaOblasti(idOblasti))
            {
                KorisnikDTO autorPitanja = Korisnici.Procitaj(pit.KorisnikId);
                PitanjeModel p = new PitanjeModel()
                {
                    Id = pit.Id,
                    DatumVreme = pit.DatumVreme,
                    Text = pit.Tekst,
                    AutorPitanja = autorPitanja.Ime,
                    AutorId=autorPitanja.Id,
                    NaslovPitanja=pit.Naslov,
                };
                oblast.Pitanja.ListaPitanja.Add(p);
            }

            return View("~/Views/Oblasti/Oblasti.cshtml", oblast);
  
        }

        public  ActionResult PitanjeIOdgovori1(int idPitanja)
        {
            PitanjaOdgovoriKomentariModel model = new PitanjaOdgovoriKomentariModel();
            PitanjeModel pitanje = new PitanjeModel();
      

            List<OdgovorDTO> odgovori = Odgovori.VratiSve(pitanje.Id);
            //u listi sada imamo sve odgovore, ostaje da njihove parametre prosledimo modelu
            int i = 0;
            OdgovoriModel odgovoriModel = new OdgovoriModel();
            foreach (var odg in odgovori)
            {
                odgovoriModel.ListaOdgovora[i].Text = odg.Tekst;
                odgovoriModel.ListaOdgovora[i].Pozitivno = odg.Plus;
                odgovoriModel.ListaOdgovora[i].Negativno = odg.Minus;
                odgovoriModel.ListaOdgovora[i].Id = odg.Id;

            }
            PitanjeDTO pit = Pitanja.Procitaj(idPitanja);


            //PitanjeDTO pit2 = Pitanja.Nadji(pit.Naslov);

            List<TagDTO> tagovi = Pitanja.VratiSveTagovePitanja(idPitanja);
            KorisnikDTO kor = Korisnici.Procitaj(pit.KorisnikId);
            OblastDTO obl=Oblasti.Procitaj(pit.OblastId);




            pitanje.Text = pit.Tekst;
            pitanje.AutorPitanja = kor.Ime;
            pitanje.DatumVreme = pit.DatumVreme;
            pitanje.Oblast = obl.Ime;
            pitanje.OblastId = pit.OblastId;
            pitanje.AutorId = kor.Id;
            pitanje.NaslovPitanja = pit.Naslov;
            pitanje.Id = pit.Id;


            foreach (var tag in tagovi)
            {
                TagModel tag1 = new TagModel()
                {
                    TagIme=tag.TagIme,
                    Ime=tag.Ime,
                    Opis=tag.Opis

                };
                pitanje.Tagovi.Add(tag1);
            }

            string slicniTagovi="";

            int prom=0;
            foreach(var tag in tagovi)
            {
                if (prom < 2)
                { 
                    slicniTagovi=slicniTagovi+"#"+tag.TagIme+" ";
                }
                prom++;
            }

            model.SlicnaPitanja = OblastiController.PitanjaPoTagovima(slicniTagovi);



            model.Pitanje = pitanje;

            foreach (var odg in Odgovori.VratiSve(pitanje.Id))
            {
                KorisnikDTO kor1 = Korisnici.Procitaj(odg.KorisnikId);
                OdgovorModel odg1 = new OdgovorModel
                {
                    Odobreno=odg.Odobreno,
                    DatumVreme=odg.DatumVreme,
                    Negativno=odg.Minus,
                    Pozitivno=odg.Plus,
                    Text=odg.Tekst,
                    AutorOdgovora=kor1.Ime,                    
                };
                model.Odgovori.Add(odg1);
            }


            var broj = pitanje.Tagovi.Count;
            foreach (var tag in pitanje.Tagovi)
            {

            }

         


            return View("~/Views/PitanjeIOdgovori/PitanjeIOdgovori.cshtml",model);
        }

        public PitanjeModel KreirajModelPitanja() 
        {
            return null;
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult PostaviOdgovor(int pitanjeId, string textarea)
        {
            OdgovorDTO odg = new OdgovorDTO();
            odg.DatumVreme = DateTime.Now;
            odg.KorisnikId = (int)Session["Id"];
            odg.Minus = 0;
            odg.Plus = 0;
            odg.Odobreno = 1;
            odg.Tekst = textarea;
            odg.PitanjeId = pitanjeId;
            Odgovori.Dodaj(odg);

            return PitanjeIOdgovori1(pitanjeId);

        }


	}
}