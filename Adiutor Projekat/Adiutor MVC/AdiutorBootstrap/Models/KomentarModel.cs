using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class KomentarModel
    {
        public int Id { get; set; }

        [Display(Name = "Tekst komentara")]
        public string Text { get; set; }

        [Display(Name = "Datum i vreme postavljanja komentara")]
        public DateTime DatumVreme { get; set; }

        public string ImeAutora { get; set; }

        public int AutorId { get; set; }

        public int PitanjeId { get; set; }

        public int OdgovorId { get; set; }

    }


  

}