using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Pitanje
    {
        public virtual int Id { get; set; }
        public virtual string Tekst { get; set; }
        public virtual DateTime DatumVreme { get; set; }
        public virtual string Naslov { get; set; }
        public virtual Korisnik ImaKorisnika { get; set; }
        public virtual Oblast PripadaOblasti { get; set; }
        public virtual IList<Tag> ImaTagove { get; set; }

        public Pitanje()
        {
            ImaTagove = new List<Tag>();
        }
    }
}
