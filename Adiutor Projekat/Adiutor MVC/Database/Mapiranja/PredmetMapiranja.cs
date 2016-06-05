using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;


namespace Database.Mapiranja
{
    class PredmetMapiranja : ClassMap<Predmet>
    {
        public PredmetMapiranja()
        {
            Table("PREDMET");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Naziv).Column("NAZIV");
            Map(x => x.GodinaStudija).Column("GODINA_STUDIJA");
            Map(x => x.Semestar).Column("SEMESTAR");

            References(x => x.ZaduzeniProfesor).Column("ZADUZEN_ID").LazyLoad();

            HasManyToMany(x => x.PripadaSmerovima).Table("PREDMET_SMER")
                 .ParentKeyColumn("PREDMET_ID")
                 .ChildKeyColumn("SMER_ID")
                 .Cascade.All();
                 //.Inverse();
        }
    }
}
