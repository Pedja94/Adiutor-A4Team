using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class Literatura
    {
        public virtual int Id { get; set; }
        public virtual string Naslov { get; set; }
        public virtual int GodinaIzdavanja { get; set; }

        //ostali imaju ka literaturi

        public virtual IList<Autor> Autori { get; set; }
        public virtual IList<DodatnaLiteratura> DodatnaLiteratura { get; set; }
        public virtual IList<OsnovnaLiteratura> OsnovnaLiteratura { get; set; }

        public Literatura()
        {
            Autori = new List<Autor>();
            DodatnaLiteratura = new List<DodatnaLiteratura>();
            OsnovnaLiteratura = new List<OsnovnaLiteratura>();
        }


    }
}
