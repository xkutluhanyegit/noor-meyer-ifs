using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Interfaces.Entity;
using Domain.Interfaces.GenericRepository;
using Oracle.ManagedDataAccess.Client;

namespace Infrastracture.Persistence.Repositories.Base
{
    public class DapperGenericRepositoryBase<T> : IDapperGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly string _connectionString;
        public DapperGenericRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public async Task<IEnumerable<T>> GetAllAsync(string sql, object param = null)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(sql, param);
            }
        }
    }
}