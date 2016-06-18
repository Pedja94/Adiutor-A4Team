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
    public class TeorijskiProjekatMapiranja:SubclassMap<TeorijskiProjekat>
    {
        public TeorijskiProjekatMapiranja()
        {

            Table("TEORIJSKI_PROJEKAT");

            KeyColumn("PROJEKAT_ID");

            Map(x => x.MaxBrojStrana, "MAX_BROJ_STRANA");

            HasManyToMany(x => x.dodatnaLiteratura).Table("DODATNA_LITERATURA")
                .ParentKeyColumn("TEORIJSKI_PROJEKAT_ID")
                .ChildKeyColumn("LITERATURA_ID")
                .Cascade.SaveUpdate();

            HasManyToMany(x => x.osnovnaLiteratura).Table("OSNOVNA_LITERATURA")
                .ParentKeyColumn("TEORIJSKI_PROJEKAT_ID")
                .ChildKeyColumn("LITERATURA_ID")
                .Cascade.SaveUpdate();
        }

    }
}
