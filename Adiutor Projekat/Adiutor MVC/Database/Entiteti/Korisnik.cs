using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Korisnik
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual decimal BrojIndeksa { get; set; }
        public virtual string Slika { get; set; }
        public virtual string Smer { get; set; }
        public virtual string Opis { get; set; }
        public virtual decimal GodinaStudija { get; set; }

        public virtual Role ImaRolu { get; set; }
        public virtual Status ImaStatus { get; set; }
        public virtual IList<Odgovor> OcenjeniOdgovori { get; set; }

        public Korisnik()
        {
            OcenjeniOdgovori = new List<Odgovor>();
        }
    }
}
