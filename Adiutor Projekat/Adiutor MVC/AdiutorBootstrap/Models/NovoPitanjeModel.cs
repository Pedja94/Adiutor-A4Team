using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class NovoPitanjeModel
    {
        public string NazivOblasti { get; set;}

        public string IdOblasti { get; set; }

        public List<string> ImenaSvihOblasti { get; set; }


        public string NaslovPitanja { get; set; }

        public string TekstPitanja { get; set; }

        public string Tagovi { get; set; }

        public bool Greska { get; set; }
        public NovoPitanjeModel()
        {
            ImenaSvihOblasti = new List<string>();
        }


    }
}