using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public  class Student
    {
        public virtual int Id { get; protected set; }
        public virtual string Smer { get; set; }
        public virtual int BrojIndeksa { get; set; }
        public virtual string Ime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        
        public virtual IList<Tim> Timovi { get; set; }

        public Student()
        {
            Timovi = new List<Tim>();
        }
    }
}
