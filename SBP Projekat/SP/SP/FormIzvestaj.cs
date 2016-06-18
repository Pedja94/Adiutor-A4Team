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
    public partial class FormIzvestaj : Form
    {
        public FormIzvestaj()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            //neaktivno();
            dataGridView1.DataSource = Crud<Izvestaj>.ReturnAll(s);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //TeorijskiProjekat t = Crud<TeorijskiProjekat>.Read(s, int.Parse(textBox5.Text));
                //neaktivno();

                textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = ((PrakticniProjekat)dataGridView1.CurrentRow.Cells[4].Value).Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            button7.Visible = true;
        }

        private void neaktivno()
        {
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            button7.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Izvestaj>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Izvestaj i = new Izvestaj
                {
                    Opis = textBox9.Text,
                    
                };

                i.RokPredaje = DateTime.Parse(textBox8.Text);
                i.VremePredaje = DateTime.Parse(textBox7.Text);
                i.Id = int.Parse(textBox5.Text);

                PrakticniProjekat p = Crud<PrakticniProjekat>.Read(s, int.Parse(textBox6.Text));
                i.PrakticniProjekat = p;
                Crud<Izvestaj>.Update(s, i);
                s.Close();
                neaktivno();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
