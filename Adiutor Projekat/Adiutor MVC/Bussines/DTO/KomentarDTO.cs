using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class KomentarDTO
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime DatumVreme { get; set; }

        public int KorisnikId { get; set; }
        public int OdgovorId { get; set; }
    }
}
