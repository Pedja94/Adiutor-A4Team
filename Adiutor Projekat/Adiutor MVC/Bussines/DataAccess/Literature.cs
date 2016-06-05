using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Database.Entiteti;
using Database;
using NHibernate.Linq;
using Business.DTO;

namespace Business.DataAccess
{
    public static class Literature
    {
        public static void Dodaj(LiteraturaDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oblast obl = new Oblast()
                {
                    Id = c.OblastId
                };
                Literatura lit = new Literatura()
                {
                    Link = c.Link,
                    Naziv = c.Naziv,
                    PripadaOblasti = obl
                };

                s.SaveOrUpdate(lit);
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

        static public LiteraturaDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Literatura p = s.Load<Literatura>(id);

                LiteraturaDTO lit = new LiteraturaDTO()
                {
                    Id = p.Id,
                    Link = p.Link,
                    Naziv = p.Naziv,
                    OblastId = p.PripadaOblasti.Id
                };

                s.Flush();
                s.Close();

                return lit;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(LiteraturaDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oblast obl = new Oblast()
                {
                    Id = c.OblastId
                };
                Literatura lit = new Literatura()
                {
                    Id = c.Id,
                    Link = c.Link,
                    Naziv = c.Naziv,
                    PripadaOblasti = obl
                };

                s.Update(lit);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        //static public List<Literatura> VratiSve()
        //{
        //    try
        //    {
        //        ISession s = DataLayer.GetSession();


        //        List<Literatura> Literature = (from k in s.Query<Literatura>()
        //                                    select k).ToList<Literatura>();
        //        return Literature;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}

        static public List<LiteraturaDTO> VratiSve(int OblastId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Literatura> Literature = (from k in s.Query<Literatura>()
                                                where (k.PripadaOblasti.Id == OblastId)
                                                select k).ToList<Literatura>();

                List<LiteraturaDTO> retVal = new List<LiteraturaDTO>();

                foreach (Literatura lit in Literature)
                {
                    LiteraturaDTO dto = new LiteraturaDTO()
                    {
                        Id = lit.Id,
                        Link = lit.Link,
                        Naziv = lit.Naziv,
                        OblastId = lit.PripadaOblasti.Id
                    };
                    retVal.Add(dto);
                }

                return retVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //public static void DodajLiteraturuOblasti(int id, Literatura l)
        //{
        //    Oblast o = Oblasti.Procitaj(id);
        //    l.PripadaOblasti = o;
        //    Izmeni(l);
        //}

        //public static void IzbrisiLiteraturuOblasti(int id, Literatura l)
        //{
        //    Oblast o = Oblasti.Procitaj(id);
        //    l.PripadaOblasti = null;
        //    Izmeni(l);
        //}
    }
}
