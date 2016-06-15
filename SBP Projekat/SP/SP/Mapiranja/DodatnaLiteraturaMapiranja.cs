using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Studentski_projekti.Entiteti;
using FluentNHibernate;
using NHibernate;

namespace Studentski_projekti.Mapiranja
{
    class DodatnaLiteraturaMapiranja:ClassMap<DodatnaLiteratura>
    {
        public DodatnaLiteraturaMapiranja ()
        {
            Table("DODATNA_LITERATURA");

            Id(x => x.Id, "DODATNA_LITERATURA_ID").GeneratedBy.TriggerIdentity();

            HasMany(x => x.Literatura).KeyColumn("LITERATURA_ID");
            References(x => x.TeorijskiProjekat).Column("TEORIJSKI_PROJEKAT_ID");

        }
    }
}
