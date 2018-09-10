using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class ActivitiesController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("activities")]
        public IHttpActionResult GetActivities()
        {
            return Ok(db.Activities.ToList());
        }

        [Route("activities/{id}")]
        public IHttpActionResult GetActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpPost]
        [Route("activities/update")]
        public IHttpActionResult UpdateActivity(Activity activity)
        {
            if (activity == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(activity);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("activities")]
        public IHttpActionResult PostActivity(Activity activity)
        {
            if (activity == null)
            {
                return BadRequest(ModelState);
            }

            db.Activities.Add(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        [HttpDelete]
        [Route("activities")]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.Id == id) > 0;
        }
    }
}