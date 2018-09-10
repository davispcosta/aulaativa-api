using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;
using Infra.DataContexts;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class StudentsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("students")]
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        [Route("students/{id}")]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        [Route("students/update")]
        public IHttpActionResult UpdateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(student);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("students")]
        public IHttpActionResult PostStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        [Route("students/{id}")]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}