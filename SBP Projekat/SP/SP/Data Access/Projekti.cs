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
    public static class Projekti
    {
        public static Projekat Find(ISession s, string name)
        {
            return (from k in s.Query<PrakticniProjekat>()
                    where (k.Ime == name)
                    select k).SingleOrDefault();
        }
    }
}
