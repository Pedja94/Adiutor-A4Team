using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class DodatnaLiteratura
    {
        public virtual int Id { get; protected set; }

        public virtual IList<Literatura> Literatura { get; set; }
        public virtual TeorijskiProjekat TeorijskiProjekat { get; set; }

        public DodatnaLiteratura ()
        {
            Literatura = new List<Literatura>();
        }
        
    }
}
