using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.Wrappers
{
    public class WRad
    {
        public virtual int Id { get; set; }
        public virtual string MestoObjavljivanja { get; set; }
        public virtual string URL { get; set; }
        public virtual string FormatDokumenta { get; set; }
        public virtual int LiteraturaId { get; set; }
        public virtual string Naslov { get; set; }
        public virtual int GodinaIzdavanja { get; set; }
    }
}
