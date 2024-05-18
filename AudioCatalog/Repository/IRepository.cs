namespace AudioCatalog.Repository
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);

    }
}
