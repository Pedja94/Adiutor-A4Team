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
    public class LiteraturaController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Literatura> Get()
        {
            IEnumerable<Literatura> Literaturai = Crud<Literatura>.ReturnAll(sesija);

            foreach (Literatura Literatura in Literaturai)
            {
                Literatura.OsnovnaLiteratura = null;
                Literatura.DodatnaLiteratura = null;
                Literatura.Autori = null;
            }

            return Literaturai;
        }

        // GET api/clanak/5
        public Literatura Get(int id)
        {
            Literatura Literatura = Crud<Literatura>.Read(sesija, id);
            Literatura.OsnovnaLiteratura = null;
            Literatura.DodatnaLiteratura = null;
            Literatura.Autori = null;
            return Literatura;
        }

        // POST api/clanak
        public void Post([FromBody]Literatura Literatura)
        {
            Crud<Literatura>.Create(sesija, Literatura);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Literatura Literatura)
        {
            Crud<Literatura>.Update(sesija, Literatura);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Literatura>.Delete(sesija, id);
        }

    }
}
