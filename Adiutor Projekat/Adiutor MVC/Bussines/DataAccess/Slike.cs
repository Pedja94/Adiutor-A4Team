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
    public static class Slike
    {
        public static void Dodaj(SlikaDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odgovor odg = new Odgovor
                {
                    Id = c.Id
                };

                Slika Slika = new Slika
                {
                    Link = c.Link,
                    PripadaOdgovoru = odg
                };

                s.SaveOrUpdate(Slika);
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


                Slika st = s.Load<Slika>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public SlikaDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Slika p = s.Load<Slika>(id);
                SlikaDTO Slika = new SlikaDTO
                {
                    Id = p.Id,
                    Link = p.Link
                };

                s.Flush();
                s.Close();

                return Slika;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(SlikaDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Slika Slika = new Slika
                {
                    Id = c.Id,
                    Link = c.Link
                };

                s.Update(Slika);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<SlikaDTO> VratiSve(int OdgovorId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Slika> Slike = (from k in s.Query<Slika>()
                                     where (k.PripadaOdgovoru.Id == OdgovorId)
                                     select k).ToList<Slika>();

                List<SlikaDTO> retVal = new List<SlikaDTO>();

                foreach (Slika slika in Slike)
                {
                    SlikaDTO dto = new SlikaDTO()
                    {
                        Id = slika.Id,
                        Link = slika.Link
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
