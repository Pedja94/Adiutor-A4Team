using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entiteti;
using FluentNHibernate.Mapping;



namespace Database.Mapiranja
{
    class KorisnikMaprianja : ClassMap<Korisnik>
    {
        public KorisnikMaprianja()
        {
            Table("KORISNIK");

            Id(x => x.Id).Column("ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Username).Column("USERNAME");
            Map(x => x.Password).Column("PASSWORD");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.BrojIndeksa).Column("BROJ_INDEKSA");
            Map(x => x.Slika).Column("SLIKA");
            Map(x => x.Smer).Column("SMER");
            Map(x => x.Opis).Column("OPIS");
            Map(x => x.GodinaStudija).Column("GODINA_STUDIJA");

            References(x => x.ImaRolu).Column("ROLE_ID").LazyLoad();
            References(x => x.ImaStatus).Column("STATUS_ID").LazyLoad();

            HasManyToMany(x => x.OcenjeniOdgovori).Table("KORISNIK_ODGOVOR").ParentKeyColumn("KORISNIK_ID")
                .ChildKeyColumn("ODGOVOR_ID")
                .Cascade.All();
        }
    }
}
