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
    public static class Tagovi
    {
        public static void Dodaj(Tag c)
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


                Tag st = s.Load<Tag>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Tag Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tag p = s.Load<Tag>(id);
                Tag st = (Tag)s.GetSessionImplementation().PersistenceContext.Unproxy(p);


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

        static public void Izmeni(Tag c)
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

        static public List<Tag> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Tag> Tagovi = (from k in s.Query<Tag>()
                                            select k).ToList<Tag>();
                return Tagovi;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void DodajPredlozeniTag(Predlozeni_Tag pt)
        {
            Tag t = new Tag
            {
                Ime = pt.Ime,
                Opis = pt.Opis,
                TagIme = pt.TagIme
            };

            pt.DatumObrade = DateTime.Now;

            Dodaj(t);
            PredlozeniTagovi.Izmeni(pt);
        }
    }
}
