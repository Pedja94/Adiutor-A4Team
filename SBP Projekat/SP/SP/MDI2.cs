using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP
{
    public partial class MDI2 : Form
    {
        public MDI2()
        {
            InitializeComponent();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPredmet newMDIChild = new FormPredmet();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Predmet2 newMDIChild = new Predmet2();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDodajStudenta newMDIChild = new FormDodajStudenta();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormStudent newMDIChild = new FormStudent();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormDodajTim newMDIChild = new FormDodajTim();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormTim newMDIChild = new FormTim();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormDodajTeorijskiProjekat newMDIChild = new FormDodajTeorijskiProjekat();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormTeorijskiProjekat newMDIChild = new FormTeorijskiProjekat();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormDodajPrakticniProjekat newMDIChild = new FormDodajPrakticniProjekat();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormPrakticniProjekat newMDIChild = new FormPrakticniProjekat();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormDodajKnjigu newMDIChild = new FormDodajKnjigu();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormKnjiga newMDIChild = new FormKnjiga();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FormDodajRad newMDIChild = new FormDodajRad();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FormRad newMDIChild = new FormRad();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FormDodajClanak newMDIChild = new FormDodajClanak();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FormClanak newMDIChild = new FormClanak();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FormDodajIzvestaj newMDIChild = new FormDodajIzvestaj();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void prikaziIIzmeniToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FormIzvestaj newMDIChild = new FormIzvestaj();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void dodajToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FormDodajLiteraturu newMDIChild = new FormDodajLiteraturu();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void poveziSaProjektomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPoveziSaProjektom newMDIChild = new FormPoveziSaProjektom();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
