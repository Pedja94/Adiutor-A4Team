using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using SP.Data_Access;
using Studentski_projekti.Entiteti;

namespace SP
{
    public partial class PoveziSaProjektom : Form
    {
        int trenutnoIzabraniTim;

        public PoveziSaProjektom()
        {
            trenutnoIzabraniTim = -1;
            InitializeComponent();
            textBox1.ReadOnly = true;
            ISession s = DataLayer.GetSession();
            dataGridView1.DataSource = Crud<Tim>.ReturnAll(s);
            dataGridView2.DataSource = Crud<Projekat>.ReturnAll(s);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            s.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                ISession s = DataLayer.GetSession();
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                Tim tim = Crud<Tim>.Read(s, id);
                trenutnoIzabraniTim = tim.Id;
                dataGridView3.DataSource = null;
                dataGridView3.Update();
                dataGridView3.Refresh();
                dataGridView3.DataSource = tim.Projekti;
                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                textBox1.Text = tim.Ime;
                s.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && trenutnoIzabraniTim != -1)
            {
                ISession s = DataLayer.GetSession();
                int ProjekatId = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                Projekat p = Crud<Projekat>.Read(s, ProjekatId);
                Tim t = Crud<Tim>.Read(s, trenutnoIzabraniTim);
                ProjekatTim veza = new ProjekatTim()
                {
                    DatumBiranja = DateTime.Now,
                    RokPredaje = DateTime.Now.AddMonths(3),
                    Projekat = p,
                    Tim = t
                };
                Crud<ProjekatTim>.Create(s, veza);
                Tim tim = Crud<Tim>.Read(s, trenutnoIzabraniTim);
                dataGridView3.DataSource = null;
                dataGridView3.Update();
                dataGridView3.Refresh();
                dataGridView3.DataSource = tim.Projekti;
                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                s.Close();
            }
        }
    }
}
