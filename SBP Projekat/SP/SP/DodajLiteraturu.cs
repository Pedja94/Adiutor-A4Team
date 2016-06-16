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
    public partial class DodajLiteraturu : Form
    {
        public List<string> imenaProjekta;
        public List<int> IdProjekta;
        public List<string> imenaLiterature;
        public List<int> IdLiterature;

        public DodajLiteraturu()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;

            ISession s = DataLayer.GetSession();
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

            int index = comboBox1.SelectedIndex;
            int id = IdProjekta[index];
            TeorijskiProjekat tp = Crud<TeorijskiProjekat>.Read(s, id);
 

            s.Close();
        }
    }
}
