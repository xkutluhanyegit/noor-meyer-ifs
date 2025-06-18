using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Models.Requests
{
    public class MeyerSetSicilRequest
    {
        public MeyerConnectAuthentication ConnectAuthentication { get; set; }
        public MeyerSicilRequestData RequestData { get; set; }
    }
}