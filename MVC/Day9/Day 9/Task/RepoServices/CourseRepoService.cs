using System.Collections.Generic;
using System.Linq;
using Task.Models;

namespace Task.RepoServices
{
    public class CourseRepoServices : ICourseRepository
    {
        public Day9DbContext Context { get; set; }
        public CourseRepoServices(Day9DbContext context)
        {
            Context = context;
        }
       
        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetDetails(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Insert(Course crs)
        {
            Context.Courses.Add(crs);
            Context.SaveChanges();
        }

        public void Update(int id, Course crs)
        {
            Course course = Context.Courses.Find(id);
            course.CName = crs.CName;
            course.CGrade = crs.CGrade;

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Remove(Context.Courses.Find(id));

            Context.SaveChanges();
        }
    }
}
