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
        public FormDodajPrakticniProjekat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrakticniProjekat p = new PrakticniProjekat
            {
                Ime = textBox2.Text,
                BrojIzvestaja = int.Parse(textBox1.Text),
                SkolskaGodina = textBox3.Text,
                PojedinacnoIliGrupno = textBox4.Text,
                Opis = textBox5.Text,
                ProgramskiJezik = textBox6.Text
            };

            ISession s = DataLayer.GetSession();
            Crud<PrakticniProjekat>.Create(s, p);

            s.Close();
        }
    }
}
