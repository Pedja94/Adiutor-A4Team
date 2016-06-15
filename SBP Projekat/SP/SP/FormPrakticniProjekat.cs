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
        public FormPrakticniProjekat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PrakticniProjekat t = Crud<PrakticniProjekat>.Read(s, int.Parse(textBox5.Text));

                textBox9.Text = t.Ime;
                textBox8.Text = t.SkolskaGodina;
                textBox7.Text = t.PojedinacnoIliGrupno;
                textBox11.Text = t.BrojIzvestaja.ToString();
                textBox10.Text = t.Opis;
                textBox6.Text = t.ProgramskiJezik;
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
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                button7.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<PrakticniProjekat>.Delete(s, int.Parse(textBox5.Text));
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
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
                    ProgramskiJezik = textBox6.Text
                };

                t.BrojIzvestaja = int.Parse(textBox11.Text);
                t.Id = int.Parse(textBox5.Text);

                Crud<PrakticniProjekat>.Update(s, t);
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

                dataGridView1.DataSource = Crud<PrakticniProjekat>.ReturnAll(s);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
