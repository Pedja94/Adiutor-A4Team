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
    public partial class FormTim : Form
    {
        public FormTim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Tim t = Crud<Tim>.Read(s, int.Parse(textBox5.Text));

                textBox10.Text = t.BrojClanova.ToString();
                textBox9.Text = t.Ime;
               
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
                button7.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Tim>.Delete(s, int.Parse(textBox5.Text));
                textBox10.Text = "";
                textBox9.Text = "";
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

                Tim t = new Tim
                {
                    Ime = textBox9.Text
                };

                t.Id = int.Parse(textBox5.Text);

                t.BrojClanova = int.Parse(textBox10.Text);

                Crud<Tim>.Update(s, t);
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

                dataGridView1.DataSource = Crud<Tim>.ReturnAll(s);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
