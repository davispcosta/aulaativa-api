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
    public class DoubtsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("doubts")]
        public IHttpActionResult GetDoubts()
        {
            return Ok(db.Doubts.ToList());
        }

        [Route("doubts/{id}")]
        public IHttpActionResult GetDoubt(int id)
        {
            Doubt doubt = db.Doubts.Find(id);
            if (doubt == null)
            {
                return NotFound();
            }

            return Ok(doubt);
        }

        [HttpPost]
        [Route("doubts/update")]
        public IHttpActionResult UpdateDoubt(Doubt doubt)
        {
            if (doubt == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(doubt).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(doubt);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("doubts")]
        public IHttpActionResult PostDoubt(Doubt doubt)
        {
            if (doubt == null)
            {
                return BadRequest(ModelState);
            }

            db.Doubts.Add(doubt);
            db.SaveChanges();

            return Ok(doubt);
        }

        [HttpDelete]
        [Route("doubts")]
        public IHttpActionResult DeleteDoubt(int id)
        {
            Doubt doubt = db.Doubts.Find(id);
            if (doubt == null)
            {
                return NotFound();
            }

            db.Doubts.Remove(doubt);
            db.SaveChanges();

            return Ok(doubt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubtExists(int id)
        {
            return db.Doubts.Count(e => e.Id == id) > 0;
        }
    }
}