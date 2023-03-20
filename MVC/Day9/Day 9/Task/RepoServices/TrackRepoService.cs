using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Task.Models;

namespace Task.RepoServices
{
    public class TrackRepoService: ITrackRepository
    {
        public Day9DbContext Context { get; set; }
        public TrackRepoService(Day9DbContext context)
        {
            Context = context;
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetDetails(int id)
        {
            return Context.Tracks.Find(id);
        }

        public void Insert(Track tr)
        {
            Context.Tracks.Add(tr);
            Context.SaveChanges();
        }

        public void Update(int id, Track tr)
        {
            Track track = Context.Tracks.Find(id);
            track.TrackName = tr.TrackName;
            track.Description = tr.Description;

            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Remove(Context.Tracks.Find(id));

            Context.SaveChanges();
        }
    }
}
