using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Izvestaj
    {
        public virtual int Id { get; protected set; }
        public virtual string Opis { get; set; }
        public virtual DateTime RokPredaje { get; set; }
        public virtual DateTime VremePredaje { get; set; }

        public virtual PrakticniProjekat PrakticniProjekat { get; set; }



    }
}