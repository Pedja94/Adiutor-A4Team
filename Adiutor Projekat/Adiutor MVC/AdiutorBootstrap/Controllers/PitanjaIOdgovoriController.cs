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
        public ActionResult PitanjeIOdgovori()
        {
            PitanjaOdgovoriKomentariModel model = new PitanjaOdgovoriKomentariModel();
            PitanjeModel pitanje = new PitanjeModel();
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

            model.Odgovori.Add(odgovor);

            return View(model);
        }
	}
}