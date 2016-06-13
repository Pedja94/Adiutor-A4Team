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
    public partial class FormKnjiga : Form
    {
        public FormKnjiga()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Knjiga k = Crud<Knjiga>.Read(s, int.Parse(textBox5.Text));

                textBox9.Text = k.Literatura.Naslov;
                textBox8.Text = k.Literatura.GodinaIzdavanja.ToString();
                textBox7.Text = k.ISBN;
                textBox6.Text = k.Izdavac;
                textBox10.Text = k.Literatura.Id.ToString();
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
                Crud<Knjiga>.Delete(s, int.Parse(textBox5.Text));
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

                Knjiga k = new Knjiga
                {
                    ISBN = textBox7.Text,
                    Izdavac = textBox6.Text,
                    Literatura = l
                };

                k.Id = int.Parse(textBox5.Text);

                Crud<Literatura>.Update(s, l);
                Crud<Knjiga>.Update(s, k);
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

                dataGridView1.DataSource = Crud<Knjiga>.ReturnAll(s);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
