using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class OdabirPredmetaModel
    {
        public List<SmerCont> listaSmerova { get; set; }

        public OdabirPredmetaModel()
        {
            listaSmerova = new List<SmerCont>();
        }
    }

    public class PredmetCont
    {
        public int Id { get; set; }
        public string Ime {get; set; }
    }

    public class SmerCont
    {
        public int Id { get; set;}
        public int PocSem { get; set;}
        public int KrajSem { get; set;}
        public string Ime { get; set;}
    }

    public class SmerSemestarModel
    {
        public int smerId { get; set; }
        public int semestar { get; set; }
    }
}