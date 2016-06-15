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
    class ClanakMapiranja:ClassMap<Clanak>
    {
        public ClanakMapiranja ()
        {
            Table("CLANAK");

            Id(x => x.Id, "CLANAK_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.ISSN, "ISSN");
            Map(x => x.Broj_casopisa, "BROJ_CASOPISA");
            //za izvedenu ?

            References(x => x.Literatura).Cascade.All().Column("LITERATURA_ID");
        }
    }
}
