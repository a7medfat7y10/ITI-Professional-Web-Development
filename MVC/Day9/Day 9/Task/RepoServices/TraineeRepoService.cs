using System.Collections.Generic;
using System.Linq;
using Task.Models;

namespace Task.RepoServices
{
    public class TraineeRepoService : ITraineeRepository
    {
        public Day9DbContext Context { get; set; }
        public TraineeRepoService(Day9DbContext context)
        {
            Context = context;
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.ToList();
        }

        public Trainee GetDetails(int id)
        {
            return Context.Trainees.Find(id);
        }

        public void Insert(Trainee tr)
        {
            Context.Trainees.Add(tr);
            Context.SaveChanges();
        }

        public void Update(int id, Trainee tr)
        {
            Trainee trainee = Context.Trainees.Find(id);
            trainee.ID = tr.ID;
            trainee.Name = tr.Name;
            trainee.gender = tr.gender;
            trainee.Email = tr.Email;
            trainee.PhoneNum = tr.PhoneNum;
            trainee.BDate= tr.BDate;

            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Context.Remove(Context.Trainees.Find(id));
            Context.SaveChanges();
        }
    }
}
