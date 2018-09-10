using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class QuestionsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("questions")]
        public IHttpActionResult GetQuestions()
        {
            return Ok(db.Questions.ToList());
        }

        [Route("questions/{id}")]
        public IHttpActionResult GetQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPost]
        [Route("questions/update")]
        public IHttpActionResult UpdateQuestion(Question question)
        {
            if (question == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(question);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("questions")]
        public IHttpActionResult PostQuestion(Question question)
        {
            if (question == null)
            {
                return BadRequest(ModelState);
            }

            db.Questions.Add(question);
            db.SaveChanges();

            return Ok(question);
        }

        [HttpDelete]
        [Route("questions/{id}")]
        public IHttpActionResult DeleteQuestion(int id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.Questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionExists(int id)
        {
            return db.Questions.Count(e => e.Id == id) > 0;
        }
    }
}