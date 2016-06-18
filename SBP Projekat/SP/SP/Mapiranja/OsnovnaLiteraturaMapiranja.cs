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
    class OsnovnaLiteraturaMapiranja:ClassMap<OsnovnaLiteratura>
    {
        public OsnovnaLiteraturaMapiranja()
        {
            Table("OSNOVNA_LITERATURA");

            Id(x => x.Id, "OSNOVNA_LITERATURA_ID").GeneratedBy.TriggerIdentity();

            References(x => x.Literatura).Column("LITERATURA_ID").Cascade.All();
            References(x => x.TeorijskiProjekat).Cascade.All().Column("TEORIJSKI_PROJEKAT_ID");
    
        }
    }
}
