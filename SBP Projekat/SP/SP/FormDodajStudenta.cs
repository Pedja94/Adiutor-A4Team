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
    public partial class FormDodajStudenta : Form
    {
        public FormDodajStudenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Student student = new Student
            {
                BrojIndeksa = int.Parse(textBox1.Text),
                Ime = textBox2.Text,
                ImeRoditelja = textBox3.Text,
                Prezime = textBox4.Text,
                Smer = textBox5.Text
            };

            ISession s = DataLayer.GetSession();
            Crud<Student>.Create(s, student);

            s.Close();
        }
    }
}
