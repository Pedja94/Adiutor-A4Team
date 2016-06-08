using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class OdabirPredmetaModel
    {
        public List<SmerModel> Smerovi;

        public List<PredmetModel> Predmeti;

        public OdabirPredmetaModel()
        {
            this.Smerovi = new List<SmerModel>();
            this.Predmeti = new List<PredmetModel>();
        }
    }

    public class SmerModel
    {
        int Id;
        string Ime;

        public SmerModel(int Id, string Ime)
        {
            this.Id = Id;
            this.Ime = Ime;
        }
    }

    public class PredmetModel
    {
        int Id;
        string Ime;

        public PredmetModel(int Id, string Ime)
        {
            this.Id = Id;
            this.Ime = Ime;
        }
    }
}