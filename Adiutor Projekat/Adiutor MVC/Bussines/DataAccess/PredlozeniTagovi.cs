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
    public static class PredlozeniTagovi
    {
        public static void Dodaj(Predlozeni_Tag c)
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


                Predlozeni_Tag st = s.Load<Predlozeni_Tag>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Predlozeni_Tag Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predlozeni_Tag p = s.Load<Predlozeni_Tag>(id);
                Predlozeni_Tag st = (Predlozeni_Tag)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Predlozeni_Tag c)
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

        static public List<Predlozeni_Tag> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predlozeni_Tag> Predlozeni_Tagi = (from k in s.Query<Predlozeni_Tag>()
                                            select k).ToList<Predlozeni_Tag>();
                return Predlozeni_Tagi;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
