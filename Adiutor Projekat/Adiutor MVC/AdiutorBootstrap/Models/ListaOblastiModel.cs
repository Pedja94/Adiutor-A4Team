using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class ListaOblastiModel
    {
        public List<string> ListaOblasti { get; set; }

        public char PrvoSlovo { get; set; }

        public ListaOblastiModel()
        {
            ListaOblasti = new List<string>();
        }
    }
}