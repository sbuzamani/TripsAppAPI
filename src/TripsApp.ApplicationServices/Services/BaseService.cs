using AutoMapper;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public abstract class BaseService<T, U> : IBaseService<T, U> where T : class where U : Entity
    {
        private readonly IRepository<U> _repository;
        private readonly IMapper _mapper;
        public BaseService(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result == null)
            {
                return null;
            }
            return _mapper.Map<T>(result);
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            var result = await _repository.ListAsync();

            if (result == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<T>>(result);
        }

        public virtual async Task<bool> SaveAsync(T t)
        {
            var toSave = _mapper.Map<U>(t);
            return await _repository.SaveAsync(toSave);
        }

        public virtual async Task<bool> UpdateAsync(T t)
        {
            var toUpdate = _mapper.Map<U>(t);
            return await _repository.UpdateAsync(toUpdate);
        }
    }
}
