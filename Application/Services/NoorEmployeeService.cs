using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;

namespace Application.Services
{
    public class NoorEmployeeService : INoorEmployeeService
    {
        private readonly INoorEmployeeRepository _noorEmployeeRepository;
        public NoorEmployeeService(INoorEmployeeRepository noorEmployeeRepository)
        {
            _noorEmployeeRepository = noorEmployeeRepository;
        }
        public Task<IEnumerable<NoorEmployee>> GetAllAsync()
        {
            var result = _noorEmployeeRepository.GetAllAsync();
            return result;
        }
    }
}