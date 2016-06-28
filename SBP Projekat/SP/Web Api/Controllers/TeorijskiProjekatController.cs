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
    public class TeorijskiProjekatController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<TeorijskiProjekat> Get()
        {
            IEnumerable<TeorijskiProjekat> TeorijskiProjekati = Crud<TeorijskiProjekat>.ReturnAll(sesija);

            foreach (TeorijskiProjekat TeorijskiProjekat in TeorijskiProjekati)
            {
                TeorijskiProjekat.Timovi = null;
                TeorijskiProjekat.dodatnaLiteratura = null;
                TeorijskiProjekat.osnovnaLiteratura = null;
                TeorijskiProjekat.Predmet = null;
            }

            return TeorijskiProjekati;
        }

        // GET api/clanak/5
        public TeorijskiProjekat Get(int id)
        {
            TeorijskiProjekat TeorijskiProjekat = Crud<TeorijskiProjekat>.Read(sesija, id);
            TeorijskiProjekat.Timovi = null;
            TeorijskiProjekat.dodatnaLiteratura = null;
            TeorijskiProjekat.osnovnaLiteratura = null;
            TeorijskiProjekat.Predmet = null;
            return TeorijskiProjekat;
        }

        // POST api/clanak
        public void Post([FromBody]TeorijskiProjekat TeorijskiProjekat)
        {
            TeorijskiProjekat.Predmet = new Predmet() { Id = 44};
            Crud<TeorijskiProjekat>.Create(sesija, TeorijskiProjekat);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]TeorijskiProjekat TeorijskiProjekat)
        {
            TeorijskiProjekat.Predmet = new Predmet() { Id = 44 };
            Crud<TeorijskiProjekat>.Update(sesija, TeorijskiProjekat);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<TeorijskiProjekat>.Delete(sesija, id);
        }

    }
}
