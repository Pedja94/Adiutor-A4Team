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

namespace Web_Api.Controllers
{
    public class ClanakController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Clanak> Get()
        {
            IEnumerable<Clanak> Clanaki = Crud<Clanak>.ReturnAll(sesija);

            foreach (Clanak Clanak in Clanaki)
            {
                Clanak.Literatura = null;
            }

            return Clanaki;
        }

        // GET api/clanak/5
        public Clanak Get(int id)
        {
            Clanak Clanak = Crud<Clanak>.Read(sesija, id);
            Clanak.Literatura = null;
            return Clanak;
        }

        // POST api/clanak
        public void Post([FromBody]Clanak Clanak)
        {
            //linija je dodata da bi mogli da testiramo sa objektima koje dobijemo kao rezultat 
            //kontrolera ge. Potavlja se objekat iz baze, zbog toga sto je u odgovarajucoj tabeli spoljni kljuc obavezan
            Clanak.Literatura = new Literatura() { Id = 81};
            Crud<Clanak>.Create(sesija, Clanak);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Clanak Clanak)
        {
            //linija je dodata da bi mogli da testiramo sa objektima koje dobijemo kao rezultat 
            //kontrolera ge. Potavlja se objekat iz baze, zbog toga sto je u odgovarajucoj tabeli spoljni kljuc obavezan
            Clanak.Literatura = new Literatura() { Id = 81 };
            Crud<Clanak>.Update(sesija, Clanak);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Clanak>.Delete(sesija, id);
        }
	}
}