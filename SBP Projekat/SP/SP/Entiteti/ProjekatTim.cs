using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class ProjekatTim
    {
        public virtual int Id { get;  protected set; }
        public virtual DateTime RokPredaje { get; set; }
        public virtual DateTime DatumBiranja { get; set; }
        public virtual DateTime DatumPredaje { get; set;  } 

        public virtual IList<Projekat> Projekti { get; set; }
        public virtual IList<Tim> Timovi { get; set;}


        public ProjekatTim ()
        {

            Projekti = new List<Projekat>();
            Timovi = new List<Tim>();

        }

    }
}
