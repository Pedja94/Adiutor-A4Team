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
    public partial class FormDodajIzvestaj : Form
    { 
        ISession s = DataLayer.GetSession();
        public List<string> imenaProjekta;
        public List<int> IdProjekta;
        public FormDodajIzvestaj()
        {
            InitializeComponent();

            List<PrakticniProjekat> projekti = Crud<PrakticniProjekat>.ReturnAll(s);
            imenaProjekta = new List<string>();
            IdProjekta = new List<int>();
            foreach (PrakticniProjekat p in projekti)
            {
                imenaProjekta.Add(p.Ime);
                IdProjekta.Add(p.Id);
            }

            comboBox1.DataSource = imenaProjekta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izvestaj i = new Izvestaj
            {
                Opis = textBox9.Text,
                RokPredaje = DateTime.Parse(textBox8.Text),
                VremePredaje = DateTime.Parse(textBox7.Text)
            };

            int index = comboBox1.SelectedIndex;
            int id = IdProjekta[index];
            PrakticniProjekat pp = Crud<PrakticniProjekat>.Read(s, id);
            i.PrakticniProjekat = pp;

            Crud<Izvestaj>.Create(s, i);
        }
    }
}
