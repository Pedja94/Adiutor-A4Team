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
    public partial class Predmet2 : Form
    {
        public Predmet2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                ISession s = DataLayer.GetSession();

                Predmet p = Crud<Predmet>.Read(s, int.Parse(textBox5.Text));

                textBox1.Text = p.Sifra;
                textBox2.Text = p.Ime;
                textBox3.Text = p.Semestar.ToString();
                textBox4.Text = p.Katedra;
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                button4.Visible = true;
            }
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


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                button4.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                ISession s = DataLayer.GetSession();

                dataGridView1.DataSource = Crud<Predmet>.ReturnAll(s);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
