using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Literatura
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Link { get; set; }

        public virtual Oblast PripadaOblasti { get; set; }
    }
}
