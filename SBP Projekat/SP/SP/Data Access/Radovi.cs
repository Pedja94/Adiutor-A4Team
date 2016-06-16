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
    public static class Radovi
    {
        public static Rad Find(ISession s, string name)
        {
            return (from k in s.Query<Rad>()
                    where (k.Literatura.Naslov == name)
                    select k).SingleOrDefault();
        }
    }
}
