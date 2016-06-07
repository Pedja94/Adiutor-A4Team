using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdiutorBootstrap.Models
{
    public class LogInModel
    {
        [Required]
        [Display(Name="Korisničko ime")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Lozinka")]
        public string password { get; set; }
    }
}