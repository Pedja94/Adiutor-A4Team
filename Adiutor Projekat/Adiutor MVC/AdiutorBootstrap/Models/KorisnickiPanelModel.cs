﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class KorisnickiPanelModel
    {
        public KorisnikModel Korisnik { get; set; }

        public IList<PitanjeModel> Pitanja { get; set; }

        public IList<PredmetModel> ListaZaduzenihPredmeta { get; set; }


        public KorisnickiPanelModel()
        {
            Pitanja = new List<PitanjeModel>();
            Korisnik = new KorisnikModel();
            ListaZaduzenihPredmeta = new List<PredmetModel>();
        }
    }
}