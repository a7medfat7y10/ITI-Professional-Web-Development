using System.Collections.Generic;
using Task.Models;

namespace Task.RepoServices
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetDetails(int id);
        public void Insert(Course std);
        public void Update(int id, Course std);
        public void Delete(int id);
    }
}
