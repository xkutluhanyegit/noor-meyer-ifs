using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastracture.ExternalServices.MeyerApi.Models.Responses;

namespace Infrastracture.ExternalServices.MeyerApi.Interfaces
{
    public interface IMeyerTokenService
    {
        Task<MeyerTokenResponses> GetTokenAsync();
    }
}