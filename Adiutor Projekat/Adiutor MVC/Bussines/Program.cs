using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DataAccess;
using Database;
using NHibernate;
using Database.Entiteti;

namespace Bussines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Role ro = new Role() 
                {
                    Id = 1
                };
                Status st = new Status() 
                {
                    Id = 1
                };
                Korisnik k = new Korisnik()
                {
                    BrojIndeksa = 14826,
                    Email = "a",
                    GodinaStudija = 2,
                    Ime = "a",
                    Prezime = "a",
                    Opis = "a",
                    Password = "a",
                    Slika = "a",
                    Smer = "a",
                    Username = "a",
                    ImaRolu = ro,
                    ImaStatus = st
                };



                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
