using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class SlikaMapiranja : ClassMap<Slika>
    {
        public SlikaMapiranja()
        {
            Table("SLIKA");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Link).Column("LINK");

            References(x => x.PripadaOdgovoru).Column("ODGOVOR_ID").LazyLoad();

        }
    }
}
