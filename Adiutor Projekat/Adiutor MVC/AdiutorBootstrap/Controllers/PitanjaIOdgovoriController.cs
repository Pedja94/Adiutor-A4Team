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
                odgovoriModel.ListaOdgovora[i].AutorId = odg.KorisnikId;

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
            pitanje.SlikaAutora = kor.Slika;


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
                    AutorId=kor1.Id,
                    Id=odg.Id,
                    Komentari=NapraviListuKomentara(odg.Id),
                };
                model.Odgovori.Add(odg1);
            }


            var broj = pitanje.Tagovi.Count;
            foreach (var tag in pitanje.Tagovi)
            {

            }

         


            return View("~/Views/PitanjeIOdgovori/PitanjeIOdgovori.cshtml",model);
        }

        public List<KomentarModel> NapraviListuKomentara(int odgovorId)
        {
            List<KomentarDTO> komentari1 = Komentari.VratiSve(odgovorId);
            List<KomentarModel> Komentaris = new List<KomentarModel>();

            foreach (var kom in komentari1)
            {
                KorisnikDTO kor = Korisnici.Procitaj(kom.KorisnikId);
                KomentarModel km = new KomentarModel 
                {
                    AutorId=kom.KorisnikId,
                    Id=kom.Id,
                    DatumVreme=kom.DatumVreme,
                    ImeAutora=kor.Ime,
                    OdgovorId=kom.OdgovorId,
                    Text=kom.Tekst,
                };
                Komentaris.Add(km);
            }

            return Komentaris;

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


        [HttpPost]
        public JsonResult DodajKomentar(string modelKomentara)
        {
            //KomentarDTO kom = new KomentarDTO();
            //kom.DatumVreme = DateTime.Now;
            //kom.KorisnikId = komentar.AutorId;
            //kom.OdgovorId = komentar.OdgovorId;
            //kom.Tekst = komentar.Text;

            //Komentari.Dodaj(kom);

            return Json(modelKomentara, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DodajKomentar1(KomentarModel modelKomentara)
        {
            KomentarDTO kom = new KomentarDTO();
            kom.DatumVreme = DateTime.Now;
            kom.KorisnikId = modelKomentara.AutorId;
            kom.OdgovorId = modelKomentara.OdgovorId;
            kom.Tekst = modelKomentara.Text;

            KorisnikDTO kor = Korisnici.Procitaj(kom.KorisnikId);
            modelKomentara.ImeAutora = kor.Ime;

            Komentari.Dodaj(kom);
            modelKomentara.DatumVreme = DateTime.Now;


            return Json(modelKomentara,JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult OceniPozitivno(OdgovorModel odgovor)
        {
            OdgovorDTO odg = Odgovori.Procitaj(odgovor.Id);
            odg.Plus++;

            Odgovori.Izmeni(odg);
            odgovor.Pozitivno++;

            return Json(odgovor, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult OceniNegativno(OdgovorModel odgovor)
        {
            OdgovorDTO odg = Odgovori.Procitaj(odgovor.Id);
            odg.Minus++;
            odgovor.Negativno++;

            Odgovori.Izmeni(odg);

            return Json(odgovor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult VratiSveKomentare(OdgovorModel odgovor)
        {
            OdgovorDTO odg = Odgovori.Procitaj(odgovor.Id);
            List<KomentarDTO> KomentariOdgovora = Komentari.VratiSve(odg.Id);
            if (KomentariOdgovora.Count > 3)
            {
                //ovde smo kad ima vise od tri komentara koji treba da budu prikazani ispod odgovora
                for (int i = 3; i < KomentariOdgovora.Count; i++)
                {
                    KorisnikDTO kor=Korisnici.Procitaj(KomentariOdgovora[i].KorisnikId);
                    KomentarModel kom = new KomentarModel()
                    {
                        ImeAutora=kor.Ime,
                        Text=KomentariOdgovora[i].Tekst,
                        DatumVreme=KomentariOdgovora[i].DatumVreme,
                        Id=KomentariOdgovora[i].Id,

                    };
                    odgovor.Komentari.Add(kom);
                }

                return Json(odgovor, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }
	}
}