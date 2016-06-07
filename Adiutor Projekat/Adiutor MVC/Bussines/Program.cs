using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DataAccess;
using Database;
using NHibernate;
using Database.Entiteti;
using Business.DTO;
using Bussines.DataAccess;

namespace Bussines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ISession s = DataLayer.GetSession();
                //Role ro = new Role() 
                //{
                //    Id = 1
                //};
                //Status st = new Status() 
                //{
                //    Id = 1
                //};
                //Korisnik k = new Korisnik()
                //{
                //    BrojIndeksa = 14826,
                //    Email = "a",
                //    GodinaStudija = 2,
                //    Ime = "a",
                //    Prezime = "a",
                //    Opis = "a",
                //    Password = "a",
                //    Slika = "a",
                //    Smer = "a",
                //    Username = "a",
                //    ImaRolu = ro,
                //    ImaStatus = st
                //};






                //Pitanje_TagDTO pt = new Pitanje_TagDTO
                //{
                //    PitanjeId = 37,
                //    TagId = 38
                //};

                //Pitanje_TagDTO pt1 = new Pitanje_TagDTO
                //{
                //    PitanjeId = 37,
                //    TagId = 17
                //};

                //Pitanja_Tagovi.Dodaj(pt);
                //Pitanja_Tagovi.Dodaj(pt1);

                //List<PitanjeDTO> lista = Pitanja.VratiSvaPitanjaTaga(38);
                //List<TagDTO> tagovi = Pitanja.VratiSveTagovePitanja(37);
                //List<PredmetDTO> predmeti = Predmeti.VratiSvePredmete(57);

                //SmerDTO smer = new SmerDTO
                //{
                //    Ime = "EENN"
                //};

                //Smerovi.Dodaj(smer);
                //SmerDTO a = Smerovi.Procitaj(57);
                //a.Ime = "EEN";
                //Smerovi.Izmeni(a);
                //List<SmerDTO> smerovi = Smerovi.VratiSve();
                //Smerovi.DodajPredmetSmeru(23, 57);
                //Smerovi.IzbrisiPredmetSaSmera(21, 58);

                //Smerovi.Obrisi(57);

                SlikaDTO slika = new SlikaDTO
                {
                    Link = "link do slike"
                };

                
                //OdgovorDTO o = Odgovori.Procitaj(39);
                //slika.OdgovorId = o.Id;
                //Slike.Dodaj(slika);
                SlikaDTO s = Slike.Procitaj(43);
                s.Link = "novi link";
                Slike.Izmeni(s);
                //Slike.VratiSve(39);
                //Slike.Obrisi(42);
                //s.SaveOrUpdate(k);
                //s.Flush();
                //s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}