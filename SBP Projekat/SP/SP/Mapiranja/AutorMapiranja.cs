using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Studentski_projekti.Entiteti;
using FluentNHibernate;
using NHibernate;


namespace Studentski_projekti.Mapiranja
{
    class AutorMapiranja:ClassMap<Autor>
    {
        public AutorMapiranja()
        {
            Table("AUTOR");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "AUTOR_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");

            HasManyToMany(x => x.Literatura).Table("LITERATURA_AUTOR").ParentKeyColumn("AUTOR_ID")
                 .ChildKeyColumn("LITERATURA_ID").Cascade.All();


        }

    }
}
