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
    public partial class FormDodajLiteraturu : Form
    {
        public List<string> imenaProjekta;
        public List<int> IdProjekta;
        public List<string> imenaLiterature;
        public List<int> IdLiterature;
        public List<Literatura> osnovna;
        public List<Literatura> dodatna;
        ISession s = DataLayer.GetSession();

        public FormDodajLiteraturu()
        {
            InitializeComponent();

            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;

            osnovna = new List<Literatura>();
            dodatna = new List<Literatura>();

            //ISession s = DataLayer.GetSession();
            List<TeorijskiProjekat> projekti = Crud<TeorijskiProjekat>.ReturnAll(s);
            imenaProjekta = new List<string>();
            IdProjekta = new List<int>();
            foreach (TeorijskiProjekat p in projekti)
            {
                imenaProjekta.Add(p.Ime);
                IdProjekta.Add(p.Id);
            }
            comboBox1.DataSource = imenaProjekta;

            List<Literatura> literatura = Crud<Literatura>.ReturnAll(s);
            imenaLiterature = new List<string>();
            IdLiterature = new List<int>();
            foreach (Literatura p in literatura)
            {
                imenaLiterature.Add(p.Naslov);
                IdLiterature.Add(p.Id);
            }
            comboBox2.DataSource = imenaLiterature;

           


            //s.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ISession s = DataLayer.GetSession();
            int index = comboBox2.SelectedIndex;
            //string lit = imenaLiterature[index];

            int id = IdLiterature[index];
            Literatura lit = Crud<Literatura>.Read(s, id);
            //lit = (Literatura)s.GetSessionImplementation().PersistenceContext.Unproxy(lit);
            osnovna.Add(lit);

            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.DataSource = osnovna;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            //s.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int index = comboBox2.SelectedIndex;
            int id = IdLiterature[index];
            Literatura lit = Crud<Literatura>.Read(s, id);
            //lit = (Literatura)s.GetSessionImplementation().PersistenceContext.Unproxy(lit);
            dodatna.Add(lit);

            dataGridView2.DataSource = null;
            dataGridView2.Update();
            dataGridView2.Refresh();
            dataGridView2.DataSource = dodatna;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;


            //s.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //s = DataLayer.GetSession();
            int index = comboBox1.SelectedIndex;
            int id = IdProjekta[index];
            TeorijskiProjekat tp = Crud<TeorijskiProjekat>.Read(s, id);

            //OsnovnaLiteratura ol = new OsnovnaLiteratura
            //{
            //    TeorijskiProjekat = tp
            //};

            tp.osnovnaLiteratura = osnovna;
            tp.dodatnaLiteratura = dodatna;

            Crud<TeorijskiProjekat>.Update(s, tp);

            //foreach(Literatura l in osnovna)
            //{
            //    OsnovnaLiteratura ol = new OsnovnaLiteratura
            //    {
            //        TeorijskiProjekat = tp,
            //        Literatura = l
            //    };

            //    Crud<OsnovnaLiteratura>.Create(s, ol);
            //}

            s.Close();
        }
    }
}
