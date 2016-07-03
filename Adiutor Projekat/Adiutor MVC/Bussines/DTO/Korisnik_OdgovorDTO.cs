using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class Korisnik_OdgovorDTO
    {
        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int OdgovorId { get; set; }
    }
}
