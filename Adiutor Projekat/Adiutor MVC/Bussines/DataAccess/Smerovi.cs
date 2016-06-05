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
    public static class Smerovi
    {
        public static void Dodaj(Smer c)
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


                Smer st = s.Load<Smer>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Smer Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer p = s.Load<Smer>(id);
                Smer st = (Smer)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Smer c)
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

        static public List<Smer> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Smer> Smerovi = (from k in s.Query<Smer>()
                                            select k).ToList<Smer>();
                return Smerovi;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void DodajPredmetSmeru(int PredmetId, int SmerId) {
            Smer smer = Procitaj(SmerId);
            Predmet p = Predmeti.Procitaj(PredmetId);
            smer.ImaPredmete.Add(p);
            Izmeni(smer);
        }

        public static void IzbrisiPredmetSaSmera(int PredmetId, int SmerId)
        {
            Smer smer = Procitaj(SmerId);
            Predmet p = Predmeti.Procitaj(PredmetId);
            smer.ImaPredmete.Remove(p);
            Izmeni(smer);
        }
    }
}
