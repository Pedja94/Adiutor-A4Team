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
    public partial class FormPrakticniProjekat : Form
    {
        public Predmet predmet;

        public FormPrakticniProjekat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                neaktivno();

                textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                ISession s = DataLayer.GetSession();
                int id = int.Parse(textBox5.Text);
                PrakticniProjekat pp = Crud<PrakticniProjekat>.Read(s, id);
                predmet = pp.Predmet;
                s.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void neaktivno()
        {
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            button7.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {   
            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            button7.Visible = true;   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<PrakticniProjekat>.Delete(s, int.Parse(textBox5.Text));

                neaktivno();
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
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

                PrakticniProjekat t = new PrakticniProjekat
                {
                    Ime = textBox9.Text,
                    SkolskaGodina = textBox8.Text,
                    PojedinacnoIliGrupno = textBox7.Text,
                    Opis = textBox10.Text,
                    ProgramskiJezik = textBox6.Text,
                    Predmet = predmet
                };

                t.BrojIzvestaja = int.Parse(textBox11.Text);
                t.Id = int.Parse(textBox5.Text);

                Crud<PrakticniProjekat>.Update(s, t);
                s.Close();
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
                dataGridView1.DataSource = Crud<PrakticniProjekat>.ReturnAll(s);
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}