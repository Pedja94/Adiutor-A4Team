using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Studentski_projekti.Entiteti
{
    public class Tim
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; } 
        public virtual int BrojClanova { get; set; }

        public virtual IList<Projekat> Projekti { get; set; }
        public virtual IList<Student> Studenti { get; set; }

        public Tim ()
        {
            Projekti = new List<Projekat>();
            Studenti = new List<Student>();

        }
        
    }
}