using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdiutorBootstrap.Models
{
    public class AdminPredmetModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        public string Naziv { get; set; }

        public int GodinaStudija { get; set; }
        public int Semestar { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }
        public int smerId { get; set; }
        public string smerIme { get; set; }

        public List<SmerModel> listaSmerova;

        public AdminPredmetModel()
        {
            listaSmerova = new List<SmerModel>();
        }
    }

    public class ZaduzeniModel
    {
        public int predmetId { get; set; }
        public List<KorisnikModel> korisnici { get; set; }
    }
}