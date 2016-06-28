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
    public class IzvestajController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Izvestaj> Get()
        {
            IEnumerable<Izvestaj> Izvestaji = Crud<Izvestaj>.ReturnAll(sesija);

            foreach (Izvestaj Izvestaj in Izvestaji)
            {
                Izvestaj.PrakticniProjekat = null;
            }

            return Izvestaji;
        }

        // GET api/clanak/5
        public Izvestaj Get(int id)
        {
            Izvestaj Izvestaj = Crud<Izvestaj>.Read(sesija, id);
            Izvestaj.PrakticniProjekat = null;
            return Izvestaj;
        }

        // POST api/clanak
        public void Post([FromBody]Izvestaj Izvestaj)
        {
            Izvestaj.PrakticniProjekat = new PrakticniProjekat() { Id = 167};
            Crud<Izvestaj>.Create(sesija, Izvestaj);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Izvestaj Izvestaj)
        {
            Izvestaj.PrakticniProjekat = new PrakticniProjekat() { Id = 167 };
            Crud<Izvestaj>.Update(sesija, Izvestaj);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Izvestaj>.Delete(sesija, id);
        }

    }
}
