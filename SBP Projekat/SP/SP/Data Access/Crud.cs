using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studentski_projekti.Entiteti;
using NHibernate;
using NHibernate.Linq;
using System.Windows.Forms;

namespace SP.Data_Access
{
    public static class Crud<T>
    {
        public static void Create(ISession s, T Item)
        {
            try
            {
                s.SaveOrUpdate(Item);
                s.Flush();
                MessageBox.Show("Uspešno ste dodali podatke");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void Delete(ISession s, int Id)
        {
            try
            {
                T item = s.Load<T>(Id);

                s.Delete(item);
                s.Flush();
                MessageBox.Show("Uspešno ste obrisali podatke");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static public T Read(ISession s, int id)
        {
            try
            {
                T item = s.Load<T>(id);

                s.Flush();

                return item;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default(T);
            }

        }

        static public void Update(ISession s, T Item)
        {
            try
            {
                s.Update(Item);
                
                s.Flush();
                MessageBox.Show("Uspešno ste načinili izmene");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static List<T> ReturnAll(ISession s)
        {
            try
            {
                

                List<T> retVal = (from k in s.Query<T>()
                                        select k).ToList<T>();

                return retVal;
            }
            catch (Exception e)
            {
                
                return null;
            }
        }
    }
}
