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
    static public class Statusi
    {
        public static void DodajStatus(string ime, string opis)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Status st = new Status
                {
                    Ime = ime,
                    Opis = opis
                };

                s.SaveOrUpdate(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void ObrisiStatus(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Status st = s.Load<Status>(id);

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
