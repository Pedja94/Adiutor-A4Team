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
    public class TimMapiranja:ClassMap<Tim>
    {
        public TimMapiranja()
        {
            Table("TIM");

            Id(x => x.Id, "TIM_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.BrojClanova, "BROJ_CLANOVA");

            HasManyToMany(x => x.Projekti).Table("PROJEKAT_TIM").ParentKeyColumn("TIM_ID")
               .ChildKeyColumn("PROJEKAT_ID").Inverse().Cascade.All();

            HasManyToMany(x => x.Studenti).Table("STUDENT_TIM").ParentKeyColumn("TIM_ID")
               .ChildKeyColumn("STUDENT_ID")
               .Cascade
               .SaveUpdate();

        }

    }
}
