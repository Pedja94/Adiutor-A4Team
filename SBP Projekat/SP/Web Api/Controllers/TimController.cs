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
    public class TimController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Tim> Get()
        {
            IEnumerable<Tim> Timi = Crud<Tim>.ReturnAll(sesija);

            foreach (Tim Tim in Timi)
            {
                Tim.Projekti = null;
                Tim.Studenti = null;
            }

            return Timi;
        }

        // GET api/clanak/5
        public Tim Get(int id)
        {
            Tim Tim = Crud<Tim>.Read(sesija, id);
            Tim.Projekti = null;
            Tim.Studenti = null;
            return Tim;
        }

        // POST api/clanak
        public void Post([FromBody]Tim Tim)
        {
            Crud<Tim>.Create(sesija, Tim);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Tim Tim)
        {
            Crud<Tim>.Update(sesija, Tim);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Tim>.Delete(sesija, id);
        }

    }
}
