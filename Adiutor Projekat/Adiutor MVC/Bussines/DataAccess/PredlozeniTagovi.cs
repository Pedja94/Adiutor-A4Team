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
using Business.DataAccess;

namespace Business.DataAccess
{
    public static class PredlozeniTagovi
    {
        public static void Dodaj(Predlozeni_TagDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predlozeni_Tag pt = new Predlozeni_Tag()
                {
                    DatumObrade = c.DatumObrade,
                    DatumPostavljanja = c.DatumPostavljanja,
                    Ime = c.Ime,
                    Opis = c.Opis,
                    TagIme = c.TagIme
                };

                s.SaveOrUpdate(pt);
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


                Predlozeni_Tag st = s.Load<Predlozeni_Tag>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public Predlozeni_TagDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predlozeni_Tag p = s.Load<Predlozeni_Tag>(id);

                Predlozeni_TagDTO pt = new Predlozeni_TagDTO()
                {
                    Id = p.Id,
                    DatumObrade = p.DatumObrade,
                    DatumPostavljanja = p.DatumPostavljanja,
                    Ime = p.Ime,
                    Opis = p.Opis,
                    TagIme = p.TagIme
                };

                s.Flush();
                s.Close();

                return pt;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(Predlozeni_TagDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predlozeni_Tag pt = new Predlozeni_Tag()
                {
                    Id = c.Id,
                    DatumObrade = c.DatumObrade,
                    DatumPostavljanja = c.DatumPostavljanja,
                    Ime = c.Ime,
                    Opis = c.Opis,
                    TagIme = c.TagIme
                };

                s.Update(pt);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public Predlozeni_TagDTO Nadji(string tag_ime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predlozeni_Tag p = (from k in s.Query<Predlozeni_Tag>()
                         where (k.TagIme == tag_ime)
                         select k).SingleOrDefault();

                Predlozeni_TagDTO tag = new Predlozeni_TagDTO
                {
                    Id = p.Id,
                    TagIme = p.TagIme,
                    Ime = p.Ime,
                    Opis = p.Opis,
                    DatumObrade = p.DatumObrade,
                    DatumPostavljanja = p.DatumPostavljanja
                };

                s.Flush();
                s.Close();

                return tag;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public List<Predlozeni_TagDTO> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predlozeni_Tag> Predlozeni_Tagi = (from k in s.Query<Predlozeni_Tag>()
                                            select k).ToList<Predlozeni_Tag>();

                List<Predlozeni_TagDTO> retVal = new List<Predlozeni_TagDTO>();

                foreach (Predlozeni_Tag p in Predlozeni_Tagi)
                {
                    Predlozeni_TagDTO dto = new Predlozeni_TagDTO()
                    {
                        Id = p.Id,
                        DatumObrade = p.DatumObrade,
                        DatumPostavljanja = p.DatumPostavljanja,
                        Ime = p.Ime,
                        Opis = p.Opis,
                        TagIme = p.TagIme
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

        static public List<Predlozeni_TagDTO> VratiSveNeObradjene()
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Predlozeni_Tag> Predlozeni_Tagi = (from k in s.Query<Predlozeni_Tag>()
                                                        where k.DatumObrade == null
                                                        select k).ToList<Predlozeni_Tag>();

                List<Predlozeni_TagDTO> retVal = new List<Predlozeni_TagDTO>();

                foreach (Predlozeni_Tag p in Predlozeni_Tagi)
                {
                    Predlozeni_TagDTO dto = new Predlozeni_TagDTO()
                    {
                        Id = p.Id,
                        DatumObrade = p.DatumObrade,
                        DatumPostavljanja = p.DatumPostavljanja,
                        Ime = p.Ime,
                        Opis = p.Opis,
                        TagIme = p.TagIme
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
