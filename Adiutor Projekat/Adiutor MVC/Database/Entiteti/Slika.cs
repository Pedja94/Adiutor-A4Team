using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Slika
    {
        public virtual int Id { get; set; }
        public virtual string Link { get; set; }

        public virtual Odgovor PripadaOdgovoru { get; set; }
    }
}
