using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Rad
    {
        public virtual int Id { get; set; }
        public virtual string MestoObjavljivanja { get; set; }
        public virtual string URL { get; set; }
        public virtual string FormatDokumenta { get; set; }

        public virtual Literatura Literatura { get; set; }

    }
}
