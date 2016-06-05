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

            HasMany(x => x.ImaPitanja).KeyColumn("PITANJE_ID");
            HasMany(x => x.ImaTagove).KeyColumn("TAG_ID");
        }
    }
}
