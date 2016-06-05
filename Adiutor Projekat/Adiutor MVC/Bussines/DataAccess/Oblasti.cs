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
    public static class Oblasti
    {
        public static void Dodaj(OblastDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet pre = new Predmet()
                {
                    Id = c.PredmetId
                };
                Oblast obl = new Oblast()
                {
                    Ime = c.Ime,
                    PripadaPredmetu = pre
                };

                s.SaveOrUpdate(obl);
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


                Oblast st = s.Load<Oblast>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public OblastDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oblast p = s.Load<Oblast>(id);

                OblastDTO obl = new OblastDTO()
                {
                    Id = p.Id,
                    Ime = p.Ime,
                    PredmetId = p.PripadaPredmetu.Id
                };

                s.Flush();
                s.Close();

                return obl;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(OblastDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet pre = new Predmet()
                {
                    Id = c.PredmetId
                };
                Oblast obl = new Oblast()
                {
                    Id = c.Id,
                    Ime = c.Ime,
                    PripadaPredmetu = pre
                };

                s.Update(obl);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<OblastDTO> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<Oblast> Oblasti = (from k in s.Query<Oblast>()
                                            select k).ToList<Oblast>();

                List<OblastDTO> retVal = new List<OblastDTO>();

                foreach (Oblast obl in Oblasti)
                {
                    OblastDTO dto = new OblastDTO()
                    {
                        Id = obl.Id,
                        Ime = obl.Ime,
                        PredmetId = obl.PripadaPredmetu.Id
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
    }
}
