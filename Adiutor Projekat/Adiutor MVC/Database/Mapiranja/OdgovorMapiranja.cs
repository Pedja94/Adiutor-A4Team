using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class OdgovorMapiranja : ClassMap<Odgovor>
    {
        public OdgovorMapiranja()
        {
            Table("ODGOVOR");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Tekst).Column("TEKST");
            Map(x => x.Plus).Column("POZITIVNO");
            Map(x => x.Minus).Column("NEGATIVNO");
            Map(x => x.Odobreno).Column("ODOBRENO");

            //
            //MINUS JE U BAZI SA PRVIM VELIKIM SLOVOM I OSTALIM MALIMA
            //
            Map(x => x.DatumVreme).Column("DATUM_VREME");

            References(x => x.ImaKorisnika).Column("KORISNIK_ID").LazyLoad();
            References(x => x.PripadaPitanju).Column("PITANJE_ID").LazyLoad();

        } 
    }
}
