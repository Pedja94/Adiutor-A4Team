using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class PredmetModel
    {
        [Display(Name="Naziv predmeta")]
        public string NazivPredmeta { get; set; }

        [Display(Name = "Godina studija")]
        public decimal GodinaStudija { get; set; }

        [Display(Name="Semestar")]
        public decimal Semestar { get; set; }

        [Display(Name ="Zaduzeni profesor")]
        public string ZaduzeniProfesor { get; set; }

        [Display(Name = "Oblasti")]
        public IList<OblastModel> Oblasti { get; set; }

        public int Id { get; set; }

        public string OpisPredmeta { get; set; }

        public bool PregledaProfesor { get; set; }


        public PredmetModel()
        {
            Oblasti = new List<OblastModel>();
        }

    }
}