using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using NHibernate;
using Database.Entiteti;
using Business.DTO;
using Business.DataAccess;

namespace Bussines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ISession s = DataLayer.GetSession();
                //Role ro = new Role() 
                //{
                //    Id = 1
                //};
                //Status st = new Status() 
                //{
                //    Id = 1
                //};
                //Korisnik k = new Korisnik()
                //{
                //    BrojIndeksa = 14826,
                //    Email = "a",
                //    GodinaStudija = 2,
                //    Ime = "a",
                //    Prezime = "a",
                //    Opis = "a",
                //    Password = "a",
                //    Slika = "a",
                //    Smer = "a",
                //    Username = "a",
                //    ImaRolu = ro,
                //    ImaStatus = st
                //};






                //Pitanje_TagDTO pt = new Pitanje_TagDTO
                //{
                //    PitanjeId = 37,
                //    TagId = 38
                //};

                //Pitanje_TagDTO pt1 = new Pitanje_TagDTO
                //{
                //    PitanjeId = 37,
                //    TagId = 17
                //};

                //Pitanja_Tagovi.Dodaj(pt);
                //Pitanja_Tagovi.Dodaj(pt1);

                //List<PitanjeDTO> lista = Pitanja.VratiSvaPitanjaTaga(38);
                //List<TagDTO> tagovi = Pitanja.VratiSveTagovePitanja(37);
                //List<PredmetDTO> predmeti = Predmeti.VratiSvePredmete(57);

                //SmerDTO smer = new SmerDTO
                //{
                //    Ime = "EENN"
                //};

                //Smerovi.Dodaj(smer);
                //SmerDTO a = Smerovi.Procitaj(57);
                //a.Ime = "EEN";
                //Smerovi.Izmeni(a);
                //List<SmerDTO> smerovi = Smerovi.VratiSve();
                //Smerovi.DodajPredmetSmeru(23, 57);
                //Smerovi.IzbrisiPredmetSaSmera(21, 58);

                //Smerovi.Obrisi(57);

                //SlikaDTO slika = new SlikaDTO
                //{
                //    Link = "link do slike"
                //};


                //OdgovorDTO o = Odgovori.Procitaj(39);
                //slika.OdgovorId = o.Id;
                //Slike.Dodaj(slika);
                //SlikaDTO s = Slike.Procitaj(43);
                //s.Link = "novi link";
                //Slike.Izmeni(s);
                //Slike.VratiSve(39);
                //Slike.Obrisi(42);

                //PredmetDTO predmet = Predmeti.Procitaj(42);

                //ProfesorDTO profa = new ProfesorDTO {
                //    PunoIme = "Milos Mladenovic",
                //    PredmetId = predmet.Id
                //};

                //Profesori.Dodaj(profa);
                //ProfesorDTO pr = Profesori.Procitaj(37);
                //pr.PunoIme = "Predrag Nikolic";
                //Profesori.Izmeni(pr);
                //Profesori.VratiSve(42);
                //Profesori.Obrisi(37);

                //Predmet_SmerDTO ps = new Predmet_SmerDTO
                //{
                //    PredmetId = 42,
                //    SmerId = 77
                //};
                //Predmet_Smerovi.Dodaj(ps);

                //PredmetDTO pr = new PredmetDTO
                //{
                //    Naziv = "VI",
                //    Semestar = 6,
                //    GodinaStudija = 3,
                //    ProfesorId = 38
                //};

                //Predmeti.Dodaj(pr);
                //PredmetDTO predmet = Predmeti.Procitaj(42);
                //predmet.Naziv = "Analogna Elektronika";
                //Predmeti.Izmeni(predmet);
                //Predmeti.VratiSve();
                //Predmeti.VratiSvePredmete(77);
                //Predmeti.Obrisi(40);

                //ProfesorDTO prof = Profesori.Procitaj(38);

                //Predmeti.DodajZaduzenog(39, prof);
                //Predmeti.IzbrisiZaduzenog(39, prof);

                //Profesori.Procitaj();
                //s.SaveOrUpdate(k);
                //s.Flush();
                //s.Close();

                //Predlozeni_TagDTO pt = new Predlozeni_TagDTO
                //{
                //    Ime = "eth",
                //    TagIme = "eth",
                //    DatumPostavljanja = new DateTime(2015, 5, 20),
                //    DatumObrade = new DateTime(2015, 5, 22),
                //    Opis = "eth tag"
                //};

                //PredlozeniTagovi.Dodaj(pt);
                //Predlozeni_TagDTO ptd = PredlozeniTagovi.Procitaj(57);
                //ptd.Opis = "eth tag na adiutoru";
                //PredlozeniTagovi.Izmeni(ptd);
                //PredlozeniTagovi.VratiSve();
                //PredlozeniTagovi.Obrisi(58);

                //Pitanje_TagDTO ptdto = new Pitanje_TagDTO
                //{
                //    PitanjeId = 37,
                //    TagId = 57

                //};

                //Pitanja_Tagovi.Dodaj(ptdto);
                //Pitanja_Tagovi.Nadji(37, 57);
                //Pitanja_Tagovi.Obrisi(38);



                PitanjeDTO pitanje = new PitanjeDTO
                {
                    Naslov = "Novo pitanje",
                    Tekst = "Da li je",
                    DatumVreme = new DateTime(2015, 5, 25),
                    KorisnikId = 37,
                    OblastId = 37
                };

                //Pitanja.Dodaj(pitanje);
                //PitanjeDTO pt = Pitanja.Procitaj(97);
                //pt.Tekst = "nesto drugo";
                //Pitanja.Izmeni(pt);
                //Pitanja.Obrisi(37);
                //Pitanja.VratiSvaPitanjaKorisnika(37);
                //Pitanja.VratiSvaPitanjaOblasti(37);

                //OdgovorDTO odg = new OdgovorDTO
                //{
                //    DatumVreme = new DateTime(2016, 5, 28),
                //    Minus = 5,
                //    Plus = 14,
                //    Tekst = "ja mislim da je ovako",
                //    KorisnikId = 37,
                //    PitanjeId = 39,
                //    Odobreno = 1
                //};

                //Odgovori.Dodaj(odg);
                //OdgovorDTO o = Odgovori.Procitaj(58);
                //o.Tekst = "ipak je ovo";
                //Odgovori.Izmeni(o);
                //Odgovori.DodajMinus(58);
                //Odgovori.DodajPlus(58);
                //Odgovori.Odobri(58);
                //Odgovori.VratiSve(39);

                //OblastDTO oblast = new OblastDTO
                //{
                //    Ime = "Grafovi",
                //    PredmetId = 62
                //};

                //Oblasti.Dodaj(oblast);
                OblastDTO ob = Oblasti.Procitaj(58);
                //ob.Ime = "Nova oblast";
                //Oblasti.Izmeni(ob);
                //Oblasti.VratiSve();
                //Oblasti.Obrisi(38);

                //LiteraturaDTO lt = new LiteraturaDTO
                //{
                //    Link = "neki link",
                //    Naziv = "Knjiga",
                //    OblastId = 58
                //};

                //Literature.Dodaj(lt);

                //LiteraturaDTO lit = Literature.Procitaj(37);
                //lit.Naziv = "noviiiii";
                //Literature.Izmeni(lit);
                //Literature.VratiSve(58);
                //Literature.Obrisi(37);
                //PredmetDTO p = Predmeti.Procitaj(21);

                Tagovi.Nadji("web");
                Pitanja.Nadji("Novo pitanje");   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}