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
using Studentski_projekti.Entiteti;
using Studentski_projekti.Mapiranja;
using SP.Data_Access;

namespace SP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Literatura l = new Literatura
                {
                    Naslov = "Higsov bozon",
                    GodinaIzdavanja = 2013
                };

                Rad k = new Rad
                {
                    FormatDokumenta = "pdf",
                    URL = "www.higsov.rs",
                    MestoObjavljivanja = "Niš",
                    Literatura = l
                };

                s.Save(l);
                s.Save(k);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                ISession s = DataLayer.GetSession();

                Literatura l = new Literatura
                {
                    Naslov = "Baze Podataka",
                    GodinaIzdavanja = 2015
                };

                Knjiga k = new Knjiga
                {
                    ISBN = "4835692483513",
                    Izdavac = "Vulkan",
                    Literatura = l
                };

                s.Save(l);
                s.Save(k);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Clanak c = s.Load<Clanak>(43);

                if (c != null)
                {
                    MessageBox.Show(c.Literatura.Naslov);
                }
                else
                {
                    MessageBox.Show("Ne postoji clanak sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Knjiga c = s.Load<Knjiga>(46);

                if (c != null)
                {
                    MessageBox.Show(c.Literatura.Naslov);
                }
                else
                {
                    MessageBox.Show("Ne postoji knjiga sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Rad c = s.Load<Rad>(47);

                if (c != null)
                {
                    MessageBox.Show(c.Literatura.Naslov);
                }
                else
                {
                    MessageBox.Show("Ne postoji rad sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Literatura l = new Literatura
                {
                    Naslov = "NHibernate",
                    GodinaIzdavanja = 2015
                };

                Clanak k = new Clanak
                {
                    ISSN = "4835691532353513",
                    Broj_casopisa = 57,
                    Literatura = l
                };

                s.Save(l);
                s.Save(k);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Literatura l = new Literatura
                {
                    Naslov = "Seobe",
                    GodinaIzdavanja = 1929
                };

                Knjiga k = new Knjiga
                {
                    ISBN = "594959",
                    Izdavac = "Laguna",
                    Literatura = l
                };

                Autor a = new Autor
                {
                    Ime = "Milos Crnjanski",
                };

                a.Literatura.Add(l);


                s.Save(l);
                s.Save(k);
                s.Save(a);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Autor c = s.Load<Autor>(47);

                if (c != null)
                {
                    String l = c.Ime + " je napisao ";
                    foreach (Literatura element in c.Literatura)
                    {

                        l += element.Naslov + ", ";
                    }

                    MessageBox.Show(l);
                }
                else
                {
                    MessageBox.Show("Ne postoji rad sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            OsnovnaLiteratura c = s.Load<OsnovnaLiteratura>(50);

            if (c != null)
            {
                String l = "Osnovna literatura teorijkog projekta " + c.TeorijskiProjekat.Ime + " je: ";

                //foreach (Literatura element in c.Literatura)
                //{
                //    l += element.Naslov + ", ";
                //}

                MessageBox.Show(l);
            }
            else
            {
                MessageBox.Show("Ne postoji osnovna literatura sa zadatim identifikatorom");
            }


            s.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            DodatnaLiteratura c = s.Load<DodatnaLiteratura>(51);

            if (c != null)
            {
                String l = "Dodatna literatura teorijkog projekta " + c.TeorijskiProjekat.Ime + " je: ";

                //foreach (Literatura element in c.Literatura)
                //{
                //    l += element.Naslov + ", ";
                //}

                MessageBox.Show(l);
            }
            else
            {
                MessageBox.Show("Ne postoji rad sa zadatim identifikatorom");
            }


            s.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                TeorijskiProjekat t = new TeorijskiProjekat
                {
                    Ime = "Prepoznavanje rukopisa",
                    MaxBrojStrana = 50,
                    SkolskaGodina = "2016",
                    PojedinacnoIliGrupno = "g"
                };

                t.Predmet = s.Load<Predmet>(45);
                
                s.SaveOrUpdate(t);
                
                s.Flush();
                s.Close();
                
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Predmet p = new Predmet
                {
                    Ime = "Ruski",
                    Katedra = "Katedra za lingvistiku",
                    Semestar = 3,
                    Sifra = "OEZ0566"
                };

                s.SaveOrUpdate(p);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet c = s.Load<Predmet>(44);

                if (c != null)
                {
                    MessageBox.Show(c.Ime + " " + c.Katedra + " " + c.Semestar + " " + c.Sifra);
                }
                else
                {
                    MessageBox.Show("Ne postoji predmet sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();


                Profesor pr = new Profesor
                {
                    Ime = "Misko Milovanovic"
                };

                s.SaveOrUpdate(pr);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Profesor c = s.Load<Profesor>(46);

            if (c != null)
            {
                String l = c.Ime + " predaje: ";

                foreach (Predmet element in c.Predmeti)
                {
                    l += element.Ime + ", ";
                }

                MessageBox.Show(l);
            }
            else
            {
                MessageBox.Show("Ne postoji profesor sa zadatim identifikatorom");
            }


            s.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                PrakticniProjekat t = new PrakticniProjekat
                {
                    Ime = "Adiutor",
                    SkolskaGodina = "2016",
                    PojedinacnoIliGrupno = "g",
                    BrojIzvestaja = 6
                };

                Predmet predmet = s.Load<Predmet>(45);
                t.Predmet = predmet;


                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            try
            {

                ISession s = DataLayer.GetSession();

                Student l = new Student
                {
                    Ime = "Zarko",
                    ImeRoditelja = "Milan",
                    Prezime = "Zarkovic",
                    BrojIndeksa = 12512,
                    Smer = "RII"
                };


                s.SaveOrUpdate(l);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Student c = s.Load<Student>(43);

                if (c != null)
                {
                    MessageBox.Show(c.Ime);
                }
                else
                {
                    MessageBox.Show("Ne postoji student sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Tim t = new Tim
                {
                    Ime = "A4",
                    BrojClanova = 4,  
                };

                Student s1 = s.Load<Student>(45);
                Student s2 = s.Load<Student>(46);
                t.Studenti.Add(s1);
                t.Studenti.Add(s2);
                Projekat p = s.Load<Projekat>(52);
                t.Projekti.Add(p);

                s.Save(t);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
            
                Tim c = s.Load<Tim>(42);

                if (c != null)
                {
                    MessageBox.Show(c.Ime);
                }
                else
                {
                    MessageBox.Show("Ne postoji tim sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Izvestaj i = new Izvestaj
                {
                    Opis = "Ovo je jedan izvestaj",
                    RokPredaje = new DateTime(2015, 05, 15),
                    VremePredaje = new DateTime(2015, 05, 12)
                };

                PrakticniProjekat p = s.Load<PrakticniProjekat>(48);

                i.PrakticniProjekat = p;

                s.Save(i);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Izvestaj i = s.Load<Izvestaj>(50);

                if (i != null)
                {
                    MessageBox.Show(i.Opis);
                }
                else
                {
                    MessageBox.Show("Ne postoji izvestaj sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                WebStranice w = new WebStranice
                {
                    URL = "www.noviprojekat.com",
                };

                PrakticniProjekat p = s.Load<PrakticniProjekat>(48);

                w.PrakticniProjekat = p;

                s.Save(w);
                s.Flush();
                s.Close();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                WebStranice w = s.Load<WebStranice>(47);

                if (w != null)
                {
                    MessageBox.Show(w.URL);
                }
                else
                {
                    MessageBox.Show("Ne postoji web stranica sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PrakticniProjekat p = s.Load<PrakticniProjekat>(47);

                if (p != null)
                {
                    MessageBox.Show(p.Ime);
                }
                else
                {
                    MessageBox.Show("Ne postoji prakticni projekat sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                TeorijskiProjekat p = s.Load<TeorijskiProjekat>(52);

                if (p != null)
                {
                    MessageBox.Show(p.Ime);
                }
                else
                {
                    MessageBox.Show("Ne postoji teorijski projekat sa zadatim identifikatorom");
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Crud<Knjiga>.ReturnAll(s);
        }
    }
}
