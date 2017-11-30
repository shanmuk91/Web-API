using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_EF6.Models;

namespace WebAPI_EF6.Controllers
{
    public class CoursesController : ApiController
    {
        private WebAPI_EF6Context db = new WebAPI_EF6Context();

        // GET: api/Courses
        public IQueryable<CourseDTO> GetCourses()
        {
            var courses = from c in db.Courses
                        select new CourseDTO()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            InstructorName = c.Instructor.Name
                        };

            return courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(CourseDetailDTO))]
        public async Task<IHttpActionResult> GetCourse(int id)
        {
            var Course = await db.Courses.Include(c => c.Instructor).Select(c =>
         new CourseDetailDTO()
         {
             Id = c.Id,
             Title = c.Title,
             Credits = c.Credits,
             Price = c.Price,
             InstructorName = c.Instructor.Name,
             Dept = c.Dept,
             StartDate = c.StartDate
         }).SingleOrDefaultAsync(c => c.Id == id);
            if (Course == null)
            {
                return NotFound();
            }

            return Ok(Course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(course);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(course).Reference(x => x.Instructor).Load();

            var dto = new CourseDTO()
            {
                Id = course.Id,
                Title = course.Title,
                InstructorName = course.Instructor.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, dto);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Courses.Remove(course);
            await db.SaveChangesAsync();

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