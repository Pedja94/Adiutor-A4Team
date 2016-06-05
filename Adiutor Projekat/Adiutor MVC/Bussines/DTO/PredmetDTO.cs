using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.DTO
{
    public class PredmetDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int GodinaStudija { get; set; }
        public int Semestar { get; set; }
    }
}
