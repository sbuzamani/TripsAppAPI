namespace TripsApp.ApplicationServices.Interfaces
{
    public interface IBaseService<T, U> where T : class where U : class
    {
        Task<bool> SaveAsync(T t);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(T t);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
    }
}
