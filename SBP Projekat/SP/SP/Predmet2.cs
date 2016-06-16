using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SP.Data_Access;
using NHibernate;
using Studentski_projekti.Entiteti;
using System.Collections.Generic;
using System.ComponentModel;

namespace SP
{
    public partial class Predmet2 : Form
    {
        public Predmet2()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();

                neaktivno();

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try {
                Crud<Predmet>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            button4.Visible = true;

        }

        private void neaktivno() {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
                ISession s = DataLayer.GetSession();

                Predmet p = new Predmet()
                {
                    Ime = textBox2.Text,
                    Sifra = textBox1.Text,
                    Katedra = textBox4.Text
                };

                p.Semestar = int.Parse(textBox3.Text);

                p.Id = int.Parse(textBox5.Text);

                Crud<Predmet>.Update(s, p);

                neaktivno();
              
            }
            catch (Exception ex)
            {

            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();
                neaktivno();
                dataGridView1.DataSource = Crud<Predmet>.ReturnAll(s);
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

    }
}
