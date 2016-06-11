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
    class LiteraturaAutorMapiranja:ClassMap<LiteraturaAutor>
    {
        public LiteraturaAutorMapiranja ()
        {
            Table("LITERATURA");

            Id(x => x.Id, "LITERATURA_ID").GeneratedBy.TriggerIdentity();

            HasMany(x => x.Autori).KeyColumn("AUTOR_ID");
            HasMany(x => x.Literatura).KeyColumn("LITERATURA_ID");

        }
    }
}
