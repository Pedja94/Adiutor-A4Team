using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class Korisnik_OdgovorMapiranja: ClassMap<Korisnik_Odgovor>
    {
        public Korisnik_OdgovorMapiranja()
        {
            Table("KORISNIK_ODGOVOR");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            References(x => x.Korisnik).Column("KORISNIK_ID");
            References(x => x.Odgovor).Column("ODGOVOR_ID");
        }
    }
}
