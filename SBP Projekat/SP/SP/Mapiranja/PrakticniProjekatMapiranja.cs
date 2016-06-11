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
    class PrakticniProjekatMapiranja:SubclassMap<PrakticniProjekat>
    {
		public PrakticniProjekatMapiranja()
        {
            Table("PRAKTICNI_PROJEKAT");

            KeyColumn("PROJEKAT_ID");

            Map(x => x.Opis, "OPIS");
            Map(x => x.ProgramskiJezik, "PROGRAMSKI_JEZIK");
            Map(x => x.BrojIzvestaja, "BROJ_IZVESTAJA");
        }
    }
}
