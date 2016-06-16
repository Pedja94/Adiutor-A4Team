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

                //Tim t = Crud<Tim>.Read(s, int.Parse(textBox5.Text));

                neaktivno();
                textBox10.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void neaktivno()
        {
            textBox10.ReadOnly = true;
            textBox9.ReadOnly = true;
            button7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox10.ReadOnly = false;
            textBox9.ReadOnly = false;
            button7.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            try
            {
                Crud<Tim>.Delete(s, int.Parse(textBox5.Text));
                neaktivno();
                textBox10.Text = "";
                textBox9.Text = "";
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

                Tim t = new Tim
                {
                    Ime = textBox9.Text
                };

                t.Id = int.Parse(textBox5.Text);

                t.BrojClanova = int.Parse(textBox10.Text);

                Crud<Tim>.Update(s, t);
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
                dataGridView1.DataSource = Crud<Tim>.ReturnAll(s);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
