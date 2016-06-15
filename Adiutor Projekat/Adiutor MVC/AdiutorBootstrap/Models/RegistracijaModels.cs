using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdiutorBootstrap.Models
{
    public class RegistracijaModels
    {
            [Required]
            [Display(Name = "Ime")]
            public string Ime { get; set; }

            [Required]
            [Display(Name = "Prezime")]
            public string Prezime { get; set; }

            [Required]
            [Display(Name = "Broj indeksa")]
            public decimal? BrojIndeksa { get; set; }

            [Required]
            [Display(Name = "Korisničko ime")]
            public string Username { get; set; }
        
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Potvrdi lozinku")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "E-mail")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }
    }
}