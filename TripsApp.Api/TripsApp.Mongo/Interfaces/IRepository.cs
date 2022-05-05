using System.Linq.Expressions;

namespace TripsApp.Mongo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> SaveAsync(T t);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T t);
        Task<T> GetAsync(Guid id);
    }
}
