using AudioCatalog.Context;
using AudioCatalog.Models;

namespace AudioCatalog.Repository
{
    public class TrackRepository : IRepository<Album>
    {
        private readonly MusicDbContext _context;

        public TrackRepository(MusicDbContext context)
        {
            _context = context;
        }

        public ICollection<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        public Album Get(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.AlbumId == id);
        }

        public void Add(Album item)
        {
            _context.Albums.Add(item);
            _context.SaveChanges();
        }

        public void Update(Album item)
        {
            _context.Albums.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.AlbumId == id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }
    }
}
