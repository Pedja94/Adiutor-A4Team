using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Database.Entiteti;
using Database;
using NHibernate.Linq;

namespace Business.DataAccess
{
    public static class Pitanja
    {
        public static void Dodaj(Pitanje c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.SaveOrUpdate(c);
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


                Pitanje st = s.Load<Pitanje>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Pitanje Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pitanje p = s.Load<Pitanje>(id);
                Pitanje st = (Pitanje)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


                s.Flush();
                s.Close();

                return st;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(Pitanje c)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(c);
                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<Pitanje> VratiSvaPitanjaOblasti(int OblastId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Pitanje> Pitanja = (from k in s.Query<Pitanje>()
                                            where (k.PripadaOblasti.Id == OblastId)
                                            select k).ToList<Pitanje>();
                return Pitanja;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        static public List<Pitanje> VratiSvaPitanjaKorisnika(int KorisnikId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Pitanje> Pitanja = (from k in s.Query<Pitanje>()
                                         where (k.ImaKorisnika.Id == KorisnikId)
                                         select k).ToList<Pitanje>();
                return Pitanja;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        static public List<Pitanje> VratiSvaPitanjaTaga(int TagId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Pitanje> Pitanja = (from k in s.Query<Pitanje>()
                                         where (k.PripadaOblasti.Id == TagId)
                                         select k).ToList<Pitanje>();
                return Pitanja;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
