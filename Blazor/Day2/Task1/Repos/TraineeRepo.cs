using SharedLiberary;
using System.Net.Http.Json;

namespace Task1.Repos
{
    public class TraineeRepo :ITraineeService
    {
        public HttpClient HttpClient { get; }
        public TraineeRepo(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Trainee>> GetAllTrainees()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Trainee>>("/api/Trainees");
        }

        public async Task<Trainee> GetTraineeDetails(int employeeId)
        {
            return await HttpClient.GetFromJsonAsync<Trainee>("/api/Trainees/" + employeeId);
        }

        public async Task UpdateTrainee(Trainee employee)
        {
            await HttpClient.PutAsJsonAsync("/api/Trainees/" + employee.ID,employee);
        }

        public async Task AddTrainee(Trainee employee)
        {
            await HttpClient.PostAsJsonAsync<Trainee>("/api/Trainees/", employee);
        }

        public async Task DeleteTrainee(int employeeId)
        {
            await HttpClient.DeleteAsync("/api/Trainees/" + employeeId);
        }
    }
}
