namespace Data.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        T Get(int id);
        T[] List();
        void Delete(T entity);
    }
}
