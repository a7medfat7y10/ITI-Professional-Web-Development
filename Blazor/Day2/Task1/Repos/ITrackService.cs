using SharedLiberary;

namespace Task1.Repos
{
    public interface ITrackService
    {
        Task<IEnumerable<Track>> GetAllTracks();
        Task<Track> GetTrackDetails(int Track);
        Task AddTrack(Track Track);
        Task UpdateTrack(Track Track);
        Task DeleteTrack(int Track);
    }
}
