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
    public class PrakticniProjekatController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<PrakticniProjekat> Get()
        {
            IEnumerable<PrakticniProjekat> PrakticniProjekati = Crud<PrakticniProjekat>.ReturnAll(sesija);

            foreach (PrakticniProjekat PrakticniProjekat in PrakticniProjekati)
            {
                PrakticniProjekat.Timovi = null;
                PrakticniProjekat.Izvestaji = null;
                PrakticniProjekat.Predmet = null;
                PrakticniProjekat.WebStranice = null;
            }

            return PrakticniProjekati;
        }

        // GET api/clanak/5
        public PrakticniProjekat Get(int id)
        {
            PrakticniProjekat PrakticniProjekat = Crud<PrakticniProjekat>.Read(sesija, id);
            PrakticniProjekat.Timovi = null;
            PrakticniProjekat.Izvestaji = null;
            PrakticniProjekat.Predmet = null;
            PrakticniProjekat.WebStranice = null;
            return PrakticniProjekat;
        }

        // POST api/clanak
        public void Post([FromBody]PrakticniProjekat PrakticniProjekat)
        {
            PrakticniProjekat.Predmet = new Predmet() { Id = 44};
            Crud<PrakticniProjekat>.Create(sesija, PrakticniProjekat);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]PrakticniProjekat PrakticniProjekat)
        {
            PrakticniProjekat.Predmet = new Predmet() { Id = 44 };
            Crud<PrakticniProjekat>.Update(sesija, PrakticniProjekat);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<PrakticniProjekat>.Delete(sesija, id);
        }

    }
}
