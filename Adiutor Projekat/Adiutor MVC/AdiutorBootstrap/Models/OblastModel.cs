using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class OblastModel
    {
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public PitanjaSetModel Pitanja { get; set; }

        public IList<LiteraturaModel> Literatura { get; set; }

        public int Id { get; set; }

        public OblastModel()
        {
            Literatura = new List<LiteraturaModel>();
            Pitanja = new PitanjaSetModel();
        }
    }
}