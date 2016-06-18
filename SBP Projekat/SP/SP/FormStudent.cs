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
using NHibernate;
using Studentski_projekti.Entiteti;

namespace SP
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Student student = Crud<Student>.Read(s, int.Parse(textBox5.Text));

                textBox10.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                textBox10.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox6.ReadOnly = false;
                button7.Visible = true;
            }
        }

        private void neaktivno() {
            textBox10.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox6.ReadOnly = true;
            button7.Visible = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Student>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();

                Student student = new Student {
                    Ime = textBox9.Text,
                    ImeRoditelja = textBox8.Text,
                    Prezime = textBox7.Text,
                    Smer = textBox6.Text,
                };

                student.Id = int.Parse(textBox5.Text);

                student.BrojIndeksa = int.Parse(textBox10.Text);

                Crud<Student>.Update(s, student);
                neaktivno();
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                neaktivno();
                dataGridView1.DataSource = Crud<Student>.ReturnAll(s);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
