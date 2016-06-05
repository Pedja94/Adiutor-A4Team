using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Role
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Opis { get; set; }

        //public virtual IList<Korisnik> ImaKorisnike { get; set; }

        //public Role()
        //{
        //    ImaKorisnike = new List<Korisnik>();
        //}
    }
}
