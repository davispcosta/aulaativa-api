using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class DoubtAnswersController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("doubt/answers")]
        public IHttpActionResult GetDoubtAnswers()
        {
            return Ok(db.DoubtAnswers.ToList());
        }

        [Route("doubt/answers/{id}")]
        public IHttpActionResult GetDoubtAnswer(int id)
        {
            DoubtAnswer doubtAnswer = db.DoubtAnswers.Find(id);
            if (doubtAnswer == null)
            {
                return NotFound();
            }

            return Ok(doubtAnswer);
        }

        [HttpPost]
        [Route("doubt/answers/update")]
        public IHttpActionResult UpdateDoubtAnswer(DoubtAnswer doubtAnswer)
        {
            if (doubtAnswer == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(doubtAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(doubtAnswer);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("doubt/answers")]
        public IHttpActionResult PostDoubtAnswer(DoubtAnswer doubtAnswer)
        {
            if (doubtAnswer == null)
            {
                return BadRequest(ModelState);
            }

            db.DoubtAnswers.Add(doubtAnswer);
            db.SaveChanges();

            return Ok(doubtAnswer);
        }

        [HttpDelete]
        [Route("doubt/answers/{id}")]
        public IHttpActionResult DeleteDoubtAnswer(int id)
        {
            DoubtAnswer doubtAnswer = db.DoubtAnswers.Find(id);
            if (doubtAnswer == null)
            {
                return NotFound();
            }

            db.DoubtAnswers.Remove(doubtAnswer);
            db.SaveChanges();

            return Ok(doubtAnswer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoubtAnswerExists(int id)
        {
            return db.DoubtAnswers.Count(e => e.Id == id) > 0;
        }
    }
}