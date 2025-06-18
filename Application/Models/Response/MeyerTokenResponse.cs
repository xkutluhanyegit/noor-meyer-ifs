using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class MeyerTokenResponse
    {
        public bool success { get; set; }
        public string successMessage { get; set; }
        public bool error { get; set; }
        public string errorMessage { get; set; }
        public string date { get; set; }
    }
}