using System.Collections.Generic;
using Task.Models;

namespace Task.RepoServices
{
    public interface ITrackRepository
    {
        public List<Track> GetAll();
        public Track GetDetails(int id);
        public void Insert(Track std);
        public void Update(int id, Track std);
        public void Delete(int id);
    }
}
