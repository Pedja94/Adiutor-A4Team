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
    class RadMapiranja : ClassMap<Rad>
    {
        public RadMapiranja()
        {
            Table("RAD");

            Id(x => x.Id, "RAD_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.MestoObjavljivanja, "MESTO_OBJAVLJIVANJA");
            Map(x => x.URL, "URL");
            Map(x => x.FormatDokumenta, "FORMAT_DOKUMENTA");

            References(x => x.Literatura).Column("LITERATURA_ID");
        }

    }
}
