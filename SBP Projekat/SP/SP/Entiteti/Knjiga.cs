using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Knjiga
    {
        public virtual int Id { get; protected set; }
        public virtual string ISBN { get; set; }
        public virtual string Izdavac { get; set; }

        public virtual Literatura Literatura { get; set; }

    }
}
