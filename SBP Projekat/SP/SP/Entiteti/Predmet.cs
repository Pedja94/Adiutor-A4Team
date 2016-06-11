using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Predmet
    {
        public virtual int Id { get; protected set; }
        public virtual string Sifra { get; set; }
        public virtual string Ime { get; set; }
        public virtual int  Semestar { get; set; }
        public virtual string Katedra { get; set; }

    }
}
