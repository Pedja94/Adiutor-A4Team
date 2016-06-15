using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Profesor
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }

        public virtual IList<Predmet> Predmeti { get; set;}

        public Profesor ()
        {
            Predmeti = new List<Predmet>();
        }
    }
}
