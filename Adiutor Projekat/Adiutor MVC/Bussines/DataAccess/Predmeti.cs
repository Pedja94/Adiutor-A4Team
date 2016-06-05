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
    public static class Predmeti
    {

        static public void Obrisi(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Predmet st = s.Load<Predmet>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Dodaj(Predmet c)
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

        static public Predmet Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet p = s.Load<Predmet>(id);
                Predmet st = (Predmet)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Predmet c)
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

        static public List<Predmet> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predmet> Predmeti = (from k in s.Query<Predmet>()
                                            select k).ToList<Predmet>();
                return Predmeti;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public static void DodajZaduzenog(int Id, Profesor p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predmet pr = Procitaj(Id);
                pr.ZaduzeniProfesor = p;
                Izmeni(pr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void IzbrisiZaduzenog(int Id, Profesor p)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predmet pr = Procitaj(Id);
                pr.ZaduzeniProfesor = null;
                Izmeni(pr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public IList<Smer> VratiSveSmerove(int PredmetId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predmet p = s.Load<Predmet>(PredmetId);

                //List<Smer> smerovi = (from smer in s.Query<Smer>()
                //                            where (smer.ImaPredmete.Contains(p))
                //                            select smer).ToList<Smer>();

                return p.PripadaSmerovima;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        static public void DodajSmer(Predmet p, Smer smer)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                p.PripadaSmerovima.Add(smer);

                s.Update(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void ObrisiSmer(Predmet p, Smer smer)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                p.PripadaSmerovima.Remove(smer);

                s.Update(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


    }
}
