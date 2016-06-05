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

        public static void Dodaj(PredmetDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Profesor prof = new Profesor()
                {
                    Id = c.ProfesorId
                };
                Predmet pre = new Predmet()
                {
                    GodinaStudija = c.GodinaStudija,
                    Naziv = c.Naziv,
                    Semestar = c.Semestar,
                    ZaduzeniProfesor = prof
                };

                s.SaveOrUpdate(pre);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public PredmetDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet p = s.Load<Predmet>(id);

                PredmetDTO pre = new PredmetDTO()
                {
                    Id = p.Id,
                    GodinaStudija = p.GodinaStudija,
                    Naziv = p.Naziv,
                    Semestar = p.Semestar,
                    ProfesorId = p.ZaduzeniProfesor.Id
                };

                s.Flush();
                s.Close();

                return pre;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(PredmetDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Profesor prof = new Profesor()
                {
                    Id = c.ProfesorId
                };
                Predmet pre = new Predmet()
                {
                    Id = c.Id,
                    GodinaStudija = c.GodinaStudija,
                    Naziv = c.Naziv,
                    Semestar = c.Semestar,
                    ZaduzeniProfesor = prof
                };

                s.Update(pre);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<PredmetDTO> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predmet> Predmeti = (from k in s.Query<Predmet>()
                                            select k).ToList<Predmet>();

                List<PredmetDTO> retVal = new List<PredmetDTO>();

                foreach (Predmet p in Predmeti)
                {
                    PredmetDTO pre = new PredmetDTO()
                    {
                        Id = p.Id,
                        GodinaStudija = p.GodinaStudija,
                        Naziv = p.Naziv,
                        Semestar = p.Semestar,
                        ProfesorId = p.ZaduzeniProfesor.Id
                    };
                    retVal.Add(pre);
                }

                return retVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //static public List<PredmetDTO> VratiSve(int smerID)
        //{
        //    try
        //    {
        //        ISession s = DataLayer.GetSession();


        //        List<Predmet> Predmeti = (from k in s.Query<Predmet>()
        //                                  select k).ToList<Predmet>();

        //        List<PredmetDTO> retVal = new List<PredmetDTO>();

        //        foreach (Predmet p in Predmeti)
        //        {
        //            PredmetDTO pre = new PredmetDTO()
        //            {
        //                Id = p.Id,
        //                GodinaStudija = p.GodinaStudija,
        //                Naziv = p.Naziv,
        //                Semestar = p.Semestar,
        //                ProfesorId = p.ZaduzeniProfesor.Id
        //            };
        //            retVal.Add(pre);
        //        }

        //        return retVal;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}

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

    }
}
