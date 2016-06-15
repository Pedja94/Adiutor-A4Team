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
    public partial class FormDodajClanak : Form
    {
        public FormDodajClanak()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Literatura l = new Literatura
            {
                Naslov = textBox1.Text,
                GodinaIzdavanja = int.Parse(textBox2.Text)
            };

            Clanak c = new Clanak
            {
                Broj_casopisa = int.Parse(textBox3.Text),
                ISSN = textBox4.Text,
                Literatura = l
            };

            ISession s = DataLayer.GetSession();
            Crud<Literatura>.Create(s, l);
            Crud<Clanak>.Create(s, c);
            s.Close();
        }
    }
}
