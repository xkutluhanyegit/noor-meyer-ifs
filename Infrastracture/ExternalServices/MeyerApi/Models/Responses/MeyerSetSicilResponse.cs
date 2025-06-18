using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastracture.ExternalServices.MeyerApi.Models.Responses
{
    public class MeyerSetSicilResponse
    {
        public List<PersonInfo> PersonInfo { get; set; } = new();
        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime Date { get; set; }
    }
}