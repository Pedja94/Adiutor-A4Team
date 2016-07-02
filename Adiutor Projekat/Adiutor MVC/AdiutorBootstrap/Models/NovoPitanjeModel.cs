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

        public NovoPitanjeModel()
        {
            ImenaSvihOblasti = new List<string>();
        }


    }
}