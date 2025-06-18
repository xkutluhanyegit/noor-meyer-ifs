using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;

namespace Domain.Interfaces.GenericRepository
{
    public interface IGenericRepositoryBase<T> where T: class,IEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Expression<Func<T,bool>> filter);
        Task AddAsync(T entity);
        Task UpdateAsync(int id);
        Task DeleteAsync(int id);

    }
}