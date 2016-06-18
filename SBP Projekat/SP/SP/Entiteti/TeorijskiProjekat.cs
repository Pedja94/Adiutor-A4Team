using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class TeorijskiProjekat:Projekat
    {
        
        public virtual int MaxBrojStrana { get; set;}

        public virtual IList<Literatura> dodatnaLiteratura { get; set; }

        public virtual IList<Literatura> osnovnaLiteratura { get; set; }
    }
}
