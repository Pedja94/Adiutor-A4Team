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
    public class ProfesorMapiranja: ClassMap<Profesor>
    {
        public ProfesorMapiranja()
        {
            Table("PROFESOR");

            Id(x => x.Id, "PROFESOR_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");

            HasMany(x => x.Predmeti).KeyColumn("PREDMET_ID").Cascade.All();

        }

    }
}
