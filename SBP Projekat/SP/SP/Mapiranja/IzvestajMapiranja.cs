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
    class IzvestajMapiranja:ClassMap<Izvestaj>
    {
        public IzvestajMapiranja ()
        {
            Table("IZVESTAJ");

            Id(x => x.Id, "IZVESTAJ_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Opis, "OPIS");
            Map(x => x.RokPredaje, "ROK_PREDAJE");
            Map(x => x.VremePredaje, "VREME_PREDAJE");

            References(x => x.PrakticniProjekat).Column("PROJEKAT_ID");
        }
    }
}
