using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Predmet_Smer
    {
        public virtual int Id { get; set; }

        public virtual Smer Smer { get; set; }
        public virtual Predmet Predmet { get; set; }

        //public Predmet_Smer()
        //{
        //    ImaPredmete = new List<Predmet>();
        //    ImaSmerove = new List<Smer>();
        //}
    }
}
