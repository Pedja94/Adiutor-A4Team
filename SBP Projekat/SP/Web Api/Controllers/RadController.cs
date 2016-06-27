using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SP.Data_Access;
using Studentski_projekti.Entiteti;
using SP;
using NHibernate;

namespace Test.Controllers
{
    public class RadController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Rad> Get()
        {
            IEnumerable<Rad> Radi = Crud<Rad>.ReturnAll(sesija);

            foreach (Rad Rad in Radi)
            {
                Rad.Literatura = null;
            }

            return Radi;
        }

        // GET api/clanak/5
        public Rad Get(int id)
        {
            Rad Rad = Crud<Rad>.Read(sesija, id);
            Rad.Literatura = null;
            return Rad;
        }

        // POST api/clanak
        public void Post([FromBody]Rad Rad)
        {
            Crud<Rad>.Create(sesija, Rad);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Rad Rad)
        {
            Crud<Rad>.Update(sesija, Rad);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Rad>.Delete(sesija, id);
        }

    }
}
