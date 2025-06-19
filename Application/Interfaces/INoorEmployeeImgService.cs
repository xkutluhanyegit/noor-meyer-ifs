using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface INoorEmployeeImgService
    {
        Task<IEnumerable<NoorEmployeeImg>> GetAllAsync();
    }
}