using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Database.Entiteti;
using Database;
using Business.DTO;

namespace Business.DataAccess
{
    public static class Komentari
    {
        public static void Dodaj(KomentarDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik user = new Korisnik()
                {
                    Id = c.KorisnikId
                };
                Odgovor odg = new Odgovor() 
                {
                    Id = c.OdgovorId
                };
                Komentar coment = new Komentar() 
                {
                    Tekst = c.Tekst,
                    DatumVreme = c.DatumVreme,
                    ImaKorisnika = user,
                    NaOdgovor = odg
                };

                s.SaveOrUpdate(coment);
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


                Komentar st = s.Load<Komentar>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public KomentarDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Komentar p = s.Load<Komentar>(id);
                KomentarDTO st = new KomentarDTO() 
                {
                    Id = p.Id,
                    Tekst = p.Tekst,
                    DatumVreme = p.DatumVreme,
                    KorisnikId = p.ImaKorisnika.Id,
                    OdgovorId = p.NaOdgovor.Id
                };

                s.Flush();
                s.Close();

                return st;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(KomentarDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Korisnik user = new Korisnik()
                {
                    Id = c.KorisnikId
                };
                Odgovor odg = new Odgovor()
                {
                    Id = c.OdgovorId
                };
                Komentar coment = new Komentar()
                {
                    Id = c.Id,
                    Tekst = c.Tekst,
                    DatumVreme = c.DatumVreme,
                    ImaKorisnika = user,
                    NaOdgovor = odg
                };

                s.Update(coment);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public List<KomentarDTO> VratiSve(int OdgovorId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                

                List<Komentar> komentari = (from k in s.Query<Komentar>()
                                                       where (k.NaOdgovor.Id == OdgovorId)
                                                       select k).ToList<Komentar>();

                List<KomentarDTO> retVal = new List<KomentarDTO>();

                foreach (Komentar komentar in komentari)
                {
                    KomentarDTO dto = new KomentarDTO() 
                    {
                        Id = komentar.Id,
                        Tekst = komentar.Tekst,
                        DatumVreme = komentar.DatumVreme,
                        KorisnikId = komentar.ImaKorisnika.Id,
                        OdgovorId = komentar.NaOdgovor.Id
                    };
                    retVal.Add(dto);
                }

                return retVal;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }


}
