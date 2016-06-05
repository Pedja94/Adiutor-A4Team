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
    public static class Odgovori
    {
        public static void Dodaj(Odgovor c)
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


                Odgovor st = s.Load<Odgovor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Odgovor Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odgovor p = s.Load<Odgovor>(id);
                Odgovor st = (Odgovor)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Odgovor c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //s.Update(c);
                s.Persist(c);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<Odgovor> VratiSve(int PitanjeId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Odgovor> Odgovori = (from k in s.Query<Odgovor>()
                                            where (k.PripadaPitanju.Id == PitanjeId)
                                            select k).ToList<Odgovor>();
                return Odgovori;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void DodajPlus(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odgovor o = Procitaj(id);
                o.Plus += 1;
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void DodajMinus(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odgovor o = Procitaj(id);
                o.Minus -= 1;
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void Odobri(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Odgovor o = Procitaj(id);
                o.Odobreno = 1;//proveri dal je 1
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


    }
}
