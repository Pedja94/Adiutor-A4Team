using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Wrappers
{
    public class WKnjiga
    {
        public virtual int Id { get; set; }
        public virtual string ISBN { get; set; }
        public virtual string Izdavac { get; set; }
        public virtual int LiteraturaId { get; set; }
        public virtual string Naslov { get; set; }
        public virtual int GodinaIzdavanja { get; set; }
    }
}
