using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class TagModel
    {
        public string Ime { get; set; }

        public string Opis { get; set; }

        public string TagIme { get; set; }

        public int TagID { get; set; }

        //za predloznei tag koristicemo jos jedan property

        public DateTime DatumPostavljanja { get; set; }

    }
}