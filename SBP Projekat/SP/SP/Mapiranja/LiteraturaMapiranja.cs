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
    class LiteraturaMapiranja:ClassMap<Literatura>
    {
        public LiteraturaMapiranja ()
        {
            Table("LITERATURA");

            Id(x => x.Id, "LITERATURA_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naslov, "NASLOV");
            Map(x => x.GodinaIzdavanja, "GODINA_IZDAVANJA");

            HasManyToMany(x => x.Autori).Table("LITERATURA_AUTOR").ParentKeyColumn("LITERATURA_ID")
                .ChildKeyColumn("AUTOR_ID").Cascade.All();


        }
    }
}
