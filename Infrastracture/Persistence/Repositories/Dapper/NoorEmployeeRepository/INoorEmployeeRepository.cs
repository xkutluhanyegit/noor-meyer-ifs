using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.GenericRepository;

namespace Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository
{
    public interface INoorEmployeeRepository:IGenericRepositoryBase<NoorEmployee>
    {
        
    }
}