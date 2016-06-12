using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP.Data_Access;
using Studentski_projekti.Entiteti;
using NHibernate;

namespace SP
{
    public partial class FormPredmet : Form
    {
        public FormPredmet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sem = Int32.Parse(textBox3.Text);

            Predmet p = new Predmet
            {
                Ime = textBox2.Text,
                Sifra = textBox1.Text,
                Semestar = sem,
                Katedra = textBox4.Text
            };

            ISession s = DataLayer.GetSession();
            Crud<Predmet>.Create(s, p);

            s.Close();
        }
    }
}
