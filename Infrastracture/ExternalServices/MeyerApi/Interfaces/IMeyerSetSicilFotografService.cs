using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Interfaces
{
    public interface IMeyerSetSicilFotografService
    {
        Task<string> SetSicilFotografAsync();
    }
}