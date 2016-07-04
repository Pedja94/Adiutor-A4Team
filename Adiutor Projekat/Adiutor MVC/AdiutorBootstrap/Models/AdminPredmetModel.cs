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
        public string predmetIme { get; set; }
        public List<KorisnikModel> korisnici { get; set; }

        public ZaduzeniModel()
        {
            korisnici = new List<KorisnikModel>();
        }
    }

    public class AdminKorisnikModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }

        [Required]
        [Display(Name = "Sifra")]
        public string Password { get; set; }

        public string Email { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class AdminTagModel
    {
        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }

        [Required]
        [Display(Name = "Tag ime")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Razmaci nisu dozvoljeni")]
        public string TagIme { get; set; }

        public int TagID { get; set; }

        public DateTime DatumPostavljanja { get; set; }
    }

    public class AdminSviTagoviModel
    {
        public List<AdminTagModel> listaTagova;
        public List<AdminTagModel> listaPredlozenihTagova;

        public AdminSviTagoviModel()
        {
            listaTagova = new List<AdminTagModel>();
            listaPredlozenihTagova = new List<AdminTagModel>();
        }

    }
}