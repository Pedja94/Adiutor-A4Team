using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Profesor
    {
        public virtual int Id { get; set; }
        public virtual string PunoIme { get; set; }

        public virtual Predmet PripadaPredmetu { get; set; }
    }
}
