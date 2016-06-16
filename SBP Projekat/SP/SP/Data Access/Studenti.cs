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
    public static class Studenti
    {
        public static Student Find(ISession s, string ime, string sime, string prezime)
        {
            return (from k in s.Query<Student>()
                    where (k.Ime == ime && k.ImeRoditelja == sime && k.Prezime == prezime)
                    select k).SingleOrDefault();
        }
    }
}
