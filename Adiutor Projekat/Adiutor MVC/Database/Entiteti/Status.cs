using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Status
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Opis { get; set; }

        public virtual IList<Korisnik> ImaKorisnike { get; set; }

        public Status()
        {
            ImaKorisnike = new List<Korisnik>();
        }
    }
}
