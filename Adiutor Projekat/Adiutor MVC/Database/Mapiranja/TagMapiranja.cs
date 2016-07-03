using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class TagMapiranja : ClassMap<Tag>
    {
         public TagMapiranja()
        {
            Table("TAG");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime).Column("IME");
            Map(x => x.TagIme).Column("TAG_IME");
            Map(x => x.Opis).Column("OPIS");

            HasManyToMany(x => x.PripadaPitanjima).Table("PITANJE_TAG").ParentKeyColumn("TAG_ID")
                .ChildKeyColumn("PITANJE_ID");
        }
    }
}
