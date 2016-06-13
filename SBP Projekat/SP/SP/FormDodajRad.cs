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
    public partial class FormDodajRad : Form
    {
        public FormDodajRad()
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

            Rad r = new Rad
            {
                MestoObjavljivanja = textBox4.Text,
                URL = textBox3.Text,
                FormatDokumenta = textBox5.Text,
                Literatura = l
            };

            ISession s = DataLayer.GetSession();
            Crud<Literatura>.Create(s, l);
            Crud<Rad>.Create(s, r);
            s.Close();
        }
    }
}
