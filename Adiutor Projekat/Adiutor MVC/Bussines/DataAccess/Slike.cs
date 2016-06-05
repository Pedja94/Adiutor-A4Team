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
    public static class Slike
    {
        public static void Dodaj(Slika c)
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


                Slika st = s.Load<Slika>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Slika Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Slika p = s.Load<Slika>(id);
                Slika st = (Slika)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Slika c)
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

        static public List<Slika> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Slika> Slike = (from k in s.Query<Slika>()
                                            select k).ToList<Slika>();
                return Slike;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        static public List<Slika> VratiSve(int OdgovorId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Slika> Slike = (from k in s.Query<Slika>()
                                     where (k.PripadaOdgovoru.Id == OdgovorId)
                                     select k).ToList<Slika>();
                return Slike;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
