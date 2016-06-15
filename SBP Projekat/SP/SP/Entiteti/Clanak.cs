using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Clanak
    {
        public virtual int Id { get; set; }
        public virtual string ISSN { get; set; }
        public virtual int Broj_casopisa { get; set; }

        public virtual Literatura Literatura { get; set; }

    
    }
}
