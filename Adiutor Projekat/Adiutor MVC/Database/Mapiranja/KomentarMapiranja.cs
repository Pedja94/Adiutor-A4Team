using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class KomentarMapiranja : ClassMap<Komentar>
    {
        public KomentarMapiranja()
        {
            Table("KOMENTAR");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Tekst).Column("TEKST");
            Map(x => x.DatumVreme).Column("DATUM_VREME");


            References(x => x.ImaKorisnika).Column("KORISNIK_ID").LazyLoad();
            References(x => x.NaOdgovor).Column("ODGOVOR_ID").LazyLoad();

        }
    }
}
