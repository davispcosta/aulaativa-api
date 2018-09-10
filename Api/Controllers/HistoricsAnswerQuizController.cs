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
    public class HistoricsAnswerQuizController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("historic/quiz/answers")]
        public IHttpActionResult GetHistoricsAnswerQuiz()
        {
            return Ok(db.HistoricsAnswerQuiz.ToList());
        }

        [Route("historic/quiz/answers/{id}")]
        public IHttpActionResult GetHistoricAnswerQuiz(int id)
        {
            HistoricAnswerQuiz historicAnswerQuiz = db.HistoricsAnswerQuiz.Find(id);
            if (historicAnswerQuiz == null)
            {
                return NotFound();
            }

            return Ok(historicAnswerQuiz);
        }

        [HttpPost]
        [Route("historic/quiz/answers/update")]
        public IHttpActionResult UpdateHistoricAnswerQuiz(HistoricAnswerQuiz historicAnswerQuiz)
        {
            if (historicAnswerQuiz == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(historicAnswerQuiz).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(historicAnswerQuiz);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("historic/quiz/answers")]
        public IHttpActionResult PostHistoricAnswerQuiz(HistoricAnswerQuiz historicAnswerQuiz)
        {
            if (historicAnswerQuiz == null)
            {
                return BadRequest(ModelState);
            }

            db.HistoricsAnswerQuiz.Add(historicAnswerQuiz);
            db.SaveChanges();

            return Ok(historicAnswerQuiz);
        }

        [HttpDelete]
        [Route("historic/quiz/answers/{id}")]
        public IHttpActionResult DeleteHistoricAnswerQuiz(int id)
        {
            HistoricAnswerQuiz historicAnswerQuiz = db.HistoricsAnswerQuiz.Find(id);
            if (historicAnswerQuiz == null)
            {
                return NotFound();
            }

            db.HistoricsAnswerQuiz.Remove(historicAnswerQuiz);
            db.SaveChanges();

            return Ok(historicAnswerQuiz);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoricAnswerQuizExists(int id)
        {
            return db.HistoricsAnswerQuiz.Count(e => e.Id == id) > 0;
        }
    }
}