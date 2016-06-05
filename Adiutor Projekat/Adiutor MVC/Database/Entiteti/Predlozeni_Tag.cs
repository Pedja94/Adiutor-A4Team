using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Predlozeni_Tag
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string TagIme { get; set; }
        public virtual string Opis { get; set; }
        public virtual DateTime DatumPostavljanja { get; set; }
        public virtual DateTime DatumObrade { get; set; }
    }
}
