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
    public class StudentTimMapiranja: ClassMap<StudentTim>
    {
        public StudentTimMapiranja()
        {
            Table("STUDENT_TIM");

            Id(x => x.Id, "STUDENT_TIM_ID").GeneratedBy.TriggerIdentity();

            HasMany(x => x.Studenti).KeyColumn("STUDENT_ID");
            HasMany(x => x.Timovi).KeyColumn("TIM_ID");

        }
    }
}
