using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class Predlozeni_TagDTO
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string TagIme { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public DateTime DatumObrade { get; set; }
    }
}
