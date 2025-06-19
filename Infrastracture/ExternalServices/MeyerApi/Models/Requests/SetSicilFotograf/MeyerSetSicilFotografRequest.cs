using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Models.Requests.SetSicilFotograf
{
    public class MeyerSetSicilFotografRequest
    {
        public MeyerConnectAuthentication ConnectAuthentication { get; set; }
        public MeyerFotografRequestData RequestData { get; set; }
    }
}