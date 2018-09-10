using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class AchievementsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("achievements")]
        public IHttpActionResult GetAchievements()
        {
            return Ok(db.Achievements.ToList());
        }

        [Route("achievements/{id}")]
        public IHttpActionResult GetAchievement(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return Ok(achievement);
        }

        [HttpPost]
        [Route("achievements/update")]
        public IHttpActionResult UpdateAchievement(Achievement achievement)
        {
            if (achievement == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(achievement).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(achievement);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("achievements")]
        public IHttpActionResult PostAchievement(Achievement achievement)
        {
            if (achievement == null)
            {
                return BadRequest(ModelState);
            }

            db.Achievements.Add(achievement);
            db.SaveChanges();

            return Ok(achievement);
        }

        [HttpDelete]
        [Route("achievements/{id}")]
        public IHttpActionResult DeleteAchievement(int id)
        {
            Achievement achievement = db.Achievements.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }

            db.Achievements.Remove(achievement);
            db.SaveChanges();

            return Ok(achievement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AchievementExists(int id)
        {
            return db.Achievements.Count(e => e.Id == id) > 0;
        }
    }
}