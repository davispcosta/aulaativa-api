using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class ClassesController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("classes")]
        public IHttpActionResult GetClasses()
        {
            return Ok(db.Classes.ToList());
        }

        [Route("classes/{id}")]
        public IHttpActionResult GetClass(int id)
        {
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        [Route("classes/update")]
        public IHttpActionResult UpdateClass(Class @class)
        {
            if (@class == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(@class);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("classes")]
        public IHttpActionResult PostClass(Class @class)
        {
            if (@class == null)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(@class);
            db.SaveChanges();

            return Ok(@class);
        }

        [HttpDelete]
        [Route("classes/{id}")]
        public IHttpActionResult DeleteClass(int id)
        {
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return NotFound();
            }

            db.Classes.Remove(@class);
            db.SaveChanges();

            return Ok(@class);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassExists(int id)
        {
            return db.Classes.Count(e => e.Id == id) > 0;
        }
    }
}