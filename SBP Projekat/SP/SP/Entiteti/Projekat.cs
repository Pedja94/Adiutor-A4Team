using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Projekat
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string SkolskaGodina { get; set; }
        public virtual string PojedinacnoIliGrupno { get; set; }  //obrati paznju, mozda pravi problem

        public virtual Predmet Predmet { get; set; }    
        public virtual IList <Tim> Timovi { get; set; }

        public Projekat()
        {
            Timovi = new List<Tim>();

        }
    }
}
