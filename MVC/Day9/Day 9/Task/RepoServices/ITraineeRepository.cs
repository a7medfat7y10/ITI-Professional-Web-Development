using System.Collections.Generic;
using Task.Models;

namespace Task.RepoServices
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();
        public Trainee GetDetails(int id);
        public void Insert(Trainee std);
        public void Update(int id, Trainee std);
        public void Delete(int id);
    }
}
