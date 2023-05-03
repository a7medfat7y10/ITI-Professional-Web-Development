using SharedLiberary;
using System.Net.Http.Json;

namespace Task1.Repos
{
    public class TrackRepo:ITrackService
    {

        public HttpClient HttpClient { get; }
        public TrackRepo(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Track>>("/api/Tracks");
        }

        public async Task<Track> GetTrackDetails(int employeeId)
        {
            return await HttpClient.GetFromJsonAsync<Track>("/api/Tracks/" + employeeId);
        }

        public async Task UpdateTrack(Track employee)
        {
            await HttpClient.PutAsJsonAsync("/api/Tracks/" + employee.ID, employee);
        }

        public async Task AddTrack(Track Track)
        {
            await HttpClient.PostAsJsonAsync<Track>("/api/Tracks/", Track);
        }

        public async Task DeleteTrack(int employeeId)
        {
            await HttpClient.DeleteAsync("/api/Tracks/" + employeeId);
        }
    }
}
