using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class KomentarModel
    {
        [Display(Name = "Tekst komentara")]
        public string Text { get; set; }

        [Display(Name = "Datum i vreme postavljanja komentara")]
        public DateTime DatumVreme { get; set; }

    }


    public class Komentari
    {
        public List<KomentarModel> ListaKomentara { get; set; }

        public Komentari(params KomentarModel[] ViseKomentara)
        {
            ListaKomentara  = new List<KomentarModel>();

            foreach (var KomentarModel in ViseKomentara)
            {
                ListaKomentara.Add(KomentarModel);
            }
        }
        

    }
}