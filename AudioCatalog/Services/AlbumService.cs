using AudioCatalog.Models;
using AudioCatalog.Repository;

namespace AudioCatalog.Services
{
    public class AlbumService
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public Album GetAlbum(int albumId)
        {
            return _albumRepository.Get(albumId);
        }

        public void AddAlbum(Album album)
        {
            _albumRepository.Add(album);
        }

        public void UpdateAlbum(Album album)
        {
            _albumRepository.Update(album);
        }

        public void DeleteAlbum(int albumId)
        {
            _albumRepository.Delete(albumId);
        }

    }
}
