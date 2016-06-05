using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Database.Entiteti;
using Database;

namespace Business.DataAccess
{
    public static class Roles
    {
        public static void DodajRolu(string ime, string opis)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Role r = new Role
                {
                    Ime = ime,
                    Opis = opis
                };

                s.SaveOrUpdate(r);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void ObrisiRolu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Role st = s.Load<Role>(id);

                s.Delete(st);
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
