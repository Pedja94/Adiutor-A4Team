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
    public partial class FormDodajTeorijskiProjekat : Form
    {
        public FormDodajTeorijskiProjekat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeorijskiProjekat t = new TeorijskiProjekat
            {
                Ime = textBox2.Text,
                MaxBrojStrana = int.Parse(textBox1.Text),
                SkolskaGodina = textBox3.Text,
                PojedinacnoIliGrupno = textBox4.Text
            };

            ISession s = DataLayer.GetSession();
            Crud<TeorijskiProjekat>.Create(s, t);

            s.Close();
       }
    }
}
