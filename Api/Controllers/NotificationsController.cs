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
    public class NotificationsController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("notifications")]
        public IHttpActionResult GetNotifications()
        {
            return Ok(db.Notifications.ToList());
        }

        [Route("notifications/{id}")]
        public IHttpActionResult GetNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        [HttpPost]
        [Route("notifications/update")]
        public IHttpActionResult UpdateNotification(Notification notification)
        {
            if (notification == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(notification);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("notifications")]
        public IHttpActionResult PostNotification(Notification notification)
        {
            if (notification == null)
            {
                return BadRequest(ModelState);
            }

            db.Notifications.Add(notification);
            db.SaveChanges();

            return Ok(notification);
        }

        [HttpDelete]
        [Route("notifications")]
        public IHttpActionResult DeleteNotification(int id)
        {
            Notification notification = db.Notifications.Find(id);
            if (notification == null)
            {
                return NotFound();
            }

            db.Notifications.Remove(notification);
            db.SaveChanges();

            return Ok(notification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificationExists(int id)
        {
            return db.Notifications.Count(e => e.Id == id) > 0;
        }
    }
}