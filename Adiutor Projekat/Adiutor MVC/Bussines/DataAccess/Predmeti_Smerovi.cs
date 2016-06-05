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
    public static class Predmet_Smerovi
    {
        public static void Dodaj(Predmet_Smer c)
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


                Predmet_Smer st = s.Load<Predmet_Smer>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Predmet_Smer Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet_Smer p = s.Load<Predmet_Smer>(id);
                Predmet_Smer st = (Predmet_Smer)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Predmet_Smer c)
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

        static public List<Predmet_Smer> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predmet_Smer> Predmet_Smerovi = (from k in s.Query<Predmet_Smer>()
                                            select k).ToList<Predmet_Smer>();
                return Predmet_Smerovi;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
