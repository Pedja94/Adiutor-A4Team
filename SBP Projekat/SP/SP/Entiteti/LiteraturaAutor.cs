using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class LiteraturaAutor
    {
        public virtual int Id { get; protected set; }


        public virtual IList<Literatura> Literatura { get; set; }
        public virtual IList<Autor> Autori { get; set; }


        public LiteraturaAutor()
        {
            Literatura = new List<Literatura>();
            Autori = new List<Autor>();
        }
    }
}
