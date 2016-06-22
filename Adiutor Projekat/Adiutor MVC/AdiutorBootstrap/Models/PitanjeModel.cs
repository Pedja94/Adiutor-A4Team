using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdiutorBootstrap.Models
{
    public class PitanjeModel
    {
        public int Id { get; set; }
        
        [Display(Name="Tekst pitanja")]
        public string Text { get; set; }

        [Display(Name="Datum i vreme postavljanja pitanja")]
        public DateTime DatumVreme { get; set; }

        [Display(Name = "Autor pitanja")]
        public string AutorPitanja { get; set; }

        [Display(Name = "Slika autora")]
        public string SlikaAutora { get; set; }

        public string Oblast { get; set; }
        public int OblastId { get; set; }

        public int AutorId { get; set; }

        public string NaslovPitanja { get; set; }

        public IList<TagModel> Tagovi { get; set; }

        public PitanjeModel()
        {
            Tagovi = new List<TagModel>();
        }
        
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