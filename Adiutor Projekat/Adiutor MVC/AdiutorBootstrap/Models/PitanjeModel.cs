using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdiutorBootstrap.Models
{
    public class PitanjeModel
    {
        [Display(Name="Tekst pitanja")]
        public string Text { get; set; }

        [Display(Name="Datum i vreme postavljanja pitanja")]
        public DateTime DatumVreme { get; set; }

        
    }

    public class PitanjaSetModel
    {
        public List<PitanjeModel> ListaPitanja { get; set; }

        public PitanjaSetModel(params PitanjeModel[] VisePitanja)
        {
            ListaPitanja = new List<PitanjeModel>();

            foreach (var PitanjeModel in VisePitanja)
            {
                ListaPitanja.Add(PitanjeModel);
            }
        }
    }
}