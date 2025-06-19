using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;

namespace Application.Services
{
    public class NoorEmployeeImgService : INoorEmployeeImgService
    {
        private readonly INoorEmployeeImgRepository _noorEmployeeImgRepository;
        public NoorEmployeeImgService(INoorEmployeeImgRepository noorEmployeeImgRepository)
        {
            _noorEmployeeImgRepository = noorEmployeeImgRepository;
        }
        public Task<IEnumerable<NoorEmployeeImg>> GetAllAsync()
        {
            var result = _noorEmployeeImgRepository.GetAllAsync();
            return result;
        }
    }
}