using AudioCatalog.Context;
using AudioCatalog.Models;

namespace AudioCatalog.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly MusicDbContext _context;
        public UserRepository(MusicDbContext authContext)
        {

            _context = authContext;
        }
        public void Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Users.First(x => x.Id == id);
            if (model != null)
            {
                _context.Users.Remove(model);
                _context.SaveChanges();
            }
        }

        public User Get(int id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public User GetUserByName(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
