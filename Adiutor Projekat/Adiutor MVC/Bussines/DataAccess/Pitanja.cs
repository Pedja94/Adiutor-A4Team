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
    public static class Pitanja
    {
        public static void Dodaj(PitanjeDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oblast oblast = new Oblast
                {
                    Id = c.OblastId
                };

                Korisnik korisnik = new Korisnik
                {
                    Id = c.KorisnikId
                };

                Pitanje Pitanje = new Pitanje
                {
                    Tekst = c.Tekst,
                    Naslov = c.Naslov,
                    DatumVreme = c.DatumVreme,
                    PripadaOblasti = oblast,
                    ImaKorisnika = korisnik,
                };

                s.SaveOrUpdate(Pitanje);
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


                Pitanje st = s.Load<Pitanje>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public PitanjeDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pitanje p = s.Load<Pitanje>(id);

                PitanjeDTO Pitanje = new PitanjeDTO
                {
                    Id = p.Id,
                    Naslov = p.Naslov,
                    KorisnikId = p.ImaKorisnika.Id,
                    OblastId = p.PripadaOblasti.Id,
                    DatumVreme = p.DatumVreme,
                    Tekst = p.Tekst
                };

                s.Flush();
                s.Close();

                return Pitanje;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public PitanjeDTO Nadji(string naslov)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pitanje p = (from k in s.Query<Pitanje>()
                             where (k.Naslov == naslov)
                             select k).SingleOrDefault();

                PitanjeDTO pit = new PitanjeDTO
                {
                    Id = p.Id,
                    Naslov = p.Naslov,
                    Tekst = p.Tekst,
                    DatumVreme = p.DatumVreme,
                    KorisnikId = p.ImaKorisnika.Id,
                    OblastId = p.PripadaOblasti.Id,

                };

                s.Flush();
                s.Close();

                return pit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(PitanjeDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oblast oblast = new Oblast
                {
                    Id = c.OblastId
                };

                Korisnik korisnik = new Korisnik
                {
                    Id = c.KorisnikId
                };

                Pitanje Pitanje = new Pitanje
                {
                    Id = c.Id,
                    ImaKorisnika = korisnik,
                    PripadaOblasti = oblast,
                    DatumVreme = c.DatumVreme,
                    Tekst = c.Tekst,
                    Naslov = c.Naslov
                };

                s.Update(Pitanje);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<PitanjeDTO> VratiSvaPitanjaOblasti(int OblastId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Pitanje> Pitanja = (from k in s.Query<Pitanje>()
                                            where (k.PripadaOblasti.Id == OblastId)
                                            select k).ToList<Pitanje>();

                List<PitanjeDTO> retVal = new List<PitanjeDTO>();

                foreach (Pitanje pitanje in Pitanja)
                {
                    PitanjeDTO dto = new PitanjeDTO()
                    {
                        Id = pitanje.Id,
                        Tekst = pitanje.Tekst,
                        Naslov = pitanje.Naslov,
                        DatumVreme = pitanje.DatumVreme,
                        KorisnikId = pitanje.ImaKorisnika.Id,
                        OblastId = pitanje.PripadaOblasti.Id
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

        static public List<PitanjeDTO> VratiSvaPitanjaKorisnika(int KorisnikId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Pitanje> Pitanja = (from k in s.Query<Pitanje>()
                                         where (k.ImaKorisnika.Id == KorisnikId)
                                         select k).ToList<Pitanje>();

                List<PitanjeDTO> retVal = new List<PitanjeDTO>();

                foreach (Pitanje pitanje in Pitanja)
                {
                    PitanjeDTO dto = new PitanjeDTO()
                    {
                        Id = pitanje.Id,
                        Tekst = pitanje.Tekst,
                        Naslov = pitanje.Naslov,
                        DatumVreme = pitanje.DatumVreme,
                        KorisnikId = pitanje.ImaKorisnika.Id,
                        OblastId = pitanje.PripadaOblasti.Id
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

        static public List<PitanjeDTO> VratiSvaPitanjaTaga(int TagId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                //List<Pitanje_Tag> PitanjaTagovi = (from k in s.Query<Pitanje_Tag>()
                //                         where (k.Tag.Id == TagId)
                //                         select k).ToList<Pitanje_Tag>();

                //List<Pitanje> pitanja = new List<Pitanje>();
                //foreach(Pitanje_Tag pt in PitanjaTagovi)
                //{
                //    Pitanje pitanje = (from k in s.Query<Pitanje>() where (k.Id == pt.Pitanje.Id) select k).Single();
                //    pitanja.Add(pitanje);    
                //}

                List<PitanjeDTO> retVal = new List<PitanjeDTO>();

                
                Tag t = s.Load<Tag>(TagId);
                IList<Pitanje> pitanja = t.PripadaPitanjima;

                foreach (Pitanje pitanje in pitanja)
                {
                    PitanjeDTO dto = new PitanjeDTO()
                    {
                        Id = pitanje.Id,
                        Tekst = pitanje.Tekst,
                        Naslov = pitanje.Naslov,
                        DatumVreme = pitanje.DatumVreme,
                        KorisnikId = pitanje.ImaKorisnika.Id,
                        OblastId = pitanje.PripadaOblasti.Id
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

        static public List<PitanjeDTO> VratiSvaPitanjaTaga(string tag_ime)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<PitanjeDTO> retVal = new List<PitanjeDTO>();


                Tag t = (from k in s.Query<Tag>()
                         where (k.TagIme == tag_ime)
                         select k).SingleOrDefault();

                IList<Pitanje> pitanja = t.PripadaPitanjima;

                foreach (Pitanje pitanje in pitanja)
                {
                    PitanjeDTO dto = new PitanjeDTO()
                    {
                        Id = pitanje.Id,
                        Tekst = pitanje.Tekst,
                        Naslov = pitanje.Naslov,
                        DatumVreme = pitanje.DatumVreme,
                        KorisnikId = pitanje.ImaKorisnika.Id,
                        OblastId = pitanje.PripadaOblasti.Id
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

        static public List<TagDTO> VratiSveTagovePitanja(int PitanjeId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                List<TagDTO> retVal = new List<TagDTO>();


                Pitanje t = s.Load<Pitanje>(PitanjeId);
                IList<Tag> tagovi = t.ImaTagove;

                foreach (Tag tag in tagovi)
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
    }
}
