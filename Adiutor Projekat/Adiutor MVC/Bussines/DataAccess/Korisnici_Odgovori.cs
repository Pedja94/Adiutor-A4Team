using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using NHibernate;
using Database.Entiteti;
using Database;
using NHibernate.Linq;
using Business.DataAccess;
using Business.DTO;

namespace Business.DataAccess
{
    public static class Korisnici_Odgovori
    {
        public static void Dodaj(Korisnik_OdgovorDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik k = new Korisnik()
                {
                    Id = c.KorisnikId
                };


                Odgovor o = new Odgovor()
                {
                    Id = c.OdgovorId
                };

                Korisnik_Odgovor Korisnik_Odgovor = new Korisnik_Odgovor()
                {
                    Korisnik = k,
                    Odgovor = o
                };

                s.SaveOrUpdate(Korisnik_Odgovor);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void Obrisi(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik_Odgovor st = s.Load<Korisnik_Odgovor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        static public Korisnik_OdgovorDTO Nadji(int KorisnikId, int OdgovorId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                KorisnikDTO korisnik = Korisnici.Procitaj(KorisnikId);
                OdgovorDTO odgovor = Odgovori.Procitaj(OdgovorId);

                Korisnik_Odgovor pt = (from k in s.Query<Korisnik_Odgovor>()
                                  where (k.Korisnik.Id == korisnik.Id && k.Odgovor.Id == odgovor.Id)
                                  select k).Single();

                Korisnik_OdgovorDTO ptdto = new Korisnik_OdgovorDTO
                {
                    Id = pt.Id,
                    KorisnikId = pt.Korisnik.Id,
                    OdgovorId = pt.Odgovor.Id
                };

                s.Flush();
                s.Close();

                return ptdto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
