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
    public static class Tagovi
    {
        public static void Dodaj(TagDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tag tag = new Tag
                {
                    Ime = c.Ime,
                    Opis = c.Opis,
                    TagIme = c.TagIme
                };

                s.SaveOrUpdate(tag);
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

        static public TagDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tag p = s.Load<Tag>(id);
                TagDTO tag = new TagDTO
                {
                    Id = p.Id,
                    TagIme = p.TagIme,
                    Ime = p.Ime,
                    Opis = p.Opis
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

        static public TagDTO Nadji(string tag_ime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tag p = (from k in s.Query<Tag>()
                           where (k.TagIme == tag_ime)
                           select k).SingleOrDefault();

                TagDTO tag = new TagDTO
                {
                    Id = p.Id,
                    TagIme = p.TagIme,
                    Ime = p.Ime,
                    Opis = p.Opis
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

        static public void Izmeni(TagDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tag tag = new Tag
                {
                    Id = c.Id,
                    Ime = c.Ime,
                    Opis = c.Opis,
                    TagIme = c.TagIme
                };
                s.Update(tag);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<TagDTO> VratiSve()
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<TagDTO> retVal = new List<TagDTO>();

                List<Tag> Tagovi = (from k in s.Query<Tag>()
                                            select k).ToList<Tag>();

                foreach (Tag tag in Tagovi)
                {
                    TagDTO dto = new TagDTO()
                    {
                        Id = tag.Id,
                        Ime = tag.Ime,
                        Opis = tag.Opis,
                        TagIme = tag.TagIme
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

        public static void DodajPredlozeniTag(Predlozeni_TagDTO pt)
        {
            TagDTO t = new TagDTO
            {
                Ime = pt.Ime,
                Opis = pt.Opis,
                TagIme = pt.TagIme
            };

            pt.DatumObrade = DateTime.Now;

            Tagovi.Dodaj(t);
            PredlozeniTagovi.Izmeni(pt);
        }
    }
}
