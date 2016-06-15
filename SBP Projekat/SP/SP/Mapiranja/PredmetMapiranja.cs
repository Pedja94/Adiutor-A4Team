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
    class PredmetMapiranja:ClassMap<Predmet>
    {
        PredmetMapiranja()
        {
            Table("PREDMET");

            Id(x => x.Id, "PREDMET_ID").GeneratedBy.TriggerIdentity();


            Map(x => x.Ime, "IME");
            Map(x => x.Katedra, "KATEDRA");
            Map(x => x.Semestar, "SEMESTAR");
            Map(x => x.Sifra, "SIFRA");
            

        }
    }
}
