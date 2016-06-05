using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.DTO
{
    public class OdgovorDTO
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Plus { get; set; }
        public int Minus { get; set; }
        public int Odobreno { get; set; }
        public DateTime DatumVreme { get; set; }
    }
}
