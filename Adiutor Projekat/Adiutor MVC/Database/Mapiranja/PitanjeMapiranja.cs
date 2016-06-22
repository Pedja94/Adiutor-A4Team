using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class PitanjeMapiranja : ClassMap<Pitanje>
    {
        public PitanjeMapiranja()
        {
            Table("PITANJE");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Tekst).Column("TEKST");
            Map(x => x.DatumVreme).Column("DATUM_VREME");
            Map(x => x.Naslov).Column("NASLOV");

            References(x => x.ImaKorisnika).Column("KORISNIK_ID").LazyLoad();
            References(x => x.PripadaOblasti).Column("OBLAST_ID").LazyLoad();


            HasManyToMany(x => x.ImaTagove).Table("PITANJE_TAG").ParentKeyColumn("PITANJE_ID")
                .ChildKeyColumn("TAG_ID")
                .Cascade.All();

        }
    }
}
