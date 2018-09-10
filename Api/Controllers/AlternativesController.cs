using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class AlternativesController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("alternatives")]
        public IHttpActionResult GetAlternatives()
        {
            return Ok(db.Alternatives.ToList());
        }

        [Route("alternatives/{id}")]
        public IHttpActionResult GetAlternative(int id)
        {
            Alternative alternative = db.Alternatives.Find(id);
            if (alternative == null)
            {
                return NotFound();
            }

            return Ok(alternative);
        }

        [HttpPost]
        [Route("alternatives/update")]
        public IHttpActionResult UpdateAlternative(Alternative alternative)
        {
            if (alternative == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(alternative).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(alternative);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("alternatives")]
        public IHttpActionResult PostAlternative(Alternative alternative)
        {
            if (alternative == null)
            {
                return BadRequest(ModelState);
            }

            db.Alternatives.Add(alternative);
            db.SaveChanges();

            return Ok(alternative);
        }

        [HttpDelete]
        [Route("alternatives")]
        public IHttpActionResult DeleteAlternative(int id)
        {
            Alternative alternative = db.Alternatives.Find(id);
            if (alternative == null)
            {
                return NotFound();
            }

            db.Alternatives.Remove(alternative);
            db.SaveChanges();

            return Ok(alternative);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternativeExists(int id)
        {
            return db.Alternatives.Count(e => e.Id == id) > 0;
        }
    }
}