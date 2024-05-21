using CustomerManagement.DAL.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
            
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
