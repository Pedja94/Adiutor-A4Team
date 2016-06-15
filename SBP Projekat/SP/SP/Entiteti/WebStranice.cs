using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentski_projekti.Entiteti
{
    public class WebStranice
    {
        public virtual int Id { get; protected set; }
        public virtual string URL { get; set; }

        public virtual PrakticniProjekat PrakticniProjekat { get; set; }

    }
}

