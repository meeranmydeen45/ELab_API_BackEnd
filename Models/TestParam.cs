using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELab_NetCore_API.Models
{
    public class TestParam
    {
        public int Id { get; set; }
        public string ParamName { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string Range { get; set; }
        public int TypeId { get; set; }
    }
}
