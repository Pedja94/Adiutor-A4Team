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
    public static class Predmet_Smerovi
    {
        public static void Dodaj(Predmet_SmerDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet p = new Predmet()
                {
                    Id = c.PredmetId
                };


                Smer sm = new Smer()
                {
                    Id = c.SmerId
                };

                Predmet_Smer Predmet_Smer = new Predmet_Smer()
                {
                    Smer = sm,
                    Predmet = p
                };

                s.SaveOrUpdate(Predmet_Smer);
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


                Predmet_Smer st = s.Load<Predmet_Smer>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        static public Predmet_SmerDTO Nadji(int PredmetId, int SmerId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet_Smer ps = (from k in s.Query<Predmet_Smer>()
                                   where (k.Predmet.Id == PredmetId  && k.Smer.Id == SmerId)
                                   select k).Single();

                Predmet_SmerDTO psdto = new Predmet_SmerDTO
                {
                    Id = ps.Id,
                    PredmetId = ps.Predmet.Id,
                    SmerId = ps.Smer.Id
                };

                s.Flush();
                s.Close();

                return psdto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
