using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.DTO
{
    public class KorisnikDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public decimal BrojIndeksa { get; set; }
        public string Slika { get; set; }
        public string Smer { get; set; }
        public string Opis { get; set; }
        public decimal GodinaStudija { get; set; }
    }
}
