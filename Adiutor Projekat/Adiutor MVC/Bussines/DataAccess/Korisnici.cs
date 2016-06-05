using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Database.Entiteti;
using Database;

namespace Business.DataAccess
{
    public static class Korisnici
    {
        public static void Dodaj(Korisnik c)
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


                Korisnik st = s.Load<Korisnik>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Korisnik Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik st = s.Load<Korisnik>(id);

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

        static public void Izmeni(Korisnik c)
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

        static public Korisnik Nadji(string username)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik k = (Korisnik)(from c in s.QueryOver<Korisnik>()
                             where (c.Username == username)
                             select c).SingleOrDefault();

                s.Flush();
                s.Close();
                return k;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public Korisnik Nadji(int BrojIndeksa)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik k = (Korisnik)(from c in s.QueryOver<Korisnik>()
                                        where (c.BrojIndeksa == BrojIndeksa)
                                        select c);

                s.Flush();
                s.Close();
                return k;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public bool ProveriSifru(int id, string password)
        {
            return Procitaj(id).Password == password;
        }

        public static void PromeniStatus(Korisnik k, Status s)
        {
            k.ImaStatus = s;
            Izmeni(k);
        }

        public static void PromeniRolu(Korisnik k, Role r)
        {
            k.ImaRolu = r;
            Izmeni(k);
        }
    }
}
