using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Studentski_projekti.Entiteti;
using FluentNHibernate;
using NHibernate;

namespace Studentski_projekti.Mapiranja
{
    class KnjigaMapiranja:ClassMap<Knjiga>
    {
        public KnjigaMapiranja()
        {
            Table("KNJIGA");

            Id(x => x.Id, "KNJIGA_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.ISBN, "ISBN");
            Map(x => x.Izdavac, "IZDAVAC");
            //za izvedenu ?


            References(x => x.Literatura).Column("LITERATURA_ID");
        

        }
    }
}
