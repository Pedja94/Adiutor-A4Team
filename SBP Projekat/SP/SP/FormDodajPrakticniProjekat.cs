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
    public partial class FormDodajPrakticniProjekat : Form
    {
        public List<string> imenaPredmeta;
        public List<int> IdPredmeta;
        public IList<WebStranice> listaStranica;

        public FormDodajPrakticniProjekat()
        {
            listaStranica = new List<WebStranice>();
            InitializeComponent();
            ISession s = DataLayer.GetSession();
            List<Predmet> predmeti = Crud<Predmet>.ReturnAll(s);
            imenaPredmeta = new List<string>();
            IdPredmeta = new List<int>();
            foreach (Predmet p in predmeti)
            {
                imenaPredmeta.Add(p.Ime);
                IdPredmeta.Add(p.Id);
            }
            s.Close();
            dataGridView1.MultiSelect = false;
            comboBox1.DataSource = imenaPredmeta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            int index = comboBox1.SelectedIndex;
            int id = IdPredmeta[index];

            Predmet predmet = Crud<Predmet>.Read(s, id);
            PrakticniProjekat p = new PrakticniProjekat
            {
                Ime = textBox2.Text,
                BrojIzvestaja = int.Parse(textBox1.Text),
                SkolskaGodina = textBox3.Text,
                PojedinacnoIliGrupno = textBox4.Text,
                Opis = textBox5.Text,
                ProgramskiJezik = textBox6.Text,
                Predmet = predmet,
            };

            Crud<PrakticniProjekat>.Create(s, p);

            foreach (WebStranice ws in listaStranica)
            {
                ws.PrakticniProjekat = p;
                Crud<WebStranice>.Create(s, ws);
            }

            s.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebStranice str = new WebStranice()
            {
                URL = textBox7.Text
            };
            listaStranica.Add(str);
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.DataSource = listaStranica;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            textBox7.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int pos = dataGridView1.CurrentRow.Index;
                listaStranica.RemoveAt(pos);
                dataGridView1.DataSource = null;
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.DataSource = listaStranica;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
        }

    }
}
