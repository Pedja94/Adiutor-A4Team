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
    public static class Smerovi
    {
        public static void Dodaj(SmerDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer Smer = new Smer
                {
                    Ime = c.Ime,
                    PocSem = c.PocSem,
                    KrajSem = c.KrajSem
                };

                s.SaveOrUpdate(Smer);
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


                Smer st = s.Load<Smer>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public SmerDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer p = s.Load<Smer>(id);
                SmerDTO Smer = new SmerDTO
                {
                    Id = p.Id,
                    Ime = p.Ime,
                    PocSem = p.PocSem,
                    KrajSem = p.KrajSem
                };

                s.Flush();
                s.Close();

                return Smer;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public SmerDTO Nadji(string ime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer p = (from k in s.Query<Smer>()
                                    where (k.Ime == ime)
                                    select k).SingleOrDefault();

                SmerDTO smer = new SmerDTO
                {
                    Id = p.Id,
                    Ime = p.Ime,
                    PocSem = p.PocSem,
                    KrajSem = p.KrajSem
                };

                s.Flush();
                s.Close();

                return smer;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(SmerDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer Smer = new Smer
                {
                    Id = c.Id,
                    Ime = c.Ime,
                    PocSem = c.PocSem,
                    KrajSem = c.KrajSem
                };
                s.Update(Smer);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<SmerDTO> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<SmerDTO> retVal = new List<SmerDTO>();

                List<Smer> Smerovi = (from k in s.Query<Smer>()
                                    select k).ToList<Smer>();

                foreach (Smer Smer in Smerovi)
                {
                    SmerDTO dto = new SmerDTO()
                    {
                        Id = Smer.Id,
                        Ime = Smer.Ime,
                        PocSem = Smer.PocSem,
                        KrajSem = Smer.KrajSem
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

        static public List<SmerDTO> VratiSveSmerove(int PredmetId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<SmerDTO> retVal = new List<SmerDTO>();


                Predmet t = s.Load<Predmet>(PredmetId);
                IList<Smer> smerovi = t.PripadaSmerovima;

                foreach (Smer smer in smerovi)
                {
                    SmerDTO dto = new SmerDTO()
                    {
                        Id = smer.Id,
                        Ime = smer.Ime,
                        PocSem = smer.PocSem,
                        KrajSem = smer.KrajSem
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

        public static void DodajPredmetSmeru(int PredmetId, int SmerId) {

            Predmet_SmerDTO ps = new Predmet_SmerDTO
            {
                PredmetId = PredmetId,
                SmerId = SmerId
            };

            Predmet_Smerovi.Dodaj(ps);
        }

        public static void IzbrisiPredmetSaSmera(int PredmetId, int SmerId)
        {
            Predmet_SmerDTO ps  = Predmet_Smerovi.Nadji(PredmetId, SmerId);
            Predmet_Smerovi.Obrisi(ps.Id);
        }
    }
}
