using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdiutorBootstrap.Models
{
    public class LiteraturaModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Link { get; set; }
        public int OblastId { get; set; }


        public HttpPostedFileBase LiteraturaFajl { get; set; }

       
    }
}