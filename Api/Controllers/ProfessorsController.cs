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
    public class ProfessorsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("professors")]
        public IHttpActionResult GetProfessors()
        {
            return Ok(db.Professors.ToList());
        }

        [Route("professors/{id}")]
        public IHttpActionResult GetProfessor(int id)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [Route("professors/update")]
        public IHttpActionResult UpdateProfessor(Professor professor)
        {
            if (professor == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(professor);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [Route("professors")]
        public IHttpActionResult PostProfessor(Professor professor)
        {
            if (professor == null)
            {
                return BadRequest(ModelState);
            }

            db.Professors.Add(professor);
            db.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete]
        [Route("professors/{id}")]
        public IHttpActionResult DeleteProfessor(int id)
        {
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            db.Professors.Remove(professor);
            db.SaveChanges();

            return Ok(professor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfessorExists(int id)
        {
            return db.Professors.Count(e => e.Id == id) > 0;
        }
    }
}