using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class Pitanje_TagMapiranja : ClassMap<Pitanje_Tag>
    {
        public Pitanje_TagMapiranja() {
            Table("PITANJE_TAG");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            References(x => x.Pitanje).Column("PITANJE_ID");
            References(x => x.Tag).Column("TAG_ID");
        }
    }
}
