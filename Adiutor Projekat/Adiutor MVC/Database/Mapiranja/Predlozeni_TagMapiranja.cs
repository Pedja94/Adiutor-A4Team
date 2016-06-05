using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class Predlozeni_TagMapiranja : ClassMap<Predlozeni_Tag>
    {
        public Predlozeni_TagMapiranja()
        {
            Table("PREDLOZENI_TAG");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime).Column("IME");
            Map(x => x.TagIme).Column("TAG_IME");
            Map(x => x.Opis).Column("OPIS");
            Map(x => x.DatumPostavljanja).Column("DATUM_POSTAVLJANJA");
            Map(x => x.DatumObrade).Column("DATUM_OBRADE");
        }
    }
}
