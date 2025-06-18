using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoorEmployeeController : ControllerBase
    {
        ITestNoorEmpService _testNoorEmpService;
        public NoorEmployeeController(ITestNoorEmpService testNoorEmpService)
        {
            _testNoorEmpService = testNoorEmpService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            var result2 = await _testNoorEmpService.GetAllAsync();

            await Task.Yield();
            return Ok(result2);
        }
    }
}