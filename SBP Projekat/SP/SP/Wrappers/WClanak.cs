using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Wrappers
{
    public class WClanak
    {
        public virtual int Id { get; set; }
        public virtual string ISSN { get; set; }
        public virtual int Broj_casopisa { get; set; }

        public virtual int LiteraturaId { get; set; }
        public virtual string Naslov { get; set; }
        public virtual int GodinaIzdavanja { get; set; }
    }
}
