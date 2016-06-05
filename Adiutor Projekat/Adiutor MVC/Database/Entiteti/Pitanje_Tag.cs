using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entiteti
{
    public class Pitanje_Tag
    {
        public virtual int Id { get; set; }

        public virtual IList<Tag> ImaTagove { get; set; }
        public virtual IList<Pitanje> ImaPitanja { get; set; }

        public Pitanje_Tag()
        {
            ImaTagove = new List<Tag>();
            ImaPitanja = new List<Pitanje>();
        }
    }
}
