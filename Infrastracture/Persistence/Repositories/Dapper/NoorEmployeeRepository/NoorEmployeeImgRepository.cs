using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Base;

namespace Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository
{
    public class NoorEmployeeImgRepository : DapperGenericRepositoryBase<NoorEmployeeImg>, INoorEmployeeImgRepository
    {

        public NoorEmployeeImgRepository(string connectionString) : base(connectionString)
        {
            
        }

        public Task AddAsync(NoorEmployeeImg entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoorEmployeeImg>> GetAllAsync()
        {
            string query = """
                select 
                ss.company_id,
                ss.emp_no,
                ss.picture_id,
                od.data
                from vw_meyer_set_sicil ss, binary_object_data_block_tab od
                where ss.picture_id = od.blob_id
            """;
            var sql = $"{query}";
            return GetAllAsync(sql);
        }

        public Task<NoorEmployeeImg> GetByIdAsync(Expression<Func<NoorEmployeeImg, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}