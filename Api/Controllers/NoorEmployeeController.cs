using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastracture.ExternalServices.MeyerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoorEmployeeController : ControllerBase
    {
        IMeyerTokenService _meyerTokenService;
        IMeyerSetSicilService _meyerSetSicilService;
        INoorEmployeeService _noorEmployeeService;
        public NoorEmployeeController(IMeyerTokenService meyerTokenService,IMeyerSetSicilService meyerSetSicilService,INoorEmployeeService noorEmployeeService)
        {
            _meyerTokenService = meyerTokenService;
            _meyerSetSicilService = meyerSetSicilService;
            _noorEmployeeService = noorEmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tokenResponse = await _meyerTokenService.GetTokenAsync();
            var setSicilResponse = await _meyerSetSicilService.SetSicilAsync();



            await Task.Yield();
            return Ok();
        }

        
    }
}