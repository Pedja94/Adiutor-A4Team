using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Predmet
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int GodinaStudija { get; set; }
        public virtual int Semestar { get; set; }

        public virtual string Opis { get; set; }

        public virtual Profesor ZaduzeniProfesor { get; set; } //Dodaj zaduzenog u bazi

        public virtual IList<Smer> PripadaSmerovima { get; set; }
     

        public Predmet()
        {
            PripadaSmerovima  = new List<Smer>();
        }
    }
}
