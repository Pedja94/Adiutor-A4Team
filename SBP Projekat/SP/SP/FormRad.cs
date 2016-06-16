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
    public partial class FormRad : Form
    {
        public FormRad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // Rad r = Crud<Rad>.Read(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox9.Text = ((Literatura)dataGridView1.CurrentRow.Cells[4].Value).Naslov;
                textBox8.Text = ((Literatura)dataGridView1.CurrentRow.Cells[4].Value).GodinaIzdavanja.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox10.Text = ((Literatura)dataGridView1.CurrentRow.Cells[4].Value).Id.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            textBox11.ReadOnly = true;
            button7.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox11.ReadOnly = false;
            button7.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Rad>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox11.Text = "";
                textBox10.Text = "";
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

                Literatura l = new Literatura
                {
                    Id = int.Parse(textBox10.Text),
                    Naslov = textBox9.Text,
                    GodinaIzdavanja = int.Parse(textBox8.Text)
                };

                Rad r = new Rad
                {
                    MestoObjavljivanja = textBox11.Text,
                    URL = textBox7.Text,
                    FormatDokumenta = textBox6.Text,
                    Literatura = l
                };

                r.Id = int.Parse(textBox5.Text);

                Crud<Literatura>.Update(s, l);
                Crud<Rad>.Update(s, r);
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
                dataGridView1.DataSource = Crud<Rad>.ReturnAll(s);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
