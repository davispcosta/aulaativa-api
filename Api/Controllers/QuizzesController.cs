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
    public class QuizzesController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("quizzes")]
        public IHttpActionResult GetQuizzes()
        {
            return Ok(db.Quizzes.ToList());
        }

        [Route("quizzes/{id}")]
        public IHttpActionResult GetQuiz(int id)
        {
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        [HttpPost]
        [Route("quizzes/update")]
        public IHttpActionResult UpdateQuiz(Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(quiz);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("quizzes")]
        public IHttpActionResult PostQuiz(Quiz quiz)
        {
            if (quiz == null)
            {
                return BadRequest(ModelState);
            }

            db.Quizzes.Add(quiz);
            db.SaveChanges();

            return Ok(quiz);
        }

        [HttpDelete]
        [Route("quizzes/{id}")]
        public IHttpActionResult DeleteQuiz(int id)
        {
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return NotFound();
            }

            db.Quizzes.Remove(quiz);
            db.SaveChanges();

            return Ok(quiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuizExists(int id)
        {
            return db.Quizzes.Count(e => e.Id == id) > 0;
        }
    }
}