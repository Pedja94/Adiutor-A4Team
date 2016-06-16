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
        public IList<Student> listaStudenata;

        public FormDodajTim()
        {
            listaStudenata = new List<Student>();
            InitializeComponent();
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
            ISession s = DataLayer.GetSession();
            dataGridView1.DataSource = Crud<Student>.ReturnAll(s);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            s.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Tim t = new Tim
            {
                Ime = textBox9.Text,
                Studenti = listaStudenata
            };

            t.BrojClanova = int.Parse(textBox10.Text);

            ISession s = DataLayer.GetSession();
            Crud<Tim>.Create(s, t);

            s.Close();

            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Student s = new Student
                {
                    Id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                    Smer = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                    BrojIndeksa = Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()),
                    Ime = dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                    ImeRoditelja = dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                    Prezime = dataGridView1.CurrentRow.Cells[5].Value.ToString(),
                };
                listaStudenata.Add(s);
                dataGridView2.DataSource = null;
                dataGridView2.Update();
                dataGridView2.Refresh();
                dataGridView2.DataSource = listaStudenata;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[6].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int pos = dataGridView2.CurrentRow.Index;
                listaStudenata.RemoveAt(pos);
                dataGridView2.DataSource = null;
                dataGridView2.Update();
                dataGridView2.Refresh();
                dataGridView2.DataSource = listaStudenata;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[6].Visible = false;
            }
        }
    }
}
