using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class LiteraturaMapiranja : ClassMap<Literatura>
    {
        public LiteraturaMapiranja()
        {
            Table("LITERATURA");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.Link).Column("LINK");


            References(x => x.PripadaOblasti).Column("OBLAST_ID").LazyLoad();

        }
    }
}
