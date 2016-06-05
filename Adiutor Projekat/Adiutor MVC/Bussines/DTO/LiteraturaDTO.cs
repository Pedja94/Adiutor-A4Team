using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class LiteraturaDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Link { get; set; }

        public int OblastId { get; set; }
    }
}
