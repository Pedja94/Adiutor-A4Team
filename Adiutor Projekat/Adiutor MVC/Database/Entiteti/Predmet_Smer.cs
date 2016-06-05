using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Predmet_Smer
    {
        public virtual int Id { get; set; }

        public virtual IList<Smer> ImaSmerove { get; set; }
        public virtual IList<Predmet> ImaPredmete { get; set; }

        public Predmet_Smer()
        {
            ImaPredmete = new List<Predmet>();
            ImaSmerove = new List<Smer>();
        }
    }
}
