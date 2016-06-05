using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Komentar
    {
        public virtual int Id { get; set; }
        public virtual string Tekst { get; set; }
        public virtual DateTime DatumVreme { get; set; }

        public virtual Korisnik ImaKorisnika { get; set; }
        public virtual Odgovor NaOdgovor { get; set; }
    }
}
