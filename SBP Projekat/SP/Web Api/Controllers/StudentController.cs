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
    public class StudentController : ApiController
    {
        ISession sesija = DataLayer.GetSession();

        // GET api/clanak
        public IEnumerable<Student> Get()
        {
            IEnumerable<Student> studenti = Crud<Student>.ReturnAll(sesija);

            foreach (Student student in studenti)
            {
                student.Timovi = null;
            }

            return studenti;
        }

        // GET api/clanak/5
        public Student Get(int id)
        {
            Student student =  Crud<Student>.Read(sesija, id);
            student.Timovi = null;
            return student;
        }

        // POST api/clanak
        public void Post([FromBody]Student student)
        {
            Crud<Student>.Create(sesija, student);
        }

        // PUT api/clanak/5
        public void Put(int id, [FromBody]Student student)
        {
            Crud<Student>.Update(sesija, student);
        }

        // DELETE api/clanak/5
        public void Delete(int id)
        {
            Crud<Student>.Delete(sesija, id);
        }

    }
}
