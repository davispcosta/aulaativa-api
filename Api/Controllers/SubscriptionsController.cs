using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class SubscriptionsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("subscriptions")]
        public IHttpActionResult GetSubscriptions()
        {
            return Ok(db.Subscriptions.ToList());
        }

        [Route("subscriptions/{id}")]
        public IHttpActionResult GetSubscription(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [HttpPost]
        [Route("subscriptions/update")]
        public IHttpActionResult UpdateSubscription(Subscription subscription)
        {
            if (subscription == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(subscription);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("subscriptions")]
        public IHttpActionResult PostSubscription(Subscription subscription)
        {
            if (subscription == null)
            {
                return BadRequest(ModelState);
            }

            db.Subscriptions.Add(subscription);
            db.SaveChanges();

            return Ok(subscription);
        }

        [HttpDelete]
        [Route("subscriptions/{id}")]
        public IHttpActionResult DeleteSubscription(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return NotFound();
            }

            db.Subscriptions.Remove(subscription);
            db.SaveChanges();

            return Ok(subscription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionExists(int id)
        {
            return db.Subscriptions.Count(e => e.Id == id) > 0;
        }
    }
}