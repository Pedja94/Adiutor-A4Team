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
    public class StudentMapiranja: ClassMap<Student>
    {
        public StudentMapiranja()
        {
            Table("STUDENT");

            Id(x => x.Id, "STUDENT_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.BrojIndeksa, "BROJ_INDEKSA");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Smer, "SMER");

            HasManyToMany(x => x.Timovi).Table("STUDENT_TIM").ParentKeyColumn("STUDENT_ID")
                .ChildKeyColumn("TIM_ID")
                .Inverse()
                .Cascade.All();
        }
    }
}
