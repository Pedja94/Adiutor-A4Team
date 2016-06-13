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
    public partial class FormClanak : Form
    {
        public FormClanak()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Clanak c = Crud<Clanak>.Read(s, int.Parse(textBox5.Text));

                textBox9.Text = c.Literatura.Naslov;
                textBox8.Text = c.Literatura.GodinaIzdavanja.ToString();
                textBox7.Text = c.ISSN;
                textBox6.Text = c.Broj_casopisa.ToString();
                textBox10.Text = c.Literatura.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                textBox9.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox6.ReadOnly = false;
                button7.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Clanak>.Delete(s, int.Parse(textBox5.Text));
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
            try
            {
                ISession s = DataLayer.GetSession();

                Literatura l = new Literatura
                {
                    Id = int.Parse(textBox10.Text),
                    Naslov = textBox9.Text,
                    GodinaIzdavanja = int.Parse(textBox8.Text)
                };

                Clanak c = new Clanak
                {
                    ISSN = textBox7.Text,
                    Broj_casopisa = int.Parse(textBox6.Text),
                    Literatura = l
                };

                c.Id = int.Parse(textBox5.Text);

                Crud<Literatura>.Update(s, l);
                Crud<Clanak>.Update(s, c);
                s.Close();
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

                dataGridView1.DataSource = Crud<Clanak>.ReturnAll(s);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
