using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class NoorEmployee:IEntity
    {
        public string COMPANY_ID { get; set; }
        public string EMP_NO { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
    }
}