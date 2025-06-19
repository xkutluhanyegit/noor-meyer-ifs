using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class NoorEmployeeImg:IEntity
    {
        public string COMPANY_ID { get; set; }
        public string EMP_NO { get; set; }
        public string PICTURE_ID { get; set; }
        public byte[] DATA { get; set; }
    }
}