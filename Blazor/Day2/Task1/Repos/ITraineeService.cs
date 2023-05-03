using SharedLiberary;

namespace Task1.Repos
{
    public interface  ITraineeService
    {
        Task<IEnumerable<Trainee>> GetAllTrainees();
        Task<Trainee> GetTraineeDetails(int TraineeId);
        Task AddTrainee(Trainee Trainee);
        Task UpdateTrainee(Trainee Trainee);
        Task DeleteTrainee(int Trainee);
    }
}
