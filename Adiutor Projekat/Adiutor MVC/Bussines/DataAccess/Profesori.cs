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
    public static class Profesori
    {
        public static void Dodaj(ProfesorDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet pre = new Predmet()
                {
                    Id = c.PredmetId
                };
                Profesor pro = new Profesor()
                {
                    PunoIme = c.PunoIme,
                    PripadaPredmetu = pre
                };

                s.SaveOrUpdate(pro);
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


                Profesor st = s.Load<Profesor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public ProfesorDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Profesor p = s.Load<Profesor>(id);

                ProfesorDTO pro = new ProfesorDTO()
                {
                    Id = p.Id,
                    PunoIme = p.PunoIme,
                    PredmetId = p.PripadaPredmetu.Id
                };

                s.Flush();
                s.Close();

                return pro;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(ProfesorDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet pre = new Predmet()
                {
                    Id = c.PredmetId
                };
                Profesor pro = new Profesor()
                {
                    Id = c.Id,
                    PunoIme = c.PunoIme,
                    PripadaPredmetu = pre
                };

                s.Update(pro);

                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<ProfesorDTO> VratiSve(int predmetId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Profesor> Profesori = (from k in s.Query<Profesor>()
                                            where k.PripadaPredmetu.Id == predmetId
                                            select k).ToList<Profesor>();

                List<ProfesorDTO> retVal = new List<ProfesorDTO>();

                foreach (Profesor pro in Profesori)
                {
                    ProfesorDTO dto = new ProfesorDTO()
                    {
                        Id = pro.Id,
                        PunoIme = pro.PunoIme,
                        PredmetId = pro.PripadaPredmetu.Id
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
