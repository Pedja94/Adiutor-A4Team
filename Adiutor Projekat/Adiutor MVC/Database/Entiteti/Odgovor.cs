using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Odgovor
    {
        public virtual int Id { get; set; }
        public virtual string Tekst { get; set; }
        public virtual int Plus { get; set; }
        public virtual int Minus { get; set; }
        public virtual int Odobreno { get; set; }
        public virtual DateTime DatumVreme { get; set; }

        public virtual Korisnik ImaKorisnika { get; set; }
        public virtual Pitanje PripadaPitanju { get; set; }


    }
}
