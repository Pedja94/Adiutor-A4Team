using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class TeorijskiProjekat:Projekat
    {
        //public virtual int Id { get; protected set; } ovo cemo da prepravimo u tabeli
        public virtual int MaxBrojStrana { get; set;}

       // public virtual Projekat Projekat { get; set; }

    }
}
