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
    public static class Literature
    {
        public static void Dodaj(Literatura c)
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


                Literatura st = s.Load<Literatura>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Literatura Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Literatura p = s.Load<Literatura>(id);
                Literatura st = (Literatura)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Literatura c)
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

        static public List<Literatura> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Literatura> Literature = (from k in s.Query<Literatura>()
                                            select k).ToList<Literatura>();
                return Literature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        static public List<Literatura> VratiSve(int OblastId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Literatura> Literature = (from k in s.Query<Literatura>()
                                                where (k.PripadaOblasti.Id == OblastId)
                                                select k).ToList<Literatura>();
                return Literature;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void DodajLiteraturuOblasti(int id, Literatura l)
        {
            Oblast o = Oblasti.Procitaj(id);
            l.PripadaOblasti = o;
            Izmeni(l);
        }

        public static void IzbrisiLiteraturuOblasti(int id, Literatura l)
        {
            Oblast o = Oblasti.Procitaj(id);
            l.PripadaOblasti = null;
            Izmeni(l);
        }
    }
}
