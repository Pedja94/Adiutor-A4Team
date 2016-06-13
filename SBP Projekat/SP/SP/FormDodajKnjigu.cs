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
    public partial class FormDodajKnjigu : Form
    {
        public FormDodajKnjigu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Literatura l = new Literatura {
                Naslov = textBox1.Text,
                GodinaIzdavanja = int.Parse(textBox2.Text)
            };

            Knjiga k = new Knjiga
            {
                ISBN = textBox4.Text,
                Izdavac = textBox3.Text,
                Literatura = l
            };

            ISession s = DataLayer.GetSession();
            Crud<Literatura>.Create(s, l);
            Crud<Knjiga>.Create(s, k);
            s.Close();
        }
    }
}
