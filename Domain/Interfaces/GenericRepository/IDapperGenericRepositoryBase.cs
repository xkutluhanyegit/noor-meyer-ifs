using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;

namespace Domain.Interfaces.GenericRepository
{
    public interface IDapperGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(string sql, object param = null);
    }
}