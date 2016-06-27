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
    public class KnjigaController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Knjiga> Get()
        {
            IEnumerable<Knjiga> Knjigai = Crud<Knjiga>.ReturnAll(sesija);

            foreach (Knjiga Knjiga in Knjigai)
            {
                Knjiga.Literatura = null;
            }

            return Knjigai;
        }

        // GET api/clanak/5
        public Knjiga Get(int id)
        {
            Knjiga Knjiga = Crud<Knjiga>.Read(sesija, id);
            Knjiga.Literatura = null;
            return Knjiga;
        }

        // POST api/clanak
        public void Post([FromBody]Knjiga Knjiga)
        {
            Crud<Knjiga>.Create(sesija, Knjiga);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Knjiga Knjiga)
        {
            Crud<Knjiga>.Update(sesija, Knjiga);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Knjiga>.Delete(sesija, id);
        }

    }
}
