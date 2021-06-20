using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELab_NetCore_API.Models
{
    public class TestType
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public int CategoryId { get; set; }
    }
}
