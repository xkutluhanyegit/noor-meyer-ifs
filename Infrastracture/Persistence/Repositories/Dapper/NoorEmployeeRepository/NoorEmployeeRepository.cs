using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Base;
using Microsoft.VisualBasic;

namespace Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository
{
    public class NoorEmployeeRepository : DapperGenericRepositoryBase<NoorEmployee>, INoorEmployeeRepository
    {
        
        public NoorEmployeeRepository(string connectionString) :base(connectionString)
        {
            
        }
        

        public Task AddAsync(NoorEmployee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoorEmployee>> GetAllAsync()
        {
            string query = "SELECT COMPANY_ID, EMP_NO, FNAME, LNAME FROM company_person_all WHERE company_id IN ('NE', 'KL', 'NT', 'KS', 'KK', 'GK')";
            var sql = $"{query}";
            return GetAllAsync(sql);
        }

        public Task<NoorEmployee> GetByIdAsync(Expression<Func<NoorEmployee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}