using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class PrakticniProjekat:Projekat
    {
        public virtual string Opis { get; set; }
        public virtual string ProgramskiJezik { get; set;  }
        public virtual int BrojIzvestaja { get; set; }

    }
}
