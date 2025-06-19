using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Models.Requests.SetSicilFotograf
{
    public class MeyerFotografModel
    {
        public string sicilNo { get; set; }
        public string fotoJGPtoBase64 { get; set; }
    }
}