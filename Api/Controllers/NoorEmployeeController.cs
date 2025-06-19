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
        IMeyerSetSicilFotografService _meyerSetSicilFotografService;

        INoorEmployeeImgService _noorEmployeeImgService;

        public NoorEmployeeController(IMeyerTokenService meyerTokenService,IMeyerSetSicilService meyerSetSicilService
        ,INoorEmployeeService noorEmployeeService,INoorEmployeeImgService noorEmployeeImgService,IMeyerSetSicilFotografService meyerSetSicilFotografService)
        {
            _meyerTokenService = meyerTokenService;
            _meyerSetSicilService = meyerSetSicilService;
            _noorEmployeeService = noorEmployeeService;
            _noorEmployeeImgService = noorEmployeeImgService;
            _meyerSetSicilFotografService = meyerSetSicilFotografService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tokenResponse = await _meyerTokenService.GetTokenAsync();
            var setSicilResponse = await _meyerSetSicilService.SetSicilAsync();
            var setSicilFotograf = await _meyerSetSicilFotografService.SetSicilFotografAsync();
            
            

            var empImg = await _noorEmployeeImgService.GetAllAsync();



            await Task.Yield();
            return Ok();
        }

        
    }
}