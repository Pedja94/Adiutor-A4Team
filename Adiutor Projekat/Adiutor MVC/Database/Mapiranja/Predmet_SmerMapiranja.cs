using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class Predmet_SmerMapiranja : ClassMap<Predmet_Smer>
    {
        public Predmet_SmerMapiranja()
        {
            Table("PREDMET_SMER");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            //Proveriti
            References(x => x.Smer).Column("SMER_ID");
            References(x => x.Predmet).Column("PREDMET_ID");
        }
    }
}
