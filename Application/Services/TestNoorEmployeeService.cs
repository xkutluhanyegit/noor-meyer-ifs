using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;

namespace Application.Services
{
    public class TestNoorEmployeeService : ITestNoorEmpService
    {
        private readonly INoorEmployeeRepository _noorEmployeeRepository;
        public TestNoorEmployeeService(INoorEmployeeRepository noorEmployeeRepository)
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