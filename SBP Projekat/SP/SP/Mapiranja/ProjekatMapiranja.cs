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
    public class ProjekatMapiranja : ClassMap<Projekat>
    {
        public ProjekatMapiranja()
        {

            Table("PROJEKAT");

            Id(x => x.Id, "PROJEKAT_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.SkolskaGodina, "SKOLSKA_GODINA");
            Map(x => x.PojedinacnoIliGrupno, "POJEDINACNO_ILI_GRUPA");

            References(x => x.Predmet).Column("PREDMET_ID");

            HasManyToMany(x => x.Timovi).Table("PROJEKAT_TIM").ParentKeyColumn("PROJEKAT_ID")
                .ChildKeyColumn("TIM_ID").Cascade.SaveUpdate();

        }
    }
}
