using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DataAccess;
using Business.DTO;

namespace Bussines
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KomentarDTO> list = Komentari.VratiSve(40);
        }
    }
}
