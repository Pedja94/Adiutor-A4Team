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
    public static class Odgovori
    {
        public static void Dodaj(OdgovorDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik user = new Korisnik()
                {
                    Id = c.KorisnikId
                };
                Pitanje pit = new Pitanje()
                {
                    Id = c.PitanjeId
                };
                Odgovor odg = new Odgovor()
                {
                    DatumVreme = c.DatumVreme,
                    Minus = c.Minus,
                    Plus = c.Plus,
                    Odobreno = c.Odobreno,
                    Tekst = c.Tekst,
                    ImaKorisnika = user,
                    PripadaPitanju = pit
                };

                s.SaveOrUpdate(odg);
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


                Odgovor st = s.Load<Odgovor>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public OdgovorDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odgovor p = s.Load<Odgovor>(id);

                OdgovorDTO odg = new OdgovorDTO()
                {
                    Id = p.Id,
                    DatumVreme = p.DatumVreme,
                    Minus = p.Minus,
                    Plus = p.Plus,
                    Odobreno = p.Odobreno,
                    Tekst = p.Tekst,
                    KorisnikId = p.ImaKorisnika.Id,
                    PitanjeId = p.PripadaPitanju.Id
                };

                s.Flush();
                s.Close();

                return odg;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(OdgovorDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik user = new Korisnik()
                {
                    Id = c.KorisnikId
                };
                Pitanje pit = new Pitanje()
                {
                    Id = c.PitanjeId
                };
                Odgovor odg = new Odgovor()
                {
                    DatumVreme = c.DatumVreme,
                    Minus = c.Minus,
                    Plus = c.Plus,
                    Odobreno = c.Odobreno,
                    Tekst = c.Tekst,
                    ImaKorisnika = user,
                    PripadaPitanju = pit
                };
                
                s.Update(odg);
                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<OdgovorDTO> VratiSve(int PitanjeId)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                List<Odgovor> Odgovori = (from k in s.Query<Odgovor>()
                                            where (k.PripadaPitanju.Id == PitanjeId)
                                            select k).ToList<Odgovor>();

                List<OdgovorDTO> retVal = new List<OdgovorDTO>();

                foreach (Odgovor odg in Odgovori)
                {
                    OdgovorDTO dto = new OdgovorDTO()
                    {
                        Id = odg.Id,
                        DatumVreme = odg.DatumVreme,
                        Minus = odg.Minus,
                        Plus = odg.Plus,
                        Odobreno = odg.Odobreno,
                        Tekst = odg.Tekst,
                        KorisnikId = odg.ImaKorisnika.Id,
                        PitanjeId = odg.PripadaPitanju.Id
                    };
                }

                return retVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static void DodajPlus(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OdgovorDTO o = Procitaj(id);
                o.Plus += 1;
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void DodajMinus(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OdgovorDTO o = Procitaj(id);
                o.Minus -= 1;
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void Odobri(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                OdgovorDTO o = Procitaj(id);
                o.Odobreno = 1;//proveri dal je 1
                Izmeni(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


    }
}
