using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class StudentTim
    {
        public virtual int Id { get; protected set; }

        public virtual IList<Tim> Timovi { get; set; }
        public virtual IList<Student> Studenti { get; set; }

        public StudentTim()
        {
            Timovi = new List<Tim>();
            Studenti = new List<Student>();

        }

    }
}
