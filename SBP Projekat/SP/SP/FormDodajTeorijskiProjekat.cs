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
        public List<string> imenaPredmeta;
        public List<int> IdPredmeta;

        public FormDodajTeorijskiProjekat()
        {
            InitializeComponent();
            ISession s = DataLayer.GetSession();
            List<Predmet> predmeti = Crud<Predmet>.ReturnAll(s);
            imenaPredmeta = new List<string>();
            IdPredmeta  = new List<int>();
            foreach (Predmet p in predmeti)
            {
                imenaPredmeta.Add(p.Ime);
                IdPredmeta.Add(p.Id);
            }
            s.Close();

            comboBox1.DataSource = imenaPredmeta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            int index = comboBox1.SelectedIndex;
            int id = IdPredmeta[index];

            Predmet predmet = Crud<Predmet>.Read(s, id);
            TeorijskiProjekat t = new TeorijskiProjekat
            {
                Ime = textBox2.Text,
                MaxBrojStrana = int.Parse(textBox1.Text),
                SkolskaGodina = textBox3.Text,
                PojedinacnoIliGrupno = textBox4.Text,
                Predmet = predmet
            };

            Crud<TeorijskiProjekat>.Create(s, t);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            s.Close();
       }
    }
}
