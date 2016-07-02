using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdiutorBootstrap.Models;
using Business.DataAccess;
using Business.DTO;


namespace AdiutorBootstrap.Controllers
{
    public class TagoviController : Controller
    {
        //
        // GET: /Tagovi/
        public ActionResult Index()
        {
            return View();
        }


        public static List<TagModel> TagoviPitanja(int idPitanja)
        {
            List<TagDTO> Tagovi = Pitanja.VratiSveTagovePitanja(idPitanja);
            List<TagModel> ModelTagova = new List<TagModel>();

            foreach (var tag in Tagovi)
            {
                TagModel tg = new TagModel()
                {
                    Ime=tag.Ime,
                    TagIme=tag.TagIme,
                    Opis=tag.Opis,
                    TagID=tag.Id,
                };
                ModelTagova.Add(tg);
            }

            return ModelTagova;

        }

        [HttpPost]
        public JsonResult PredloziTag(TagModel tag)
        {
            Predlozeni_TagDTO tg = new Predlozeni_TagDTO();
            tg.DatumPostavljanja = DateTime.Now;
            tg.Ime = tag.Ime;
            tg.TagIme = tag.TagIme;
            tg.Opis = tag.Opis;

            PredlozeniTagovi.Dodaj(tg);

            return Json(tag, JsonRequestBehavior.AllowGet);
        }
	}
}