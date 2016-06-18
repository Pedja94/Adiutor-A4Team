using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class OsnovnaLiteratura
    {
        public virtual int Id { get; protected set; }

        public virtual Literatura Literatura { get; set; }
        public virtual TeorijskiProjekat TeorijskiProjekat { get; set; }

    }
}
