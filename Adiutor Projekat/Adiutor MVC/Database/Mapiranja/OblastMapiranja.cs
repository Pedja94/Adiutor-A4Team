using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class OblastMapiranja : ClassMap<Oblast>
    {
        public OblastMapiranja()
        {
            Table("OBLAST");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime).Column("IME");

            Map(x => x.Opis).Column("OPIS");

            References(x => x.PripadaPredmetu).Column("PREDMET_ID").LazyLoad();

        }
    }
}
