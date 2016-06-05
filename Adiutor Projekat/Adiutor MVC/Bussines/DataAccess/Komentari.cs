using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Database.Entiteti;
using Database;

namespace Business.DataAccess
{
    public static class Komentari
    {
        public static void Dodaj(Komentar c)
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


                Komentar st = s.Load<Komentar>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Komentar Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Komentar p = s.Load<Komentar>(id);
                Komentar st = (Komentar)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Komentar c)
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

        static public List<Komentar> VratiSve(int OdgovorId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                

                List<Komentar> komentari = (from k in s.Query<Komentar>()
                                                       where (k.NaOdgovor.Id == OdgovorId)
                                                       select k).ToList<Komentar>();
                return komentari;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }


}
