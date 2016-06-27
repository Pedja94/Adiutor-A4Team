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
    public class PredmetController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Predmet> Get()
        {
            IEnumerable<Predmet> Predmeti = Crud<Predmet>.ReturnAll(sesija);

            return Predmeti;
        }

        // GET api/clanak/5
        public Predmet Get(int id)
        {
            Predmet Predmet = Crud<Predmet>.Read(sesija, id);

            return Predmet;
        }

        // POST api/clanak
        public void Post([FromBody]Predmet Predmet)
        {
            Crud<Predmet>.Create(sesija, Predmet);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Predmet Predmet)
        {
            Crud<Predmet>.Update(sesija, Predmet);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Predmet>.Delete(sesija, id);
        }

    }
}
