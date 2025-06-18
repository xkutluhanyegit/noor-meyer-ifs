using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Models.Responses
{
    public class PersonInfo
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string SicilNo { get; set; }
        public string PersonelNo { get; set; }
        public DateTime GirisTarih { get; set; }
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
    }
}