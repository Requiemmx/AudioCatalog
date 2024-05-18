using AudioCatalog.Models;
using AudioCatalog.Repository;

namespace AudioCatalog.Services
{
    public class TrackService
    {
        private readonly IRepository<Track> _trackRepository;

        public TrackService(IRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public List<Track> GetAllTracks()
        {
            return _trackRepository.GetAll().ToList();
        }

        public void AddTrack(Track track)
        {
            _trackRepository.Add(track);
        }

        public void UpdateTrack(Track track)
        {
            _trackRepository.Update(track);
        }

        public void DeleteTrack(int trackId)
        {
            _trackRepository.Delete(trackId);
        }
    }
}
