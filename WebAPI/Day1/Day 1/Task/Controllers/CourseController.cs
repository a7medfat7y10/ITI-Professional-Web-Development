using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult get()
        {
            List<Course> crss = CourseList.Courses.ToList();
            if (crss.Count == 0)
                return NotFound();
            return Ok(crss);
        }
        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            Course crs = CourseList.Courses.Find(x => x.id == id);
            if (crs == null)
                return NotFound();
            return Ok(crs);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult getByName(string name)
        {
            Course crs = CourseList.Courses.Find(x => x.name.ToLower() == name.ToLower());
            if (crs == null)
                return NotFound();
            return Ok(crs);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCourse (int id)
        {
            Course crs = CourseList.Courses.Find(x => x.id == id);
            if (crs == null)
                return NotFound();
                CourseList.Courses.Remove(crs);
            return Ok(crs);
        }
        [HttpPost]
        public IActionResult post(Course c)
        {
            if (c == null)
                return NotFound();
            CourseList.Courses.Add(c);
            return Ok(CourseList.Courses.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult put(int id, Course c)
        {
            Course crs = CourseList.Courses.Find(c => c.id == id);
            if (crs == null)
                return NotFound();
            crs.name = c.name;
            crs.Duration = c.Duration;
            crs.Description = c.Description;

            return Ok(CourseList.Courses.ToList());
        }
    }
}
