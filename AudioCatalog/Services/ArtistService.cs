using AudioCatalog.Models;
using AudioCatalog.Repository;

namespace AudioCatalog.Services
{
    public class ArtistService
    {
        private readonly IRepository<Artist> _artistRepository;

        public ArtistService(IRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public List<Artist> GetAllArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public void AddArtist(Artist artist)
        {
            _artistRepository.Add(artist);
        }

        public void UpdateArtist(Artist artist)
        {
            _artistRepository.Update(artist);
        }

        public void DeleteArtist(int artistId)
        {
            _artistRepository.Delete(artistId);
        }
    }
}
