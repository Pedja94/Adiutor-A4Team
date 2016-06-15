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
    public class WebStraniceMapiranja:ClassMap<WebStranice>
    {
        public WebStraniceMapiranja()
        {
            Table("WEB_STRANICE");

            Id(x => x.Id, "WEB_STRANICA_ID").GeneratedBy.TriggerIdentity();

            Map(x => x.URL, "URL");

            References(x => x.PrakticniProjekat).Column("PROJEKAT_ID");
            
        }
        
    }
}
