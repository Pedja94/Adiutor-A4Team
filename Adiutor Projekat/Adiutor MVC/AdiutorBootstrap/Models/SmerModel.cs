using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class SmerModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        public int PocSem { get; set; }
        public int KrajSem { get; set; }

        public bool Error { get; set; }
    }
}