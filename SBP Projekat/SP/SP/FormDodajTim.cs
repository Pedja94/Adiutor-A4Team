using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using SP.Data_Access;
using Studentski_projekti.Entiteti;

namespace SP
{
    public partial class FormDodajTim : Form
    {
        public FormDodajTim()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tim t = new Tim
            {
                Ime = textBox9.Text
            };

            t.BrojClanova = int.Parse(textBox10.Text);

            ISession s = DataLayer.GetSession();
            Crud<Tim>.Create(s, t);

            s.Close();
        }
    }
}
