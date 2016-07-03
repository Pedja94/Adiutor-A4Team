using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Korisnik_Odgovor
    {
        public virtual int Id { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Odgovor Odgovor { get; set; }
    }
}
