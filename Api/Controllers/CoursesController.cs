using Domain;
using Infra.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api")]
    public class CoursesController : ApiController
    {
        private AulaAtivaDataContext db = new AulaAtivaDataContext();

        [Route("courses")]
        public IHttpActionResult GetCourses()
        {
            return Ok(db.Courses.ToList());
        }

        [Route("courses/{id}")]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [Route("courses/update")]
        public IHttpActionResult UpdateCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(course);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("courses")]
        public IHttpActionResult PostCourse(Course course)
        {
            if (course == null)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            db.SaveChanges();

            return Ok(course);
        }

        [HttpDelete]
        [Route("courses/{id}")]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.Id == id) > 0;
        }
    }
}