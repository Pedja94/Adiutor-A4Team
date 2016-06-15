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
            ISession s = DataLayer.GetSession();
            IList<Autor> listaAutora = new List<Autor>();

            if (textBox6.Text != "")
            {
                Autor a = new Autor() 
                {
                    Ime = textBox6.Text
                };
                listaAutora.Add(a);
                Crud<Autor>.Create(s, a);
            }

            if (textBox7.Text != "")
            {
                Autor a = new Autor()
                {
                    Ime = textBox7.Text
                };
                listaAutora.Add(a);
                Crud<Autor>.Create(s, a);
            }

            if (textBox8.Text != "")
            {
                Autor a = new Autor()
                {
                    Ime = textBox8.Text
                };
                listaAutora.Add(a);
                Crud<Autor>.Create(s, a);
            }

            Literatura l = new Literatura
            {
                Naslov = textBox1.Text,
                GodinaIzdavanja = int.Parse(textBox2.Text),
                Autori = listaAutora
            };

            Rad r = new Rad
            {
                MestoObjavljivanja = textBox4.Text,
                URL = textBox3.Text,
                FormatDokumenta = textBox5.Text,
                Literatura = l
            };

            Crud<Literatura>.Create(s, l);
            Crud<Rad>.Create(s, r);
            s.Close();
        }

        private void FormDodajRad_Load(object sender, EventArgs e)
        {

        }
    }
}
