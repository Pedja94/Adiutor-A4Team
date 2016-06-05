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

        public virtual Tag Tag { get; set; }
        public virtual Pitanje Pitanje { get; set; }

    }
}
