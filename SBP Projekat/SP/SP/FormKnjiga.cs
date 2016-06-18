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
using SP.Wrappers;

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

                //Knjiga k = Crud<Knjiga>.Read(s, int.Parse(textBox5.Text));
                neaktivno();

                textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
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
            button7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            button7.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Knjiga>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
                textBox10.Text = "";
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
                List<Knjiga> lista = Crud<Knjiga>.ReturnAll(s);
                List<WKnjiga> lista2 = new List<WKnjiga>();

                foreach (Knjiga r in lista)
                {
                    WKnjiga knjiga = new WKnjiga
                    {
                        Id = r.Id,
                        Naslov = r.Literatura.Naslov,
                        GodinaIzdavanja = r.Literatura.GodinaIzdavanja,
                        LiteraturaId = r.Literatura.Id,
                        ISBN = r.ISBN,
                        Izdavac = r.Izdavac
                    };
                    lista2.Add(knjiga);
                }
                dataGridView1.DataSource = lista2;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
