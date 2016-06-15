using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class KorisnikModel
    {

       
        public string Ime { get; set; }


        [Display(Name = "Prezime:")]
        public string Prezime { get; set; }

        [Display(Name = "Br. indeksa:")]
        public decimal BrojIndeksa { get; set; }

        
        [Display(Name = "Korisničko ime:")]
        public string Username { get; set; }


        [Display(Name = "E-mail:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Smer:")]
        public string Smer { get; set; }

        [Display(Name = "Opis:")]
        public string Opis { get; set; }

        [Display(Name = "Godina:")]
        public string GodinaStudija { get; set; }

        


    }
}