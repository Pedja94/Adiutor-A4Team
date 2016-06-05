using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Database.Entiteti;
using Database;
using Business.DTO;

namespace Business.DataAccess
{
    public static class Korisnici
    {
        public static void Dodaj(KorisnikDTO user)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Role role = new Role()
                {
                    Id = user.RoleId
                };
                Status status = new Status()
                {
                    Id = user.StatusId
                };

                Korisnik c = new Korisnik() 
                {
                    BrojIndeksa = user.BrojIndeksa,
                    Email = user.Email,
                    GodinaStudija = user.GodinaStudija,
                    Ime = user.Ime,
                    Opis = user.Opis,
                    Password = user.Password,
                    Prezime = user.Prezime,
                    Slika = user.Slika,
                    Smer = user.Smer,
                    Username = user.Username,
                    ImaRolu = role,
                    ImaStatus = status
                };

                s.SaveOrUpdate(c);
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


                Korisnik st = s.Load<Korisnik>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public KorisnikDTO Procitaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Korisnik st = s.Load<Korisnik>(id);
                KorisnikDTO user = new KorisnikDTO()
                {
                    Id = st.Id,
                    BrojIndeksa = st.BrojIndeksa,
                    Email = st.Email,
                    GodinaStudija = st.GodinaStudija,
                    Ime = st.Ime,
                    Opis = st.Opis,
                    Password = st.Password,
                    Prezime = st.Prezime,
                    Slika = st.Slika,
                    Smer = st.Smer,
                    Username = st.Username,
                    RoleId = st.ImaRolu.Id,
                    StatusId = st.ImaStatus.Id
                };

                s.Flush();
                s.Close();
                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public void Izmeni(KorisnikDTO user)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Role role = new Role()
                {
                    Id = user.RoleId
                };
                Status status = new Status()
                {
                    Id = user.StatusId
                };
                Korisnik c = new Korisnik()
                {
                    Id = user.Id,
                    BrojIndeksa = user.BrojIndeksa,
                    Email = user.Email,
                    GodinaStudija = user.GodinaStudija,
                    Ime = user.Ime,
                    Opis = user.Opis,
                    Password = user.Password,
                    Prezime = user.Prezime,
                    Slika = user.Slika,
                    Smer = user.Smer,
                    Username = user.Username,
                    ImaRolu = role,
                    ImaStatus = status
                };

                s.Update(c);

                s.Flush();
                s.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        static public KorisnikDTO Nadji(string username)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik st = (Korisnik)(from c in s.QueryOver<Korisnik>()
                             where (c.Username == username)
                             select c).SingleOrDefault();

                KorisnikDTO user = null;

                if (st != null)
                {
                    user = new KorisnikDTO();
                    user.Id = st.Id;
                    user.BrojIndeksa = st.BrojIndeksa;
                    user.Email = st.Email;
                    user.GodinaStudija = st.GodinaStudija;
                    user.Ime = st.Ime;
                    user.Opis = st.Opis;
                    user.Password = st.Password;
                    user.Prezime = st.Prezime;
                    user.Slika = st.Slika;
                    user.Smer = st.Smer;
                    user.Username = st.Username;
                    user.RoleId = st.ImaRolu.Id;
                    user.StatusId = st.ImaStatus.Id;
                }

                s.Flush();
                s.Close();
                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public KorisnikDTO Nadji(int BrojIndeksa)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Korisnik st = (Korisnik)(from c in s.QueryOver<Korisnik>()
                                        where (c.BrojIndeksa == BrojIndeksa)
                                        select c);

                KorisnikDTO user = null;

                if (st != null)
                {
                    user = new KorisnikDTO();
                    user.Id = st.Id;
                    user.BrojIndeksa = st.BrojIndeksa;
                    user.Email = st.Email;
                    user.GodinaStudija = st.GodinaStudija;
                    user.Ime = st.Ime;
                    user.Opis = st.Opis;
                    user.Password = st.Password;
                    user.Prezime = st.Prezime;
                    user.Slika = st.Slika;
                    user.Smer = st.Smer;
                    user.Username = st.Username;
                    user.RoleId = st.ImaRolu.Id;
                    user.StatusId = st.ImaStatus.Id;
                }

                s.Flush();
                s.Close();
                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        static public bool ProveriSifru(int id, string password)
        {
            return Procitaj(id).Password == password;
        }

        public static void PromeniStatus(KorisnikDTO k, int statusID)
        {
            k.StatusId = statusID;
            Korisnici.Izmeni(k);
        }

        public static void PromeniRolu(KorisnikDTO k, int roleID)
        {
            k.RoleId = roleID;
            Korisnici.Izmeni(k);
        }
    }
}
