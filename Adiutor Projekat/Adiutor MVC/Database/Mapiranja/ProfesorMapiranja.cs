using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;

namespace Database.Mapiranja
{
    class ProfesorMapiranja : ClassMap<Profesor>
    {
        public ProfesorMapiranja()
        {
            Table("PROFESOR");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.PunoIme).Column("PUNO_IME");

            References(x => x.PripadaPredmetu).Column("PREDMET_ID").LazyLoad();

        }
    }
}
