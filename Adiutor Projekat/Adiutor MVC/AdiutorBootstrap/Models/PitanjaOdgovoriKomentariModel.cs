using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class PitanjaOdgovoriKomentariModel
    {
        public PitanjeModel Pitanje { get; set; }

        public IList<OdgovorModel> Odgovori { get; set; }
        public IList<KomentarModel> Komentari { get; set; }

        public PitanjaOdgovoriKomentariModel()
        {
            Odgovori = new List<OdgovorModel>();
            Komentari = new List<KomentarModel>();
        }
    }
}