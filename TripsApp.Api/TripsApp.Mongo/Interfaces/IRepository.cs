namespace TripsApp.Mongo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveAsync(T t);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T t);
        Task<T> GetAsync(int id);
    }
}
