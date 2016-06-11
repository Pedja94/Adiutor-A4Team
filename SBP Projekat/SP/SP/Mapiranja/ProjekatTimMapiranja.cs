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
    public class ProjekatTimMapiranja:ClassMap<ProjekatTim>
    {
        public ProjekatTimMapiranja()
        {
            Table("PROJEKAT_TIM");

            Id(x => x.Id, "PROJEKAT_TIM_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.RokPredaje).Column("ROK_PREDAJE");
            Map(x => x.DatumPredaje).Column("DATUM_PREDAJE");
            Map(x => x.DatumBiranja).Column("DATUM_BIRANJA");

            HasMany(x => x.Projekti).KeyColumn("PROJEKAT_ID").Cascade.All();
            HasMany(x => x.Timovi).KeyColumn("TIM_ID").Cascade.All();
            
        }


    }
}
