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

            HasMany(x => x.ImaSmerove).KeyColumn("SMER_ID");
            HasMany(x => x.ImaPredmete).KeyColumn("PREDMET_ID");
        }
    }
}
